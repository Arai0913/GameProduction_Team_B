using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //������������
    //�g�̓����ɔg��肵�Ă���Ƃ���outSideChargeTrick�AinSideChargeTrick�̍��v���g���b�N��������
    [Header("�`���[�W�{��(�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������)")]
    [SerializeField] float[] chargeRate;//�`���[�W�{��
    [Header("�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l")]
    [SerializeField] float outSideChargeTrick=1;//�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l
    [Header("�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l")]
    [SerializeField] float inSideChargeTrick=2;//�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l
    Player player;
    BuffOfPlayer buffOfPlayer;
    ProcessFeverMode processFeverPoint;
    ChangeChargeTrick changeChargeTrickOnWave;
    JudgeChargeNow judgeChargeNow;
  
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>();
        processFeverPoint = gameObject.GetComponent<ProcessFeverMode>();
        changeChargeTrickOnWave=gameObject.GetComponent<ChangeChargeTrick>();
        judgeChargeNow=gameObject.GetComponent<JudgeChargeNow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�g�ɐG��ăg���b�N���`���[�W
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        Wave wave = wavePrefab.GetComponent<Wave>();//Wave�̏��(isTouched)���擾

        //��x���G��Ă��Ȃ������̔g����`���[�W����
        if (wavePrefab.CompareTag("InsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick,wave);
        }

        //��x�G��Ă��Ȃ��O���̔g����`���[�W����
        else if (wavePrefab.CompareTag("OutsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick, wave);
        }
    }

    float ChargeTrickAmount(float b)//�`���[�W�����g���b�N��(b�ɂ�inSideChargeTrick��outSideChargeTrick������)
    {
        return b * buffOfPlayer.ChargeTrick.CurrentGrowthRate * processFeverPoint.CurrentChargeTrick_GrowthRate * chargeRate[player.MaxCount]*changeChargeTrickOnWave.CurrentChargeRate;
    }

    //�g�ɐG��ăg���b�N���`���[�W����Ƃ��̓����̏���
    //a(����)�ɂ�inSideChargeTrick��outSideChargeTrick������(���܂�g���b�N��)
    void ProcessingChargeTrick(float a,Wave wave)
    {
        if(player.MaxCount!=player.TrickGaugeNum)
        {
            player.ChargeTrickPoint(ChargeTrickAmount(a));//�g���b�N���`���[�W
        }
        
        wave.IsTouched = true;//��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)
        judgeChargeNow.ResetSinceLastChargedTime();//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
    }
}





