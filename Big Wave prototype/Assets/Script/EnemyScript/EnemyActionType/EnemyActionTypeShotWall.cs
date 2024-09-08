using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [Header("����")]
    [SerializeField] GameObject wallPrefab;//�ǂ̃v���n�u
    [Header("�ǂ̐����͈�")]
    [SerializeField] GameObject wallAreaPrefab;//�ǂ𐶐�����͈͂̃v���n�u
    [Header("�U���͈̗͂\���\��")]
    [SerializeField] GameObject wallPreviewPrefab;//�ǂ͈̔͗\���p�̃v���n�u
    [Header("�ǂ̐����͈͂̒��")]
    [SerializeField] GameObject ground;//�ǂ̐����͈͂̒�ӂ̃v���n�u

    [Header("����������ǂ̉��̕�����")]
    [SerializeField] int width = 4;//��������ǂ̉��̕�����
    [Header("����������ǂ̏c�̕�����")]
    [SerializeField] int height = 4;//��������ǂ̏c�̕�����

    [Header("�����ꂼ��̕ǂ����������m��")]
    [SerializeField] float generationProbability = 0.5f;//�ǂ����������m��

    [Header("���U���͈̗͂\����\�����鎞��")]
    [SerializeField] float previewDisplayDuration = 5f;//�U���͈̗͂\����\�����鎞��

    [Header("�������x���ω�����T�C�N���̎���")]
    [SerializeField] float transparencyCycleDuration = 0.5f;//�����x���ω�����T�C�N���̎���

    [Header("���U���\���\���̃v���C���[����̋���")]
    [SerializeField] float previewDistanceFromPlayer = 2.0f;//�v���C���[����̋���

    [Header("�������͈͂��Q�[����ʂɍ��킹�邩�ǂ���")]
    [SerializeField] bool matchCameraSize = true;//�J�����̑傫���ɍ��킹�邩�ǂ���

    [Header("������")]
    [SerializeField] protected float shotPower = 30f;//����
    [Header("���e�����������ʒu")]
    [SerializeField] protected Transform shotPosObject;//�e�����������ʒu

    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�

    [Header("���ǂ𐶐����Ă���͂�������܂ł̎���")]
    [SerializeField] float shotTime = 2.0f;//�ǂ𐶐����Ă���͂�������܂ł̎���

    [Header("��GamePos")]
    [SerializeField] protected GameObject gamePos;//GamePos

    GameObject enemy;

    GameObject wallAreaInstance;

    Rigidbody bulletRb;

    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������

    private float elapsedTime;//�o�ߎ��Ԃ̌v���p

    private bool shoted;

    bool nowCenter;//��ʂ̒����ɂ��邩�ǂ���

    public GameObject WallPrefab
    {
        get { return wallPrefab; }
        set { wallPrefab = value; }
    }

    public GameObject WallAreaPrefab
    {
        get { return wallAreaPrefab; }
        set { wallAreaPrefab = value; }
    }

    public GameObject WallPreviewPrefab
    {
        get { return wallPreviewPrefab; }
        set { wallPreviewPrefab = value; }
    }

    public GameObject Ground
    {
        get { return ground; }
    }

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }

    public float GenerationProbability
    {
        get { return generationProbability; }
    }

    public float PreviewDisplayDuration
    {
        get { return previewDisplayDuration; }
    }

    public float TransparencyCycleDuration
    {
        get { return transparencyCycleDuration; }
    }

    public float PreviewDistanceFromPlayer
    {
        get { return previewDistanceFromPlayer; }
    }

    public bool MatchCameraSize
    {
        get { return matchCameraSize; }
    }

    public GameObject WallAreaInstance
    {
        get { return wallAreaInstance; }
        set { wallAreaInstance = value; }
    }


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        enemy = GameObject.FindWithTag("Enemy");

        currentDelayTime = 0;
        elapsedTime = 0f;
        shoted = false;
        nowCenter = false;
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        Camera mainCamera = Camera.main;
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, mainCamera.nearClipPlane);
        Vector3 worldCenter = mainCamera.ScreenToWorldPoint(screenCenter);

        // �G�I�u�W�F�N�g���ǂ𐶐����Ă��Ȃ����A��ʂ̒����ɂ���Ȃ�
        if (nowCenter)
        {
            enemy.GetComponent<Rigidbody>().isKinematic = true;
            enemy.transform.position = new Vector3(worldCenter.x, enemy.transform.position.y, enemy.transform.position.z);
        }

        if (IsEnemyInCenter(worldCenter.x))
        {
            nowCenter = true;

            if (currentDelayTime >= delayTime && !shoted)//�w��̒x�����ԂɒB�������܂��e�������Ă��Ȃ���
            {
                if (wallAreaInstance == null)
                {
                    GenerateWallArea();
                }

                else
                {
                    Shot();
                }
            }
        }
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        enemy.GetComponent<Rigidbody>().isKinematic = false;
    }

    bool IsEnemyInCenter(float worldCenterX)
    {
        float threshold = 0.5f;

        return Mathf.Abs(enemy.transform.position.x - worldCenterX) <= threshold;
    }

    void GenerateWallArea()
    {
        if (wallAreaInstance == null)
        {
            //�U�������������ʒu���擾
            Vector3 shotPos = shotPosObject.transform.position;
            Quaternion shotRot = shotPosObject.transform.rotation;

            wallAreaInstance = Instantiate(wallAreaPrefab, shotPos, shotRot, gamePos.transform);

            WallBullet wallBulletScript = wallAreaInstance.AddComponent<WallBullet>();

            //ToggleColliderOfWallBullet��wallBullet�̎Q�Ƃ�ݒ�
            wallBulletScript.SetWallBullet(this);

            //�e��Rigidbody���擾
            bulletRb = wallAreaInstance.GetComponent<Rigidbody>();

            elapsedTime = 0f;
        }
    }

    void Shot() //�e������
    {
        /*if (wallAreaInstance == null)
        {
            //�U�������������ʒu���擾
            Vector3 shotPos = shotPosObject.transform.position;
            Quaternion shotRot = shotPosObject.transform.rotation;

            wallAreaInstance = Instantiate(wallAreaPrefab, shotPos, shotRot, gamePos.transform);

            WallBullet wallBulletScript = wallAreaInstance.AddComponent<WallBullet>();

            //ToggleColliderOfWallBullet��wallBullet�̎Q�Ƃ�ݒ�
            wallBulletScript.SetWallBullet(this);

            //�e��Rigidbody���擾
            bulletRb = wallAreaInstance.GetComponent<Rigidbody>();

            elapsedTime = 0f;
        }*/

        //else
        //{
            elapsedTime += Time.deltaTime;

            if (elapsedTime > shotTime)
            {
                //�e����������
                bulletRb.AddForce(-transform.forward * shotPower, ForceMode.Impulse);

                shoted = true;
            }
        //}
    }
}
