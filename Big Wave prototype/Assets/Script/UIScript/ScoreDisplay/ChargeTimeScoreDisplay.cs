using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�Q�[�����̃`���[�W���Ԃ̃X�R�A��\��
public class ChargeTimeScoreDisplay : MonoBehaviour
{
    [Header("�X�R�A�\�����镶��")]
    [SerializeField] TMP_Text m_scoreText;
    [Header("�`���[�W���Ԃ̃X�R�A���v������R���|�[�l���g")]
    [SerializeField] ScoreGameScene_ChargeTime score_ChargeTime;

    void Update()
    {
        Display();
    }

    void Display()//�\������
    {
        m_scoreText.text=score_ChargeTime.Score.ToString("0");
    }
}
