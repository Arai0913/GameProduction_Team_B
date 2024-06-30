using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayChargeTrickEffect : MonoBehaviour
{
    [Header("�`���[�W�p�̗��G�t�F�N�g")]
    [SerializeField] GameObject chargeSpark;//�`���[�W�p�̗��G�t�F�N�g
    JudgeChargeNow judgeChargeNow;

    void Start()
    {
        judgeChargeNow = GetComponent<JudgeChargeNow>();
        chargeSpark.SetActive(false);
    }

    void Update()
    {
        DisplayChargeSpark();//�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��
    }

    void DisplayChargeSpark()//�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��
    {
        if (judgeChargeNow.ChargeNow())
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
