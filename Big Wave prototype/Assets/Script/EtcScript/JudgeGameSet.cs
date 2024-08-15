using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    [Header("�g���b�N�񐔂̃X�R�A")]
    [SerializeField] Score_TrickCount score_TrickCount;
    [Header("�g���b�N�{�^���w�萬���̃X�R�A")]
    [SerializeField] Score_CriticalTrickCount score_CriticalTrickCount;
    [Header("�g���b�N�R���{�̃X�R�A")]
    [SerializeField] Score_TrickCombo score_TrickCombo;
    [Header("�Q�[���N���A�̃X�R�A")]
    [SerializeField] Score_GameClear score_GameClear;
    [Header("�������Ԃ̃X�R�A")]
    [SerializeField] Score_TimeLimit score_TimeLimit;
    [Header("�c��HP�̃X�R�A")]
    [SerializeField] Score_HP score_HP;
    HP player;
    HP enemy;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();

        DeadPlayer();

        TimeUp();
    }

    void DeadPlayer()//�v���C���[���S���A�Q�[���I�[�o�[
    {
        if(player.Hp<=0)//�v���C���[�����񂾂�
        {
            GameOver();
        }
    }

    void DeadEnemy()//�v���C���[���S���A�Q�[���N���A
    {
        if(enemy.Hp<=0)//�G�����񂾂�
        {
            Clear();
        }
    }

    void TimeUp()//���Ԑ؂ꎞ�A�Q�[���I�[�o�[
    {
        if(TimeLimit.RemainingTime<=0)//���Ԑ؂�ɂȂ�����
        {
            GameOver();
        }
    }

    void GameOver()//�Q�[���I�[�o�[�V�[���Ɉڍs���鎞�̏���
    {
        GameSetProcess(false);
        SceneManager.LoadScene("GameoverScene");//�Q�[���I�[�o�[�V�[���Ɉڍs
    }

    void Clear()//�N���A�V�[���Ɉڍs���鎞�̏���
    {
        GameSetProcess(true);
        SceneManager.LoadScene("ClearScene");//�N���A�V�[���Ɉڍs
    }

    void GameSetProcess(bool gameClear)//�Q�[���I�����̏���
    {
        StopControllerVibe();//�R���g���[���̐U�����~�߂�
        //�X�R�A���f
        score_TrickCount.ReflectScore();
        score_CriticalTrickCount.ReflectScore();
        score_TrickCombo.ReflectScore();
        score_GameClear.ReflectScore(gameClear);
        score_TimeLimit.ReflectScore(gameClear);
        score_HP.ReflectScore(gameClear);
    }

    void StopControllerVibe()//�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}
