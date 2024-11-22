using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�W�����v�͂�UI�ŕ\��
public class JumpPowerDisplay : MonoBehaviour
{
    [Header("�W�����v�̓Q�[�W")]
    [SerializeField] Image jumpPowerGauge;//�W�����v�̓Q�[�W
    [Header("�W�����v��")]
    [SerializeField] JumpPower jumpPower;

    void Update()
    {
        JumpPowerGauge();
    }

    void JumpPowerGauge()//�W�����v�̓Q�[�W�̏���
    {
        float ratio = jumpPower.Ratio;
        jumpPowerGauge.fillAmount = ratio;
    }
}
