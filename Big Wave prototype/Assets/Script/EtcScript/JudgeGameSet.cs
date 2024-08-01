using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    HP player;
    HP enemy;
    Controller controller;
    ManagementOfScore managementOfScore;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy = GameObject.FindWithTag("Enemy").GetComponent<HP>();

        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();

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
            controller.StopVibe_Trick();//�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
            SceneManager.LoadScene("GameoverScene");//�Q�[���I�[�o�[�V�[���Ɉڍs
        }
    }

    void DeadEnemy()
    {
        if(enemy.Hp<=0)//�G�����񂾂�
        {
            controller.StopVibe_Trick();//�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u
            managementOfScore.CalculateScore();//�X�R�A�Z�o
            SceneManager.LoadScene("ClearScene");//�N���A�V�[���Ɉڍs
        }
    }
}
