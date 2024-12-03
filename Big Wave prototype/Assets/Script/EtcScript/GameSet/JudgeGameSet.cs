using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class JudgeGameSet : MonoBehaviour
{
    public event Action<bool> GameSetAction;//true�Ȃ�Q�[���N���A�Afalse�Ȃ�Q�[���I�[�o�[
    public event Action GameSetCommonAction;//�Q�[���I�����N���A�ł��Q�[���I�[�o�[�ł��ǂ���ł���鋤�ʃC�x���g
    [Header("�G��|�������̉��o")]
    [SerializeField] DefeatEnemyEffect defeatEnemyEffect;//�G��|�������̉��o
    [Header("���S���̉��o")]
    [SerializeField] DeadEffect deadEffect;//���S���̉��o
    [Header("�^�C���A�b�v���̉��o")]
    [SerializeField] TimeUpEffect timeUpEffect;//�^�C���A�b�v���̃G�t�F�N�g
    [Header("�v���C���[��HP")]
    [SerializeField] HP player_Hp;//�v���C���[��HP
    [Header("�G��HP")]
    [SerializeField] HP enemy_Hp;//�G��HP
    [Header("����")]
    [SerializeField] TimeLimit timeLimit;
    bool gameSet = false;

    public bool GameSet { get { return gameSet; } }

    void Update()
    {
        JudgeClear();
        JudgeGameOver();
    }

    void JudgeClear()
    {
        if (enemy_Hp.Hp <= 0&&!gameSet)//�G��|������
        {
            GameSetProcess(true);

            defeatEnemyEffect.Trigger();
        }
    }

    void JudgeGameOver()
    {
        bool dead = player_Hp.Hp <= 0;//�v���C���[������
        bool timeUp = timeLimit.RemainingTime <= 0;//���Ԑ؂�ɂȂ���

        if ((dead||timeUp) && !gameSet)//�v���C���[�����񂾂�܂��͎��Ԑ؂�ɂȂ�����
        {
            GameSetProcess(false);

            if(dead)//�v���C���[���S��
            {
                deadEffect.Trigger();
            }
            else if(timeUp)//���Ԑ؂ꎞ
            {
                timeUpEffect.Trigger();
            }
        }
    }

    void GameSetProcess(bool gameClear)//�Q�[���I�����V�[���Ɉڍs���钼�O�ɍs������
    {
        GameSetCommonAction.Invoke();
        GameSetAction.Invoke(gameClear);
        gameSet = true;
    }
}
