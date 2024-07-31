using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [Header("�ő�̗�")]
    [SerializeField] float hpMax = 500;//�ő�̗�
    private float hp = 500;//���݂̗̑�
    Controller controller;
    ManagementOfScore managementOfScore;

    public float Hp
    {
        get { return hp; }
        set 
        {
            hp = value;
            hp = Mathf.Clamp(hp, 0f, hpMax);//�̗͂����E�˔j���Ȃ��悤��
            Dead();//���S���̏���
        }
    }

    public float HpMax
    {
        get { return hpMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hp�̏�����
        hp = hpMax;

        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();

        managementOfScore= GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //��ŕʂ̃X�N���v�g�Ɉڂ�����
    void Dead()//���S���̏���
    {
        if (hp <= 0)
        {
            controller.StopVibe_Trick();//�Q�[���I�����R���g���[���[�̐U�����~�߂鉞�}���u

            if (this.gameObject.tag=="Player")//�v���C���[�Ȃ�Q�[���I�[�o�[�V�[���Ɉڍs
            {
                SceneManager.LoadScene("GameoverScene");
            }
            else if(this.gameObject.tag == "Enemy")//�G�Ȃ�N���A�V�[���Ɉڍs
            {
                managementOfScore.CalculateScore();
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
}
