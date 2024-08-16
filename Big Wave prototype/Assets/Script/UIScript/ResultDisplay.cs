using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
class ScoreTypeDisplay
{
    [Header("�\������X�R�A�̎��")]
    [SerializeField] ScoreType scoreType;//�\������X�R�A�̎��
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text score_UI;//�\��������e�L�X�g
    private float scoreValue=0;//�\������X�R�A�̒l

    enum ScoreType//�\������X�R�A�̎��
    {
        trickCount,//�g���b�N�񐔃X�R�A
        criticalTrickCount,//�N���e�B�J���g���b�N�{�[�i�X
        trickCombo,//�g���b�N�R���{�{�[�i�X
        gameClear,//�Q�[���N���A�{�[�i�X
        timeLimit,//�c�莞�ԃ{�[�i�X
        hp,//�c��HP�{�[�i�X
        total//�X�R�A���v�A�����enum�^�̍Ō�ɒu��
    }

    internal void ScoreValueSet()//�\������X�R�A�̒l��ݒ�
    {
        //�\������X�R�A�̎�ނɂ���ĕ\������X�R�A�̒l��ݒ�
        //�X�R�A���v�̏ꍇscoreValue(�\������X�R�A�̒l)�ɑS�Ă̎�ނ̃X�R�A�����Z����
       for(int i=0; i< Enum.GetValues(typeof(ScoreType)).Length-1; i++)
       {
            if(scoreType==(ScoreType)i||scoreType==ScoreType.total)
            {
                scoreValue += ScoreTypeValue((ScoreType)i);//�w��̃X�R�A�̎�ނ̃X�R�A�ʂ����Z

                if(scoreType != ScoreType.total)//�X�R�A���v�ł͂Ȃ��Ȃ炱���ŏ����͏I���A�X�R�A���v�Ȃ�S�Ă̎�ނ̃X�R�A�𑫂����߂ɏ������Ō�܂ő���
                {
                    break;
                }
            }
       }
    }

    float ScoreTypeValue(ScoreType type)//�X�R�A�̎�ނ��w�肷�邱�Ƃł��ꂼ��̃X�R�A���Ԃ��Ă���
    {
        switch(type)
        {
            case ScoreType.trickCount: return Score_TrickCount.ScoreTrickCount;//�g���b�N�񐔃{�[�i�X�̃X�R�A��Ԃ�
            case ScoreType.criticalTrickCount: return Score_CriticalTrickCount.ScoreCriticalTrickCount;//�N���e�B�J���g���b�N�{�[�i�X�̃X�R�A��Ԃ�
            case ScoreType.trickCombo: return Score_TrickCombo.ScoreTrickCombo;//�g���b�N�R���{�{�[�i�X�̃X�R�A��Ԃ�
            case ScoreType.gameClear: return Score_GameClear.ScoreGameClear;//�Q�[���N���A�{�[�i�X�̃X�R�A��Ԃ�
            case ScoreType.timeLimit: return Score_TimeLimit.ScoreTimeLimit;//�c�莞�ԃ{�[�i�X�̃X�R�A��Ԃ�
            case ScoreType.hp: return Score_HP.ScoreHP;//�c��HP�{�[�i�X�̃X�R�A��Ԃ�
        }
        return 0;
    }

    internal void Display()//�X�R�A�̕\��
    {
        score_UI.text = scoreValue.ToString("0");
    }
}

public class ResultDisplay : MonoBehaviour
{

    [SerializeField] ScoreTypeDisplay[] scoreTypeDisplays;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<scoreTypeDisplays.Length ;i++)
        {
            scoreTypeDisplays[i].ScoreValueSet();
            scoreTypeDisplays[i].Display();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
