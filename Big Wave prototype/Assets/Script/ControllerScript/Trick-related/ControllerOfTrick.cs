using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�̑���
public class ControllerOfTrick : MonoBehaviour
{
    Trick trick;
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;

    void Start()
    {
        trick = GameObject.FindWithTag("Player").GetComponent<Trick>();
        pushedButton_TrickPattern = GameObject.FindWithTag("Player").GetComponent<PushedButton_CurrentTrickPattern>();
    }

    void Update()
    {
        Trick();
    }

    void Trick()//�g���b�N
    {
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//H�L�[��Y�{�^��
        {
            Trick_Process(Button.Y);
        }
        else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("j"))//J�L�[��X�{�^��
        {
            Trick_Process(Button.X);
        }
        else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("k"))//K�L�[��B�{�^��
        {
            Trick_Process(Button.B);
        }
        else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("l"))//L�L�[��A�{�^��
        {
            Trick_Process(Button.A);
        }

        //����(���R)�̃R���g���[���[�p
        //if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//H�L�[��Y�{�^��
        //{
        //    Trick_Process(Button.Y);
        //}
        //else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^��
        //{
        //    Trick_Process(Button.X);
        //}
        //else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^��
        //{
        //    Trick_Process(Button.B);
        //}
        //else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("l"))//L�L�[��A�{�^��
        //{
        //     Trick_Process(Button.A);
        //}
    }

    void Trick_Process(Button button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//�����ꂽ�{�^���̎�ނ�ݒ�
        trick.TrickTrigger();//�g���b�N
    }
}
