using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̍ő�R���{�񐔃X�R�A�̌v���E����
public class ScoreGameScene_ComboMax : MonoBehaviour
{
    [Header("�R���{1�񂲂Ƃ̃X�R�A")]
    [SerializeField] float m_scorePerCombo;//�R���{1�񂲂Ƃ̃X�R�A
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_ComboMax_ score_ComboMax;//�X�R�A���f
    [Header("�R���{�񐔂𐔂���R���|�[�l���g")]
    [SerializeField] CountTrickCombo countTrickCombo;


    public void Refelect()//�X�R�A���f
    {
        float score = countTrickCombo.ComboCountMax * m_scorePerCombo;//�X�R�A�̌v�Z��

        score_ComboMax.Rewrite(score, countTrickCombo.ComboCountMax, m_scorePerCombo);
    }
}
