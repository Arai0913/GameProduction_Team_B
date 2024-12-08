using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//�쐬��:���R
//�n�C�X�R�A���o���牉�o���o��(���݂͕������o������)
public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] SaveHighScore _saveHighScore;
    [Header("�n�C�X�R�A���ɕ\������e�L�X�g")]
    [SerializeField] TMP_Text _highScoreText;

    void Start()
    {
        _highScoreText.enabled = _saveHighScore.Updated;
    }
}
