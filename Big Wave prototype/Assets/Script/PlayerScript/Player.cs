using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //������������
    //HP�֌W
    [Header("�v���C���[�̍ő�̗�")]
    [SerializeField] float hpMax = 100;//�ő�̗�
    private float hp = 100;//���݂̗̑�

    //�g���b�N�|�C���g�֌W
    [Header("�v���C���[��1�Q�[�W�ɓ���ő�g���b�N�|�C���g�̗�")]
    [SerializeField] float trickPointMax = 50;//1�Q�[�W�ɓ���ő�g���b�N�|�C���g(�S�Q�[�W�����e��)
    [Header("�v���C���[�̃g���b�N�Q�[�W�̐�(�{��)")]
    [SerializeField] int trickGaugeNum=6;//�g���b�N�Q�[�W�̖{��
    private float[] trickPoint;//�g���b�N�|�C���g(�e��trickGaugeMax�̃Q�[�W��trickGaugeNum����)
    private int maxCount=0;//���^���̃g���b�N�Q�[�W�̐�

    //�t�B�[�o�[�|�C���g�֌W
    [Header("�ő�t�B�[�o�[�|�C���g")]
    [SerializeField] float feverPointMax = 500f;//�ő�t�B�[�o�[�|�C���g
    private float feverPoint=0f;//���݂̃t�B�[�o�[�|�C���g

    SceneControlManager sceneControlManager;

    //HP�֌W
    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float HpMax
    {
       get { return hpMax; }
    }

    //�g���b�N�|�C���g�֌W
    public float[] TrickPoint
    {
        get { return trickPoint; }
    }

    public float TrickPointMax//�g���b�N�Q�[�W1�{�ɓ���g���b�N�̗e��
    {
        get { return trickPointMax; }
    }

    public int TrickGaugeNum//�g���b�N�Q�[�W�̖{��
    {
        get { return trickGaugeNum; }
    }

    public int MaxCount//���^���̃g���b�N�Q�[�W�̖{��
    {
        get { return maxCount; }
    }

    //�t�B�[�o�[�|�C���g�֌W
    public float FeverPoint
    {
        get { return feverPoint; }
        set { feverPoint = value; }
    }

    public float FeverPointMax
    {
        get { return feverPointMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hp�̏�����
        hp = hpMax;
        //�g���b�N�̏�����
        trickPoint = new float[trickGaugeNum];
        for(int i=0;i<trickPoint.Length ;i++)
        {
            trickPoint[i] = 0f;
        }
        //�t�B�[�o�[�|�C���g�̏�����
        feverPoint = 0f;

        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp=Mathf.Clamp(hp,0f,hpMax);//�̗͂����E�˔j���Ȃ��悤��

        feverPoint = Mathf.Clamp(feverPoint, 0f, feverPointMax);//�t�B�[�o�[�|�C���g�����E�˔j���Ȃ��悤��

        Dead();//�G�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    }

    //�g���b�N�|�C���g�֌W�̃��\�b�h

    public void ChargeTrickPoint(float charge)//�g���b�N�|�C���g�̃`���[�W
    {
        if(maxCount==trickGaugeNum)//�S�Q�[�W�����^���̎��͏������Ȃ�
        {
            return;
        }

        for(int i=maxCount; i<trickPoint.Length;i++)
        {
            trickPoint[i] += charge;

            if (trickPoint[i]>=trickPointMax)//���`���[�W���Ă���Q�[�W�����^���ɂȂ�����
            {
                charge = trickPoint[i]-trickPointMax;//���̃Q�[�W�Ƀ`���[�W���镪
                trickPoint[i] = trickPointMax;//�g���b�N�|�C���g�����E�˔j���Ȃ��悤��
                maxCount++;//���^���̃g���b�N�Q�[�W�̐��𑝂₷
            }
            else//���`���[�W���Ă���Q�[�W�����^���ɂȂ�Ȃ�������`���[�W�������I����
            {
                break;
            }
        }
    }

    public bool ConsumeTrickPoint(int cost)//�g���b�N�|�C���g�̏���(�g���Q�[�W�ʂ������ɓ����A�g�p�Q�[�W������Ȃ���false��Ԃ����̂ł���ŏ����̉E�s�𔻒f)
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
                trickPoint[maxCount - 1 - i] = 0;
            }

            //
            if(maxCount==trickGaugeNum)
            {

            }
            else
            {
                trickPoint[maxCount - cost] = trickPoint[maxCount];
                trickPoint[maxCount] = 0;
            }
            
            //���^���̃Q�[�W�̐����g���������炷
            maxCount -= cost;

            return true;
        }
    }

    //��ŕʂ̃X�N���v�g�Ɉڂ�����
    void Dead()//�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    {
        if(hp <=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
}
