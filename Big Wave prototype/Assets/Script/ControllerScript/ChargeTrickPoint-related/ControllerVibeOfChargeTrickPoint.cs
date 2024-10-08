using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�|�C���g�̃`���[�W�̑��쎞�̃o�C�u
public class ControllerVibeOfChargeTrickPoint : MonoBehaviour
{
    [Header("�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���")]
    [Range(0, 1)]
    [SerializeField] float vibrationSpeed = 1f;//�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���
    JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        judgeChargeTrickPointNow = GameObject.FindWithTag("Player").GetComponent<JudgeChargeTrickPointNow>();
    }

    // Update is called once per frame
    void Update()
    {
        VibrateController();
    }

    void VibrateController()//�`���[�W���Ă���ԃR���g���[�����U��
    {
        if (gamepad != null)
        {
            if (judgeChargeTrickPointNow.ChargeNow())//�`���[�W��
            {
                gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//�o�C�u������
            }
            else//�`���[�W���Ă��Ȃ���
            {
                gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
            }
        }
    }
}