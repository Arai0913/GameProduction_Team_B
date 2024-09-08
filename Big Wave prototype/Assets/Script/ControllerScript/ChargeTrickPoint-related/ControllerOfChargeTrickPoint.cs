using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�|�C���g�̃`���[�W�̑���
public class ControllerOfChargeTrickPoint : MonoBehaviour
{
    ChargeTrickPoint chargeTrickPoint;

    void Start()
    {
        chargeTrickPoint = GameObject.FindWithTag("Player").GetComponent<ChargeTrickPoint>();
    }

    void Update()
    {
        ChargeStandbyOn();
    }

    void ChargeStandbyOn()//�g�ɐG��ăg���b�N���`���[�W�ł���悤�ɂ���
    {
        //�X�y�[�X�L�[��{�^���������Ă���Ԃ͔g�ɐG��ă`���[�W���ł���悤�ɂȂ�
        if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
        {
            chargeTrickPoint.ChargeStandby = true;
        }
        //�����Ă��Ȃ��Ԃ͔g�ɐG��Ă��`���[�W����Ȃ�
        else
        {
            chargeTrickPoint.ChargeStandby = false;
        }
    }

    
}
