using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̎c��HP�X�R�A�̌v���E����
public class ScoreGameScene_HP : MonoBehaviour
{
    [Header("�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��")]
    [SerializeField] float m_scorePerOnePercent;//�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��
    [Header("�v���C���[��HP")]
    [SerializeField] HP player_HP;//�v���C���[��HP
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_HP score_HP;//�X�R�A���f
    [Header("�Q�[���I���𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameSet judgeGameSet;
    const float ratioToPercent = 100;//�������灓�ɕϊ�����W��
    const float hpRatio_GameOver = 0;//�Q�[���I�[�o�[���c��̗͂̊����������I��0�Ƃ���

    private void Start()
    {
        judgeGameSet.GameSetAction += Reflect;
    }

    public void Reflect(bool gameClear)//�X�R�A���f
    {
        float hpRatio = gameClear ? (player_HP.Hp / player_HP.HpMax) : hpRatio_GameOver;//�v���C���[��HP�̊���
        float hpPercent = hpRatio * ratioToPercent;//�������p�[�Z���g�ɒ���������

        float score= hpPercent * m_scorePerOnePercent;//�X�R�A�̌v�Z��

        score_HP.Rewrite(score, hpPercent, m_scorePerOnePercent);
    }
}
