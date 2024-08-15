using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���쐬��:���R
//�g���b�N�̃`���[�W�֘A
public class ChargeTrick : MonoBehaviour
{
    //�g�̓����ɔg��肵�Ă���Ƃ���outSideChargeTrick�AinSideChargeTrick�̍��v���g���b�N��������
    private bool chargeStandby = false;//���ꂪtrue�ɂȂ��Ă��鎞���g�ɐG��Ă��鎞�̂݃g���b�N���`���[�W�ł���
    JudgeChargeNow judgeChargeNow;
    TRICKPoint player_TrickPoint;
    FeverMode feverMode;
    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    ChangeChargeTrickTheCharger changeChargeTrickTheCharger;

    public bool ChargeStandby
    {
        get { return chargeStandby; }
        set { chargeStandby = value; }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        feverMode = gameObject.GetComponent<FeverMode>();
        changeChargeTrickTheSurfer=gameObject.GetComponent<ChangeChargeTrickTheSurfer>();
        judgeChargeNow=gameObject.GetComponent<JudgeChargeNow>();
        changeChargeTrickTheCharger=gameObject.GetComponent<ChangeChargeTrickTheCharger>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    //�g�ɐG��ăg���b�N���`���[�W
    public void ChargeTrickTouchingWave(float chargeAmount)
    {
        if(chargeStandby)
        {
            player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//�g���b�N���`���[�W
            judgeChargeNow.ResetSinceLastChargedTime();//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
        }
    }

    float ChargeTrickAmount(float chargeAmount)//�`���[�W�����g���b�N��(
    {
        float ret=chargeAmount;//�ʏ펞�̃`���[�W�����g���b�N��
        ret *= feverMode.CurrentChargeTrick_GrowthRate;//�t�B�[�o�[��Ԃ̃`���[�W�{��
        ret *= changeChargeTrickTheCharger.ChargeRate();//���^���̃g���b�N�Q�[�W�̐��ɂ��`���[�W�{��
        ret *= changeChargeTrickTheSurfer.CurrentChargeRate;//�g�ɏ���Ă��鎞�Ԃɂ��`���[�W�{��
        return ret;
    }
}





