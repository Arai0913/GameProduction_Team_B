using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�C���v�b�g�V�X�e���w�K�p���\�b�h
public class TestInput : MonoBehaviour
{
    bool isPressed=false;
    public void InputNothing()
    {
        Debug.Log("���ɂ��ݒ肳��Ă��Ȃ�");
    }

    public void InputPerform(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Debug.Log("�ėp");
    }

    public void InputEveryFrameTrue(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        isPressed = true;
    }

    public void InputEveryFrameFalse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        isPressed = false;
    }

    void Update()
    {
        if(isPressed) Debug.Log("���t���[���Ă�ł܂�");
    }
}
