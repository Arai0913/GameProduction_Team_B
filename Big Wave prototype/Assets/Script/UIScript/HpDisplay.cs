using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁ�:���R
public class HpDisplay : MonoBehaviour
{
    [Header("��HP�Q�[�W")]
    [SerializeField] Image hpGauge;//HP�Q�[�W
    [Header("��HP��\���������I�u�W�F�N�g")]
    [SerializeField] HP objectDisplayHp;//HP��\���������I�u�W�F�N�g
    [Header("�ʏ펞�̐F")]
    [SerializeField] Color normalColor;//�ʏ펞�̐F
    [Header("�̗͂����Ȃ����̐F")]
    [SerializeField] Color pinchColor;//�̗͂����Ȃ����̐F
    [Header("�̗̓Q�[�W�̐F���ς�鋫�E�l(����)")]
    [Range(0f, 1f)]
    [SerializeField] float borderRatio;//�̗̓Q�[�W�̐F���ς�鋫�E�l(%)

    void Update()
    {
        HpGauge();
    }

    void HpGauge()//HP�Q�[�W�̏���
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGauge.fillAmount = hpRatio;
        //�Q�[�W�̐F�̕ύX
        hpGauge.color = (hpRatio <= borderRatio) ? pinchColor : normalColor;
    }
}
