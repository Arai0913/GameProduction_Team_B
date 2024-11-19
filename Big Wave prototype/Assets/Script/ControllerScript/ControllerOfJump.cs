using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�W�����v�̑���
public class ControllerOfJump : MonoBehaviour
{
    Jump jump;
    bool pushing=false;

    public bool Pushing { get { return pushing; }  }

    void Start()
    {
        jump = GameObject.FindWithTag("Player").GetComponent<Jump>();
    }

    public void PrepareJump(InputAction.CallbackContext context)//�����n�߂ɐݒ�
    {
        if (!context.performed) return;

        pushing = true;
    }

    public void Jump(InputAction.CallbackContext context)//�������u�Ԃɐݒ�
    {
        if (!context.performed) return;

        pushing = false;
        jump.JumpTrigger();
    }
}
