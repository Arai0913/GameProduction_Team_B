using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeChargeNow : MonoBehaviour
{
    [Header("�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���")]
    [SerializeField] float chargedBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    private float sinceLastChargedTime = 0.1f;//�Ō�Ƀ`���[�W����Ă���̎���

    // Start is called before the first frame update
    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;
    }

    // Update is called once per frame
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
