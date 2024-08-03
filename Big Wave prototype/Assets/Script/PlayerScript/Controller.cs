using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//���쐬��:���R

public class Controller : MonoBehaviour
{
    //[Header("�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���")]
    //[SerializeField] float chargeTrick_VibrationSpeed=0.35f;//�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���
    [SerializeField] ControllerOfJump controllerOfJump;//�W�����v�֌W�̃R���g���[���[�̏����A(��)[SerializeField]�����Ȃ��ƃG���[�N�����Ⴄ
    [Header("�g���b�N�֌W")]
    [SerializeField] ControllerOfTrick controllerOfTrick;//�g���b�N�֌W�̃R���g���[���̏���
    [Header("�g���b�N�̃`���[�W�֌W")]
    [SerializeField] ControllerOfChargeTrick controllerOfChargeTrick;//�g���b�N�̃`���[�W�֌W�̃R���g���[���̏���

    JumpControl jumpControl;
    ChargeTrick chargeTrick;
    TrickControl trickControl;
    JudgeChargeNow judgeChargeNow;

    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrick = gameObject.GetComponent<ChargeTrick>();
        trickControl= gameObject.GetComponent<TrickControl>();
        judgeChargeNow= gameObject.GetComponent<JudgeChargeNow>();

        controllerOfJump.Start(jumpControl);
        controllerOfTrick.Start(trickControl, gamepad);
        controllerOfChargeTrick.Start(judgeChargeNow, chargeTrick, gamepad);
    }

    // Update is called once per frame
    void Update()
    {
        controllerOfJump.Update();
        controllerOfTrick.Update();
        controllerOfChargeTrick.Update();
    }

    public void Vibe_Trick()//�g���b�N�̃o�C�u
    {
        controllerOfTrick.Vibe();
    }

    void OnTriggerEnter(Collider other)
    {
        controllerOfChargeTrick.OnTriggerEnter(other);
    }
}

[System.Serializable]
class ControllerOfJump//�W�����v�֌W�̃R���g���[���[�̏���
{
    JumpControl jumpControl;

    internal void Start(JumpControl j)
    {
        jumpControl = j;
    }

    internal void Update()//�W�����v
    {
        //�X�y�[�X�L�[��LB�{�^����RB�{�^���ŃW�����v
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jumpControl.Jump();
        }
    }
}

[System.Serializable]
class ControllerOfTrick//�g���b�N�֌W�̃R���g���[���[�̏���
{
    [Header("�g���b�N�����߂����̃o�C�u�̑���")]
    [Range(0, 1)]
    [SerializeField] float vibrationSpeed = 1f;//�g���b�N�����߂����̃o�C�u�̑���
    [Header("�g���b�N�����߂����̐U���̎���")]
    [SerializeField] float vibeTime = 0.2f;//�g���b�N�����߂����̐U���̎���
    private float remainingVibeTime = 0f;//�g���b�N�̐U���̎c�莞��(�����p)

    TrickControl trickControl;
    Gamepad gamepad;

    internal void Start(TrickControl t,Gamepad g)
    {
        trickControl = t;
        gamepad = g;
    }

    internal void Update()
    {
        Trick();

        VibrateController();
    }

    void Trick()//�g���b�N
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^�������������o�t
        {
            trickControl.Trick_X();
        }

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^�������������U��
        {
            trickControl.Trick_Y();
        }

        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("l"))//L�L�[��A�{�^��������������
        {
            trickControl.Trick_B();
        }
        if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("h"))
        {
            trickControl.Trick_A();
        }
    }

    void VibrateController()//�g���b�N���R���g���[���[���o�C�u����
    {
        remainingVibeTime -= Time.deltaTime;

        if(gamepad!=null)
        {
            if (remainingVibeTime > 0)
            {
                gamepad.SetMotorSpeeds(vibrationSpeed,vibrationSpeed);//�o�C�u������
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
            }
        }
    }

    internal void Vibe()//�g���b�N���Ƀo�C�u���Ăق����Ƃ�������Ă�
    {
        remainingVibeTime = vibeTime;
    }
}

[System.Serializable]
class ControllerOfChargeTrick//�g���b�N�̃`���[�W�֌W�̏���
{
    [Header("�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���")]
    [Range(0,1)]
    [SerializeField] float vibrationSpeed = 1f;//�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���

    JudgeChargeNow judgeChargeNow;
    ChargeTrick chargeTrick;
    Gamepad gamepad;

    internal void Start(JudgeChargeNow j,ChargeTrick c,Gamepad g)
    {
        judgeChargeNow = j;
        chargeTrick = c;
        gamepad = g;
    }

    internal void Update()
    {
        VibrateController();
    }

    void VibrateController()//�`���[�W���Ă���ԃR���g���[�����U��
    {
        if (gamepad != null)
        {
            if (judgeChargeNow.ChargeNow())
            {
                gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//�o�C�u������
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
            }
        }
    }

    internal void OnTriggerEnter(Collider wave)
    {
        if (wave.CompareTag("InsideWave") || wave.CompareTag("OutsideWave"))//�g�ɐG��Ă���ԏ���ăg���b�N���`���[�W
        {
            //�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W
            if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
            {
                chargeTrick.ChargeTrickTouchingWave(wave);
            }
        }
    }
}
