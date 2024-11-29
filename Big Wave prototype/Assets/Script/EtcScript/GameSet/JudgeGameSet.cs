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
    [Header("�Q�[���N���A�̉��o")]
    [SerializeField] GameClearEffect gameClearEffect;//�Q�[���N���A�̉��o
    [Header("�Q�[���I�[�o�[�̉��o")]
    [SerializeField] GameOverEffect gameOverEffect;//�Q�[���I�[�o�[�̉��o
    [Header("�v���C���[��HP")]
    [SerializeField] HP player_Hp;//�v���C���[��HP
    [Header("�G��HP")]
    [SerializeField] HP enemy_Hp;//�G��HP
    [Header("����")]
    [SerializeField] TimeLimit timeLimit;

    // Update is called once per frame
    void Update()
    {
        JudgeClear();
        JudgeGameOver();
    }

    void JudgeClear()
    {
        if (enemy_Hp.Hp <= 0)//�G�����񂾂�
        {
            GameSetProcess(true);
        }
    }

    void JudgeGameOver()
    {
        if (player_Hp.Hp <= 0|| timeLimit.RemainingTime <= 0)//�v���C���[�����񂾂�܂��͎��Ԑ؂�ɂȂ�����
        {
            GameSetProcess(false);
        }
    }

    void GameSetProcess(bool gameClear)//�Q�[���I�����V�[���Ɉڍs���钼�O�ɍs������
    {
        GameSetCommonAction.Invoke();
        GameSetAction.Invoke(gameClear);

        //�Q�[���I�����o
        if(gameClear)//�Q�[���N���A��
        {
            gameClearEffect.Trigger();
        }
        else//�Q�[���I�[�o�[��
        {
            gameOverEffect.Trigger();
        }
    }
}
