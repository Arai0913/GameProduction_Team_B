using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    HP player;
    HP enemy;
    ManagementOfScore managementOfScore;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy = GameObject.FindWithTag("Enemy").GetComponent<HP>();

        managementOfScore = GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();

        DeadPlayer();
    }

    void DeadPlayer()
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

    void DeadEnemy()
    {
        if(enemy.Hp<=0)//�G�����񂾂�
        {
            //�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0f, 0f);
            }
            managementOfScore.CalculateScore();//�X�R�A�Z�o
            SceneManager.LoadScene("ClearScene");//�N���A�V�[���Ɉڍs
        }
    }
}
