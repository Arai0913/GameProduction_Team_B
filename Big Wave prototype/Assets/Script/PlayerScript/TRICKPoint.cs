using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickPoint : MonoBehaviour
{
    [Header("1�Q�[�W�ɓ���ő�g���b�N�|�C���g�̗�")]
    [SerializeField] float trickPointMax = 50;//1�Q�[�W�ɓ���ő�g���b�N�|�C���g(�S�Q�[�W�����e��)
    [Header("�g���b�N�Q�[�W�̐�(�{��)")]
    [SerializeField] int trickGaugeNum = 6;//�g���b�N�Q�[�W�̖{��
    private float[] trickPoint;//�g���b�N�|�C���g(�e��trickGaugeMax�̃Q�[�W��trickGaugeNum����)
    private int maxCount = 0;//���^���̃g���b�N�Q�[�W�̐�

    public float[] TrickPoint_
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

    // Start is called before the first frame update
    void Start()
    {
        //�g���b�N�̏�����
        trickPoint = new float[trickGaugeNum];
        for (int i = 0; i < trickPoint.Length; i++)
        {
            trickPoint[i] = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Charge(float charge)//�g���b�N�|�C���g�̃`���[�W
    {
        if (maxCount == trickGaugeNum)//�S�Q�[�W�����^���̎��͏������Ȃ�
        {
            return;
        }

        for (int i = maxCount; i < trickPoint.Length; i++)
        {
            trickPoint[i] += charge;

            if (trickPoint[i] >= trickPointMax)//���`���[�W���Ă���Q�[�W�����^���ɂȂ�����
            {
                charge = trickPoint[i] - trickPointMax;//���̃Q�[�W�Ƀ`���[�W���镪
                trickPoint[i] = trickPointMax;//�g���b�N�|�C���g�����E�˔j���Ȃ��悤��
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
                trickPoint[maxCount - 1 - i] = 0;
            }


            if (maxCount == trickGaugeNum)
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
}
