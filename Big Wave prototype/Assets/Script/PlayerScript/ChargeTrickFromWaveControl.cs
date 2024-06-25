using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickFromWaveControl : MonoBehaviour
{
    //������������
    //�g�̓����ɔg��肵�Ă���Ƃ���outSideChargeTrick�AinSideChargeTrick�̍��v���g���b�N��������
    [Header("�`���[�W�{��(�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������)")]
    [SerializeField] float[] chargeRate;//�`���[�W�{��
    [Header("�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l")]
    [SerializeField] float outSideChargeTrick=1;//�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l
    [Header("�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l")]
    [SerializeField] float inSideChargeTrick=2;//�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l
    [Header("�`���[�W�p�̗��G�t�F�N�g")]
    [SerializeField] GameObject chargeSpark;//�`���[�W�p�̗��G�t�F�N�g
    private bool chargeNow=false;//���g���b�N���`���[�W���Ă��邩
    private float sinceLastChargeTime = 0.1f;//�Ō�Ƀ`���[�W����Ă���̎���
    private float chargeBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    JudgeTouchWave touchWave;
    Player player;
    Wave wave;
    BuffOfPlayer buffOfPlayer;
    ProcessFeverMode processFeverPoint;
  
    public bool ChargeNow
    {
        get { return chargeNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
        buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>();
        processFeverPoint = gameObject.GetComponent<ProcessFeverMode>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//�g�ɐG���Ă��邩�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��

        JudgeChargeNow();//���`���[�W���Ă��邩����
    }

    //�g�ɐG��ăg���b�N���`���[�W
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        wave = wavePrefab.GetComponent<Wave>();//Wave�̏��(isTouched)���擾

        //��x���G��Ă��Ȃ������̔g����`���[�W����
        if (wavePrefab.CompareTag("InsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick);
        }

        //��x�G��Ă��Ȃ��O���̔g����`���[�W����
        else if (wavePrefab.CompareTag("OutsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick);
        }
    }

    float ChargeTrickAmount(float b)//�`���[�W�����g���b�N��(b�ɂ�inSideChargeTrick��outSideChargeTrick������)
    {
        return b * buffOfPlayer.ChargeTrick.CurrentGrowthRate * processFeverPoint.CurrentChargeTrick_GrowthRate * chargeRate[player.MaxCount];
    }

    //�g�ɐG��ăg���b�N���`���[�W����Ƃ��̓����̏���
    //a(����)�ɂ�inSideChargeTrick��outSideChargeTrick������(���܂�g���b�N��)
    void ProcessingChargeTrick(float a)
    {
        if(player.MaxCount!=player.TrickGaugeNum)
        {
            player.ChargeTrickPoint(ChargeTrickAmount(a));//�g���b�N���`���[�W
        }
        
        wave.IsTouched = true;//��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)
        sinceLastChargeTime = 0f;//���`���[�W���Ă��锻��ɂ���
    }



    void JudgeChargeNow()//���`���[�W���Ă��邩����
    {
        sinceLastChargeTime += Time.deltaTime;

        if (sinceLastChargeTime < chargeBorderTime)//�Ō�Ƀ`���[�W���Ă���chargeBorderTime(�b)�����Ȃ獡�`���[�W���Ă锻��
        {
            chargeNow = true;
        }
        else
        {
            chargeNow = false;
        }
    }



    void DisplayChargeSpark()//�g�ɐG���Ă��邩�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��
    {
        if(ChargeNow&&touchWave.TouchWaveNow)
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
