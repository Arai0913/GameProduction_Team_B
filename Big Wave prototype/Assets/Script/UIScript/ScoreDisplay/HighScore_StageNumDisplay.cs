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
    [Header("�N���A�񐔂�\������e�L�X�g")]
    [SerializeField] TMP_Text _clearCountScoreText;
    [Header("�ő��N���A���Ԃ�\������e�L�X�g")]
    [SerializeField] TMP_Text _highClearTimeText;

    public void Display(int stageID)
    {
        DisplayHighScore(stageID);
        DisplayClearCount(stageID);
    }

    void DisplayHighScore(int stageID)//�n�C�X�R�A�̕\��
    {
        float highScore = SaveData.GetHighScore(stageID);

        _highScoreText.text = highScore.ToString("0");
    }

    void DisplayClearCount(int stageID)//�N���A�񐔂̕\��
    {
        int clearCount=SaveData.GetClearCount(stageID);

        _clearCountScoreText.text = clearCount.ToString("0");
    }

    void DisplayHighClearCount(int stageID)
    {

    }
}
