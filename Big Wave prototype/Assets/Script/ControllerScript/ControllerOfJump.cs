using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�W�����v�̑���
public class ControllerOfJump : MonoBehaviour
{
    Jump jump;
    void Start()
    {
        jump = GameObject.FindWithTag("Player").GetComponent<Jump>();
    }

    void Update()
    {
        //�X�y�[�X�L�[��LB�{�^����RB�{�^���ŃW�����v
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jump.JumpTrigger();
        }
    }
}
