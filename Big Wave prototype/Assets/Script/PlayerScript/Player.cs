using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //������������
    private float hp = 100;//���݂̗̑�
    [Header("�v���C���[�̍ő�̗�")]
    [SerializeField] float hpMax = 100;//�ő�̗�
    
    [Header("�v���C���[��1�Q�[�W�̍ő�g���b�N")]
    [SerializeField] float trickGaugeMax = 50;//1�Q�[�W�ɓ���ő�g���b�N(�S�Q�[�W�����e��)
    [Header("�v���C���[�̃g���b�N�Q�[�W�̐�(�{��)")]
    [SerializeField] int trickGaugeNum=6;//�g���b�N�Q�[�W�̖{��
    private bool barrier = false;//���G��Ԃ�(true�̎����G�ɂȂ�)
    private float[] trick;//�g���b�N�Q�[�W(�e��trickMax�̃Q�[�W��trickGaugeNum����)
    private int maxCount=0;//���^���̃g���b�N�Q�[�W�̗�
    SceneControlManager sceneControlManager;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float HpMax
    {
       get { return hpMax; }
    }

    public float[] Trick
    {
        get { return trick; }
    }

    public float TrickMax
    {
        get { return trickGaugeMax; }
    }

    public int TrickGaugeNum
    {
        get { return trickGaugeNum; }
    }

    public int MaxCount
    {
        get { return maxCount; }
    }

    public bool Barrier
    {
        get { return barrier; }
        set { barrier = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hp�̏�����
        hp = hpMax;
        //�g���b�N�̏�����
        trick = new float[trickGaugeNum];
        for(int i=0;i<trick.Length ;i++)
        {
            trick[i] = 0;
        }

        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp=Mathf.Clamp(hp,0,hpMax);//�̗͂����E�˔j���Ȃ��悤��

        Dead();//�G�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    }

    public void ChargeTrick(float charge)//�g���b�N�̃`���[�W
    {
        if(maxCount==trickGaugeNum)//�ǂ̃Q�[�W�����^���̎��͏������Ȃ�
        {
            return;
        }

        for(int i=maxCount; i<trick.Length;i++)
        {
            trick[i] += charge;

            if (trick[i]>=trickGaugeMax)//���`���[�W���Ă���Q�[�W�����^���ɂȂ�����
            {
                charge = trick[i]-trickGaugeMax;//���̃Q�[�W�Ƀ`���[�W���镪
                trick[i] = trickGaugeMax;//�g���b�N�����E�˔j���Ȃ��悤��
                maxCount++;//���^���̃g���b�N�Q�[�W�̐��𑝂₷
            }
            else//���`���[�W���Ă���Q�[�W�����^���ɂȂ�Ȃ�������`���[�W�������I����
            {
                break;
            }
        }
    }

    public bool ConsumeCharge(int cost)//�g���b�N�̏���(�g���Q�[�W�ʂ������ɓ����A�g�p�Q�[�W������Ȃ���false��Ԃ����̂ł���ŏ����̉E�s�𔻒f)
    {
        if(maxCount<cost)//�g���Q�[�W�ʂ�����Ȃ����
        {
            return false;
        }

        else//������
        {
            //�g���Q�[�W�̒��g��0�ɂ���
            for(int i=0; i<cost;i++)
            {
                trick[maxCount - 1 - i] = 0;
            }

            //
            if(maxCount==trickGaugeNum)
            {

            }
            else
            {
                trick[maxCount - cost] = trick[maxCount];
                trick[maxCount] = 0;
            }
            
            //���^���̃Q�[�W�̐����g���������炷
            maxCount -= cost;

            return true;
        }
    }

    void Dead()//�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    {
        if(hp <=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
}
