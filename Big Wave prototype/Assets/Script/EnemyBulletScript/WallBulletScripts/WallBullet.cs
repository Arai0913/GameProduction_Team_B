using UnityEngine;

//�쐬�ҁF�K��

public partial class WallBullet : MonoBehaviour
{
    GameObject[,] walls;//���������ǂ̃v���n�u���Ǘ�����z��

    GameObject[,] wallsPreview;//�U���͈͗\���v���n�u���Ǘ�����z��

    Rigidbody wallAreaRigidbody;//�ǂ̐����͈̓v���n�u�̑��x�Ǘ��p�̕ϐ�

    Camera mainCamera;

    EnemyActionTypeShotWall enemyActionTypeShotWall;

    private float currentDelayTime;//�o�ߎ��Ԃ̌v���p

    private float shotPosY;//wallArea�̐����n�_�I�u�W�F�N�g��Y���W

    private bool generated = false;//�ǂ��������ꂽ���ǂ���

    private int wallsCount;//�ǂ̖����Ǘ��p�̕ϐ�

    public bool Generated
    {
        get { return generated; }
        private set { generated = value; }
    }

    public void SetWallBullet(EnemyActionTypeShotWall enemyActionTypeShotWall)
    {
        this.enemyActionTypeShotWall = enemyActionTypeShotWall;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyActionTypeShotWall.WallAreaInstance != null)
        {
            wallAreaRigidbody = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Rigidbody>();

            shotPosY = enemyActionTypeShotWall.ShotPosObject.GetComponent<Transform>().transform.localPosition.y;//�e�̔��˒n�_��Y���W���擾

            mainCamera = Camera.main;

            PositioningWallArea();//�ǂ̐����͈͂̈ʒu��ݒ�

            GenerateWalls();//�ǂ𐶐�
            PositioningWalls();//�ǂ̈ʒu�𒲐�

            GenerateWallsPreview();//�U���͈͗\���̐���
            PositioningWallsPreview();//�U���͈͗\���̈ʒu�𒲐�

            generated = true;

            currentDelayTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentDelayTime += Time.deltaTime;

        if (!enemyActionTypeShotWall.Shoted)//�e���܂����˂���Ă��Ȃ��Ȃ�
        {
            float alpha = Mathf.PingPong(currentDelayTime / enemyActionTypeShotWall.TransparencyCycleDuration * 255f, 255f);
            SetPreviewTransparency(alpha / 255f);//�U���͈͗\���̓����x��ݒ肷��
        }

        else//��莞�Ԍo�߂��o�߂�����
        {
            DisableWallsPreview();//�U���͈̗͂\���̖���������
            AddForceToWalls();//�ǂɗ͂�������
        }
    }
}