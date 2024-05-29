using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float hp = 100;//���݂̗̑�
    public float hpMax = 100;//�ő�̗�
    public float trick = 0;//���݂̃g���b�N�Q�[�W
    public float trickMax = 50;//�ő�g���b�N�Q�[�W
    SceneControlManager sceneControlManager;
    public AudioClip sound1;//�U���ɗp������ʉ��B���P�̗]�n����B
   public AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//�X�e�[�^�X������
        trick = 0;
        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitHP();//�̗͂����E�˔j���Ȃ��悤��

        LimitTRICK();//�g���b�N�����E�˔j���Ȃ��悤��

        Dead();//�G�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    }

    public void Damage(float a)//�v���C���[�Ƀ_���[�W��^����(a�̒l���^����)
    {
        hp -= a;
    }
   
    public void ChargeTRICK(float a)//�g���b�N�𑝂₷
    {
        trick+=a;
    }

    public void ConsumeTRICK(float a)//�g���b�N��a�������
    {
        trick -= a;
    }

    void LimitHP()//�̗͂����E�˔j���Ȃ��悤��
    {
        if (hp > hpMax)
        {
            hp = hpMax;
        }
    }

    void LimitTRICK()//�g���b�N�����E�˔j���Ȃ��悤��
    {
        if (trick > trickMax)
        {
            trick = trickMax;
        }
    }

    void Dead()//�G�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    {
        if(hp<=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
    //public void AttackVibration(float a)//�U���̋����ɍ��킹�ĐU������������
    //{
    //    if (gamepad != null)
    //    { 

    //        gamepad.SetMotorSpeeds(a,a);
    //    }
    //}
    //public void StopVibration()
    //{
    //    if (gamepad != null)
    //    { 

    //        gamepad.SetMotorSpeeds(0,0);
    //    }
    //}



}
