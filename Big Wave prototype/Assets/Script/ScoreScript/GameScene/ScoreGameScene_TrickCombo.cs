using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̃g���b�N�X�R�A�̌v���E����
//�����ł����R���{�Ƃ͘A���N���e�B�J���񐔂̂���
//�g���b�N�̐������Ōv������d�l�ɕύX
public class ScoreGameScene_TrickCombo : MonoBehaviour
{
    [Header("��{�X�R�A")]
    [SerializeField] float m_defaultScore;//��{�X�R�A
    [Header("������100%�������ꍇ�ɒǉ������X�R�A")]
    [SerializeField] float m_perfectScore;
    [Header("�R���{�ǉ��X�R�A")]
    [SerializeField] float m_addComboScore;//�R���{�ǉ��X�R�A
    [Header("�X�R�A�����ő�R���{��")]
    [SerializeField] int m_maxAddComboCount;//�X�R�A�����ő�R���{��
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//�X�R�A���f
    [Header("�R���{�񐔂𐔂���R���|�[�l���g")]
    [SerializeField] CountTrickCombo countTrickCombo;
    [Header("�Q�[���I���𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameSet judgeGameSet;
  
    private int failedTrick=0;

    private float m_score=0;

    public float Score { get { return m_score; }  }

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }

    public void AddScore()//�X�R�A���Z(�g���b�N���ɌĂ�)
    {
        if(countTrickCombo.ContinueCombo)//�g���b�N������������
        {
            int comboCount = countTrickCombo.ComboCount > m_maxAddComboCount ? m_maxAddComboCount : countTrickCombo.ComboCount;//�R���{��(�ő�R���{�񐔂𒴂��Ă�����ő�R���{�񐔂̒l�ɂ���)
            m_score += m_defaultScore + m_addComboScore*comboCount;//�A���R���{�񐔂ɉ����ăX�R�A�����Z
         
        }
        else //�R���{���r�؂ꂽ��(���ʂ̃g���b�N��������)
        {
            m_score += m_defaultScore;//��{�X�R�A�����Z
            failedTrick++;
        }
    }

    public void Reflect()//�X�R�A���f
    {
        m_score += failedTrick == 0 ? m_perfectScore : m_perfectScore / (failedTrick / countTrickCombo.ComboCount);//100%�łȂ������ꍇ�A�S�g���b�N�����玸�s�̊��������X�R�A�����
        score_TrickCombo.Rewrite(m_score);
    }
}
