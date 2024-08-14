using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
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
            //�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0f, 0f);
            }
            SceneManager.LoadScene("GameoverScene");//�Q�[���I�[�o�[�V�[���Ɉڍs
        }
    }

    void DeadEnemy()//�v���C���[���S���A�Q�[���N���A
    {
        if(enemy.Hp<=0)//�G�����񂾂�
        {
            //�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0f, 0f);
            }
            //�X�R�A�Z�o
            SceneManager.LoadScene("ClearScene");//�N���A�V�[���Ɉڍs
        }
    }

    void TimeUp()//���Ԑ؂ꎞ�A�Q�[���I�[�o�[
    {
        if(TimeLimit.RemainingTime<=0)//���Ԑ؂�ɂȂ�����
        {
            SceneManager.LoadScene("GameoverScene");//�Q�[���I�[�o�[�V�[���Ɉڍs
        }
    }
}
