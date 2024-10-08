using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

//�쐬��:���R
//�g���b�N�̃`���[�W
public class ChargeTrickPoint : MonoBehaviour
{
    ChangeChargeRateTheChargers changeChargeRateTheChargers;
    FeverMode feverMode;
    TrickPoint player_TrickPoint;
    JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    ChangeChargeRateTheSurfer changeChargeRateTheSurfer;
    private bool chargeStandby = false;//���ꂪtrue�ɂȂ��Ă��鎞���g�ɐG��Ă��鎞�̂݃g���b�N���`���[�W�ł���

    /////private(�ʃN���X�͎g�p�s��)�̃��\�b�h/////
    void Start()
    {
        changeChargeRateTheChargers=GetComponent<ChangeChargeRateTheChargers>();
        feverMode = GetComponent<FeverMode>();
        player_TrickPoint=GetComponent<TrickPoint>();
        judgeChargeTrickPointNow=GetComponent<JudgeChargeTrickPointNow>();
        changeChargeRateTheSurfer=GetComponent<ChangeChargeRateTheSurfer>();
    }

    float ChargeTrickAmount(float chargeAmount)//�`���[�W�����g���b�N��
    {
        float ret = chargeAmount;//�ʏ펞�̃`���[�W�����g���b�N��
        ret *= feverMode.CurrentChargeTrick_GrowthRate;//�t�B�[�o�[��Ԃ̃`���[�W�{��
        ret *= changeChargeRateTheChargers.ChargeRate(player_TrickPoint.MaxCount,player_TrickPoint.TrickGaugeNum);//���^���̃g���b�N�Q�[�W�̐��ɂ��`���[�W�{��
        ret *= changeChargeRateTheSurfer.ChargeRate();//�g�ɏ���Ă��鎞�Ԃɂ��`���[�W�{��
        return ret;
    }


    /////public(�ʃN���X���g�p�\)�̃��\�b�h/////

    public bool ChargeStandby
    {
        get { return chargeStandby; }
        set { chargeStandby = value; }
    }

   
    public void Charge(float chargeAmount)//�g���b�N�̃`���[�W
    {
        if (chargeStandby)
        {
            player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//�g���b�N���`���[�W
            judgeChargeTrickPointNow.ResetSinceLastChargedTime();//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
        }
    }
}