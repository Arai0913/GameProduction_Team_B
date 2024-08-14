using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
    protected float score=0;//�X�R�A�A�V�[���J�ڂ��钼�O�Ɉȉ���static�ϐ��̂ǂꂩ��score�̒l����

    private static float score_TrickCount=0;//�g���b�N�񐔂̃X�R�A
    private static float score_CriticalTrickCount=0;//�N���e�B�J���񐔂ƃN���e�B�J���A���{�[�i�X�̃X�R�A
    private static float score_TrickCombo = 0;//�g���b�N�̃R���{�̃X�R�A
    private static float score_GameClear = 0;//�Q�[���N���A�{�[�i�X�̃X�R�A
    private static float score_TimeLimit = 0;//�c�莞�Ԃ̃X�R�A
    private static float score_HP = 0;//�c��HP�̃X�R�A

    public float Score_
    {
        get { return score; }
    }



    public static float Score_TrickCount
    {
        get { return score_TrickCount; }
        protected set { score_TrickCount = value;}
    }

    public static float Score_CriticalTrickCount
    {
        get { return score_CriticalTrickCount; }
        protected set { score_CriticalTrickCount = value;}
    }

    public static float Score_TrickCombo
    {
        get { return score_TrickCombo;}
        protected set { score_TrickCombo = value;}
    }

    public static float Score_GameClear
    {
        get { return score_GameClear; }
        protected set { score_GameClear = value;}
    }

    public static float Score_TimeLimit
    {
        get { return score_TimeLimit; }
        protected set { score_TimeLimit = value;}
    }

    public static float Score_HP
    {
        get { return score_HP; }
        protected set { score_HP = value;}
    }
}
