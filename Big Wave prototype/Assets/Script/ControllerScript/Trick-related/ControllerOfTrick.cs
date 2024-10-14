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
    JudgePauseNow judgePauseNow;

    void Start()
    {
        trick = GameObject.FindWithTag("Player").GetComponent<Trick>();
        pushedButton_TrickPattern = GameObject.FindWithTag("Player").GetComponent<PushedButton_CurrentTrickPattern>();
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        //Trick();
    }

    //void Trick()//�g���b�N
    //{
    //    if (judgePauseNow.PauseNow) return;

    //    if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//H�L�[��Y�{�^��
    //    {
    //        Trick_Process(Button.Y);
    //    }
    //    else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("j"))//J�L�[��X�{�^��
    //    {
    //        Trick_Process(Button.X);
    //    }
    //    else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("k"))//K�L�[��B�{�^��
    //    {
    //        Trick_Process(Button.B);
    //    }
    //    else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("l"))//L�L�[��A�{�^��
    //    {
    //        Trick_Process(Button.A);
    //    }

    //    //����(���R)�̃R���g���[���[�p
    //    //if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//H�L�[��Y�{�^��
    //    //{
    //    //    Trick_Process(Button.Y);
    //    //}
    //    //else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^��
    //    //{
    //    //    Trick_Process(Button.X);
    //    //}
    //    //else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^��
    //    //{
    //    //    Trick_Process(Button.B);
    //    //}
    //    //else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("l"))//L�L�[��A�{�^��
    //    //{
    //    //     Trick_Process(Button.A);
    //    //}
    //}

    void Trick_Process(TrickButton button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//�����ꂽ�{�^���̎�ނ�ݒ�
        trick.TrickTrigger();//�g���b�N
    }

    public void Trick_Y(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.Y);
    }

    public void Trick_X(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.X);
    }

    public void Trick_B(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.B);
    }

    public void Trick_A(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.A);
    }
}
