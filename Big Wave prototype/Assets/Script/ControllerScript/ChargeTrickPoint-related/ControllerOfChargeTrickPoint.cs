using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�|�C���g�̃`���[�W�̑���
public class ControllerOfChargeTrickPoint : MonoBehaviour
{
    ChargeTrickPoint chargeTrickPoint;
    JudgePauseNow judgePauseNow;

    void Start()
    {
        chargeTrickPoint = GameObject.FindWithTag("Player").GetComponent<ChargeTrickPoint>();
        judgePauseNow=GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        //ChargeStandbyOn();
    }

    //void ChargeStandbyOn()//�g�ɐG��ăg���b�N���`���[�W�ł���悤�ɂ���
    //{
    //    if (judgePauseNow.PauseNow) return;//�|�[�Y���̓`���[�W�ł��Ȃ�

    //    //�X�y�[�X�L�[��{�^���������Ă���Ԃ͔g�ɐG��ă`���[�W���ł���悤�ɂȂ�
    //    if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
    //    {
    //        chargeTrickPoint.ChargeStandby = true;
    //    }
    //    //�����Ă��Ȃ��Ԃ͔g�ɐG��Ă��`���[�W����Ȃ�
    //    else
    //    {
    //        chargeTrickPoint.ChargeStandby = false;
    //    }
    //}

    public void ChargeStandby_On(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        chargeTrickPoint.ChargeStandby = true;
    }

    public void ChargeStandby_Off(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        chargeTrickPoint.ChargeStandby = false;
    }
}
