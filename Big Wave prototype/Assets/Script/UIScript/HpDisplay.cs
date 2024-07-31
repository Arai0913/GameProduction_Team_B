using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁ�:���R
public class HpDisplay : MonoBehaviour
{
    [Header("��HP�Q�[�W")]
    [SerializeField] GameObject hpGaugeOfPlayer;//HP�Q�[�W
    [Header("��HP��\���������I�u�W�F�N�g")]
    [SerializeField] HP objectDisplayHp;//HP��\���������I�u�W�F�N�g
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpGauge();
    }

    void HpGauge()//HP�Q�[�W�̏���
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGaugeOfPlayer.GetComponent<Image>().fillAmount = hpRatio;
    }
}
