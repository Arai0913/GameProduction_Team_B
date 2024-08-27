using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݃`���[�W���Ă��邩�̔���
public class JudgeChargeTrickPointNow : MonoBehaviour
{
    [Header("�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���")]
    [SerializeField] float chargedBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    private float sinceLastChargedTime = 0.1f;//�Ō�Ƀ`���[�W����Ă���̎���

    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;
    }

    void Update()
    {
        sinceLastChargedTime += Time.deltaTime;
    }

    public bool ChargeNow()//���`���[�W���Ă��邩
    {
        if (sinceLastChargedTime < chargedBorderTime)//�Ō�Ƀ`���[�W���Ă���chargeBorderTime(�b)�����Ȃ獡�`���[�W���Ă锻��
        {
            return true;
        }

        return false;
    }

    public void ResetSinceLastChargedTime()//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
    {
        sinceLastChargedTime = 0;
    }
}
