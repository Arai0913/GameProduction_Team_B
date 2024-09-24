using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//���݃`���[�W���Ă��邩�̔���
public class JudgeChargeTrickPointNow : MonoBehaviour
{
    [Header("�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���")]
    [SerializeField] float chargedBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    [Header("�`���[�W�J�n�u�Ԃ̏���")]
    [SerializeField] MomentEvent startChargeEvents;//�`���[�W�J�n�u�Ԃ̏���
    [Header("�`���[�W�I���u�Ԃ̏���")]
    [SerializeField] MomentEvent endChargeEvents;//�`���[�W�I���u�Ԃ̏���
    private float sinceLastChargedTime;//�Ō�Ƀ`���[�W����Ă���̎���
    bool chargeNow = false;//���݃`���[�W���Ă��邩
    bool chargeNowBeforeFrame;//�O�̃t���[���̃`���[�W���Ă��邩�̔���

    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;//�����̍Ō�Ƀ`���[�W����Ă���̎��Ԃ��`���[�W�̋��E���Ԃɐݒ�
        chargeNowBeforeFrame = chargeNow;
    }

    void Update()
    {
        UpdateChargeNow();

        startChargeEvents.ActivateMomentEvent(chargeNow,chargeNowBeforeFrame,true);//�O�̃t���[���Ń`���[�W����Ă��Ȃ����������݂̃t���[���Ń`���[�W����Ă����珈�����s��

        endChargeEvents.ActivateMomentEvent(chargeNow, chargeNowBeforeFrame, false);//�O�̃t���[���Ń`���[�W����Ă��������݂̃t���[���Ń`���[�W����Ă��Ȃ������珈�����s��

        chargeNowBeforeFrame = chargeNow;
    }

    //�`���[�W�󋵂̍X�V
    void UpdateChargeNow()
    {
        sinceLastChargedTime += Time.deltaTime;

        if (sinceLastChargedTime < chargedBorderTime)//�Ō�Ƀ`���[�W���Ă���chargeBorderTime(�b)�����Ȃ獡�`���[�W���Ă锻��
        {
            chargeNow = true;
        }
        else
        {
            chargeNow = false;
        }
    }

    public bool ChargeNow()//���`���[�W���Ă��邩
    {
        return chargeNow;
    }

    public void ResetSinceLastChargedTime()//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
    {
        sinceLastChargedTime = 0;
    }
}
