using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    [Header("�R���g���[���̃o�C�u���~�߂邽��")]
    [SerializeField] ControlVibe controlVibe;
    [Header("�X�R�A���f����R���|�[�l���g")]
    [SerializeField] ScoreGameScene_GameClear score_GameClear;
    [SerializeField] ScoreGameScene_HP score_HP;
    [SerializeField] ScoreGameScene_TimeLimit score_TimeLimit;
    [SerializeField] ScoreGameScene_ComboMax score_ComboMax;
    [SerializeField] ScoreGameScene_ChargeTime score_ChargeTime;
    [SerializeField] ScoreGameScene_TrickCombo score_TrickCombo;
    HP player_Hp;
    HP enemy_Hp;
    // Start is called before the first frame update
    void Start()
    {
        player_Hp= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
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
        if(player_Hp.Hp<=0)//�v���C���[�����񂾂�
        {
            GameOverProcess();
        }
    }

    void DeadEnemy()//�v���C���[���S���A�Q�[���N���A
    {
        if(enemy_Hp.Hp<=0)//�G�����񂾂�
        {
            ClearProcess();
        }
    }

    void TimeUp()//���Ԑ؂ꎞ�A�Q�[���I�[�o�[
    {
        if(TimeLimit.RemainingTime<=0)//���Ԑ؂�ɂȂ�����
        {
            GameOverProcess();
        }
    }

    void GameOverProcess()//�Q�[���I�[�o�[�V�[���Ɉڍs���鎞�̏���
    {
        GameSetProcess(false);
        SceneManager.LoadScene("GameoverScene");//�Q�[���I�[�o�[�V�[���Ɉڍs
    }

    void ClearProcess()//�N���A�V�[���Ɉڍs���鎞�̏���
    {
        GameSetProcess(true);
        SceneManager.LoadScene("ClearScene");//�N���A�V�[���Ɉڍs
    }

    void GameSetProcess(bool gameClear)//�Q�[���I�����V�[���Ɉڍs���钼�O�ɍs������
    {
        //�R���g���[���̃o�C�u���~�߂�
        controlVibe.Vibe();
        //�X�R�A���f
        score_GameClear.Reflect(gameClear);
        score_HP.Reflect(gameClear);
        score_TimeLimit.Reflect(gameClear);
        score_ComboMax.Refelect();
        score_ChargeTime.Reflect();
        score_TrickCombo.Reflect();

        if(gameClear)//�N���A��
        {

        }
        else//�Q�[���I�[�o�[��
        {

        }
    }
}
