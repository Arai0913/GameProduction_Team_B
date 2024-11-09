using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�g���b�N�|�C���g
public class TrickPoint : MonoBehaviour
{
    [System.Serializable]
    class A_TrickPoint
    {
        [Header("���^���ɂȂ������ɌĂԃC�x���g")]
        [SerializeField] UnityEvent fullEvent;
        private float trickPoint=0;//�g���b�N�|�C���g

        public A_TrickPoint()
        {
            trickPoint = 0;
        }

        public float TrickPoint
        {
            get { return trickPoint; } 
            set {  trickPoint = value; }
        }

        public void FullTrigger()//���^���ɂȂ�������ɌĂԏ���
        {
            fullEvent.Invoke();
        }
    }

    [Header("1�Q�[�W�ɓ���ő�g���b�N�|�C���g�̗�")]
    [SerializeField] float trickPointMax = 50;//1�Q�[�W�ɓ���ő�g���b�N�|�C���g(�S�Q�[�W�����e��)
    [Header("�g���b�N�Q�[�W�̖{�����v�f������Ă�������")]
    [SerializeField] A_TrickPoint[] trickPoint;//�g���b�N�|�C���g(�e��trickGaugeMax�̃Q�[�W��trickGaugeNum����)
    private int maxCount = 0;//���^���̃g���b�N�Q�[�W�̐�

    public float this[int index]
    {
        get { return trickPoint[index].TrickPoint; }
    }

    public float TrickPointMax//�g���b�N�Q�[�W1�{�ɓ���g���b�N�̗e��
    {
        get { return trickPointMax; }
    }

    public int TrickGaugeNum//�g���b�N�Q�[�W�̖{��
    {
        get { return trickPoint.Length; }
    }

    public int MaxCount//���^���̃g���b�N�Q�[�W�̖{��
    {
        get { return maxCount; }
    }

    public bool Full//�S�ẴQ�[�W�����^����
    {
        get { return maxCount == trickPoint.Length; }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Charge(float charge)//�g���b�N�|�C���g�̃`���[�W
    {
        if (maxCount == trickPoint.Length)//�S�Q�[�W�����^���̎��͏������Ȃ�
        {
            return;
        }

        for (int i = maxCount; i < trickPoint.Length; i++)
        {
            trickPoint[i].TrickPoint += charge;

            if (trickPoint[i].TrickPoint >= trickPointMax)//���`���[�W���Ă���Q�[�W�����^���ɂȂ�����
            {
                charge = trickPoint[i].TrickPoint - trickPointMax;//���̃Q�[�W�Ƀ`���[�W���镪
                trickPoint[i].TrickPoint = trickPointMax;//�g���b�N�|�C���g�����E�˔j���Ȃ��悤��
                trickPoint[i].FullTrigger();
                maxCount++;//���^���̃g���b�N�Q�[�W�̐��𑝂₷
            }
            else//���`���[�W���Ă���Q�[�W�����^���ɂȂ�Ȃ�������`���[�W�������I����
            {
                break;
            }
        }
    }

    public bool Consume(int cost)//�g���b�N�|�C���g�̏���(�g���Q�[�W�ʂ������ɓ����A�g�p�Q�[�W������Ȃ���false��Ԃ����̂ł���Ńg���b�N�|�C���g�̑��E�s���𔻒f)
    {
        if (maxCount < cost)//�g���Q�[�W�ʂ�����Ȃ����
        {
            return false;
        }

        else//������
        {
            //�g���Q�[�W�̒��g��0�ɂ���
            for (int i = 0; i < cost; i++)
            {
                trickPoint[maxCount - 1 - i].TrickPoint = 0;
            }


            if (maxCount != trickPoint.Length)
            {
                trickPoint[maxCount - cost].TrickPoint = trickPoint[maxCount].TrickPoint;
                trickPoint[maxCount].TrickPoint = 0;
            }

            //���^���̃Q�[�W�̐����g���������炷
            maxCount -= cost;

            return true;
        }
    }
}
