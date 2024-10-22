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

    void Trick_Process(TrickButton button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//�����ꂽ�{�^���̎�ނ�ݒ�
        trick.TrickTrigger();//�g���b�N
    }

    public void Trick_Y(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.north);
    }

    public void Trick_X(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.west);
    }

    public void Trick_B(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.east);
    }

    public void Trick_A(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.south);
    }
}
