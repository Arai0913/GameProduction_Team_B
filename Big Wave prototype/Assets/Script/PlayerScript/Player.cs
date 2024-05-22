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
    public Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//�X�e�[�^�X������
        trick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LimitHP();//�̗͂����E�˔j���Ȃ��悤��

        LimitTRICK();//�g���b�N�����E�˔j���Ȃ��悤��
    }

    public void Damage(float a)//�v���C���[�Ƀ_���[�W��^����(a�̒l���^����)
    {
        hp -= a;
    }
   
    public void ChargeTRICK(float a)//�g���b�N�𑝂₷
    {
        trick+=a;
    }

    public void ConsumeTRICK(float a)//�g���b�N��0�ɂ���
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
    public void AttackVibration(float a)//�U���̋����ɍ��킹�ĐU������������
    {
        if (gamepad != null)
        { 

            gamepad.SetMotorSpeeds(a,a);
        }
    }
    public void StopVibration()
    {
        if (gamepad != null)
        { 

            gamepad.SetMotorSpeeds(0,0);
        }
    }



}
