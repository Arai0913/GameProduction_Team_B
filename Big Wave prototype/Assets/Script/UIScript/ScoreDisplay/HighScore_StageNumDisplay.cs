using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�쐬��:���R
//�w��X�e�[�WID�̃n�C�X�R�A���e�L�X�g�ɏo��
public class HighScore_StageNumDisplay : MonoBehaviour
{
    [Header("�n�C�X�R�A���ɕ\������e�L�X�g")]
    [SerializeField] TMP_Text _highScoreText;

    public void Display(int stageID)
    {
        float highScore= SaveData.GetHighScore(stageID);

        _highScoreText.text=highScore.ToString("00000");
    }
}
