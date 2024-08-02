using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//���쐬��:���R

public class Controller : MonoBehaviour
{
    [Header("�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���")]
    [SerializeField] float chargeTrick_VibrationSpeed=0.35f;//�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���
    [Header("�g���b�N�����߂����̃o�C�u�̑���")]
    [SerializeField] float trick_VibrationSpeed = 0.35f;//�g���b�N�����߂����̃o�C�u�̑���
    [Header("�g���b�N�����߂����̐U���̎���")]
    [SerializeField] float trickVibeTime = 0f;//�g���b�N�����߂����̐U���̎���
    private float remainingTrickVibeTime = 0f;//�g���b�N�̐U���̎c�莞��(�����p)
    [SerializeField] ControllerOfJump controllerOfJump;//�W�����v�֌W�̃R���g���[���[�̏����A(��)[SerializeField]�����Ȃ��ƃG���[�N�����Ⴄ

    JumpControl jumpControl;
    ChargeTrick chargeTrickControl;
    TrickControl trickControl;
    JudgeChargeNow judgeChargeNow;

    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrickControl = gameObject.GetComponent<ChargeTrick>();
        trickControl= gameObject.GetComponent<TrickControl>();
        judgeChargeNow= gameObject.GetComponent<JudgeChargeNow>();

        controllerOfJump.Start(jumpControl);
    }

    // Update is called once per frame
    void Update()
    {
        controllerOfJump.Update();

        Trick();//�g���b�N
        
        VibrateController_Charge();//�`���[�W���Ă���ԃR���g���[�����U��

        VibrateController_Trick();//�g���b�N�������ɃR���g���[�����U��
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InsideWave") || other.CompareTag("OutsideWave"))
        {
            ChargeTrick(other);//�g�ɐG��Ă���ԏ���ăg���b�N���`���[�W
        }
    }

    //�U���֘A
    void Trick()//�U��
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^�������������o�t
        {
            trickControl.Trick_X();
        }

        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^�������������U��
        {
            trickControl.Trick_Y();
        }

        if(Input.GetButtonDown("Fire3") || Input.GetKeyDown("l"))//L�L�[��A�{�^��������������
        {
            trickControl.Trick_B();
        }
        if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("h"))
        {
            trickControl.Trick_A();
        }
    }

    void VibrateController_Trick()//�U�����R���g���[���[���o�C�u����
    {
        remainingTrickVibeTime -= Time.deltaTime;

        if(remainingTrickVibeTime>0)
        {
            Vibration(trick_VibrationSpeed);//�o�C�u������
        }
        else
        {
            StopVibration();//�o�C�u���~�߂�
        }
    }

    public void Vibe_Trick()//�g���b�N���Ƀo�C�u���Ăق����Ƃ�������Ă�
    {
        remainingTrickVibeTime = trickVibeTime;
    }

    //�g���b�N�̃`���[�W�֘A
    void ChargeTrick(Collider wavePrefab)//�g�ɏ���ăg���b�N���`���[�W
    {
        //�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W
        if (Input.GetKey(KeyCode.JoystickButton5)  ||Input.GetKey(KeyCode.JoystickButton4)||  Input.GetKey("space"))
        {
            chargeTrickControl.ChargeTrickTouchingWave(wavePrefab);
        }
    }

    void VibrateController_Charge()//�`���[�W���Ă���ԃR���g���[�����U��
    {
        if (judgeChargeNow.ChargeNow())
        {
            Vibration(chargeTrick_VibrationSpeed);//�o�C�u������
        }
        else
        {
            StopVibration();//�o�C�u���~�߂�
        }
    }


    //�o�C�u�֘A(bool�^�Ńo�C�u�����邩�o�C�u���~�߂邩���f�Atrue->�o�C�u�Afalse->�o�C�u���~�߂�)



    //�o�C�u������
    //a(����)�ɂ̓o�C�u�̃X�s�[�h������(0�`1f�܂�)
    void Vibration(float a)
    {
        if (gamepad != null)//�Q�[���p�b�h���ڑ�����Ă���ΐU���𔭐�������(��̈����͂��ꂼ�ꍶ�E�̃��[�^�[�̐U���̋���)
        {
            gamepad.SetMotorSpeeds(a, a);
        }
    }

    //�o�C�u���~�߂�
    public void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }

}

[System.Serializable]
class ControllerOfJump
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
class ControllerOfTrick
{
    [Header("�g���b�N�����߂����̃o�C�u�̑���")]
    [SerializeField] float trick_VibrationSpeed = 0.35f;//�g���b�N�����߂����̃o�C�u�̑���
    [Header("�g���b�N�����߂����̐U���̎���")]
    [SerializeField] float trickVibeTime = 0f;//�g���b�N�����߂����̐U���̎���
    private float remainingTrickVibeTime = 0f;//�g���b�N�̐U���̎c�莞��(�����p)

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

        VibrateController_Trick();
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

    void VibrateController_Trick()//�g���b�N���R���g���[���[���o�C�u����
    {
        remainingTrickVibeTime -= Time.deltaTime;

        if(gamepad!=null)
        {
            if (remainingTrickVibeTime > 0)
            {
                gamepad.SetMotorSpeeds(trick_VibrationSpeed,trick_VibrationSpeed);//�o�C�u������
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
            }
        }
    }
}

[System.Serializable]
class ControllerOfChargeTrick
{
    [Header("�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���")]
    [SerializeField] float chargeTrick_VibrationSpeed = 0.35f;//�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���

    ChargeTrick chargeTrickControl;
    Gamepad gamepad;

    internal void Start()
    {

    }

    internal void Update()
    {

    }
}
