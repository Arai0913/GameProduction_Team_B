using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Total : Score
{
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score += Score_TrickCount._Score_TrickCount;//���v�X�R�A�Ƀg���b�N�����X�R�A�����Z
        score += Score_CriticalTrickCount._Score_CriticalTrickCount;//���v�X�R�A�Ƀg���b�N�{�^���w�萬���{�[�i�X�����Z
        score += Score_TrickCombo._Score_TrickCombo;//���v�X�R�A�Ƀg���b�N�R���{�{�[�i�X�����Z
        score += Score_GameClear._Score_GameClear;//���v�X�R�A�ɃQ�[���N���A�{�[�i�X�����Z
        score += Score_TimeLimit._Score_TimeLimit;//���v�X�R�A�ɐ������ԃ{�[�i�X�����Z
        score += Score_HP._Score_HP;//���v�X�R�A�Ɏc��HP�{�[�i�X�����Z
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
