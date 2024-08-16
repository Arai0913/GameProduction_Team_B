using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[System.Serializable]
class ReflectScore
{
    [Header("�Q�[���I�����ɔ��f���������X�R�A")]
    [SerializeField] Score reflectScore;
    [Header("�N���A���̂݃X�R�A�𔽉f�����邩")]
    [SerializeField] bool reflectWhenClear;

    internal void Reflect(bool gameClear)
    {
        if(reflectWhenClear)//�N���A���̂݃X�R�A�𔽉f������ꍇ(�Q�[���I�[�o�[���̓X�R�A��0)
        {
            reflectScore.ReflectScore(gameClear);
        }
        else//�Q�[���I�[�o�[���ł��X�R�A�𔽉f������ꍇ
        {
            reflectScore.ReflectScore();
        }
    }
}

public class JudgeGameSet : MonoBehaviour
{
    [Header("�R���{�񐔂̃X�R�A")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//�R���{�񐔂̃X�R�A
    [Header("�Q�[���I�����ɔ��f���������X�R�A")]
    [SerializeField] ReflectScore[] reflectScores;
    HP player_Hp;
    HP enemy_Hp;
    CountTrickCombo countTrickCombo;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        player_Hp= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();

        countTrickCombo= GameObject.FindWithTag("Player").GetComponent<CountTrickCombo>();
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
            GameOver();
        }
    }

    void DeadEnemy()//�v���C���[���S���A�Q�[���N���A
    {
        if(enemy_Hp.Hp<=0)//�G�����񂾂�
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
        //�Q�[���I�����O�̃R���{�񐔂��X�R�A�ɉ��Z
        score_TrickCombo.AddScore(countTrickCombo.ComboCount);
        //�X�R�A���f
        for(int i = 0; i<reflectScores.Length; i++)
        {
            reflectScores[i].Reflect(gameClear);
        }
    }

    void StopControllerVibe()//�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}
