using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("����")]
    [SerializeField] GameObject wallPrefab;//�ǂ̃v���n�u
    [Header("���ǂ̐����͈�")]
    [SerializeField] GameObject wallAreaPrefab;//�ǂ𐶐�����͈͂̃v���n�u
    [Header("���U���͈̗͂\���\��")]
    [SerializeField] GameObject wallPreviewPrefab;//�ǂ͈̔͗\���p�̃v���n�u

    [Header("����������ǂ̉��̕�����")]
    [SerializeField] int width = 4;//��������ǂ̉��̕�����
    [Header("����������ǂ̏c�̕�����")]
    [SerializeField] int height = 4;//��������ǂ̏c�̕�����

    [Header("�����ꂼ��̕ǂ����������m��")]
    [SerializeField] float generationProbability = 0.5f;//�ǂ����������m��

    [Header("�������x���ω�����T�C�N���̎���")]
    [SerializeField] float transparencyCycleDuration = 0.5f;//�����x���ω�����T�C�N���̎���

    [Header("���U���\���\���𐶐�����ʒu")]
    [SerializeField] protected Transform spawnPosOfWallPreview;//�U���\���\���𐶐�����ʒu

    [Header("�������͈͂��Q�[����ʂɍ��킹�邩�ǂ���")]
    [SerializeField] bool matchCameraSize = true;//�J�����̑傫���ɍ��킹�邩�ǂ���

    [Header("������")]
    [SerializeField] protected float shotPower = 30f;//����
    [Header("���e�����������ʒu")]
    [SerializeField] protected Transform shotPosObject;//�e�����������ʒu

    [Header("���ǂ𐶐����Ă��猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime = 2.0f;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�

    [Header("��GamePos")]
    [SerializeField] protected GameObject gamePos;//GamePos

    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;

    GameObject wallAreaInstance;
    Rigidbody bulletRb;

    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    bool shoted;//�e����������

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

    public GameObject WallAreaInstance
    {
        get { return wallAreaInstance; }
        set { wallAreaInstance = value; }
    }

    public Transform SpawnPosOfWallPreview { get { return spawnPosOfWallPreview; } }
    public Transform ShotPosObject { get { return shotPosObject; } }
    public GameObject GamePos { get { return gamePos; } }

    public int Width { get { return width; } }
    public int Height { get { return height; } }
    public float GenerationProbability { get { return generationProbability; } }
    public float TransparencyCycleDuration { get { return transparencyCycleDuration; } }
    public bool MatchCameraSize { get { return matchCameraSize; } }
    public bool Shoted { get { return shoted; } }
}