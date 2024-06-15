using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    //������������
    [Header("�g���b�N�`���[�W���̃o�C�u�̑���")]
    [SerializeField] float chargeTrick_VibrationSpeed=0.35f;//�g���b�N�`���[�W���̃o�C�u�̑���
    MoveControl moveControl;
    JumpControl jumpControl;
    ChargeTrickControl chargeTrickControl;
    TrickControl attackControl;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        moveControl = gameObject.GetComponent<MoveControl>();
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrickControl = gameObject.GetComponent<ChargeTrickControl>();
        attackControl= gameObject.GetComponent<TrickControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�v���C���[�̓���

        Jump();//�W�����v

        Trick();//�U��
        
        VibrateController_Charge();//�`���[�W���Ă���ԃR���g���[�����U��
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InsideWave") || other.CompareTag("OutsideWave"))
        {
            ChargeTrick(other);//�g�ɐG��Ă���ԏ���ăg���b�N���`���[�W
        }
    }


    //�ړ��֘A
    void Move()//�v���C���[�̓���
    {
        //���E�L�[���E�X�e�B�b�N(���E�ɓ�����)�ŃL���������E�ɓ���
        moveControl.Move();
    }


    //�W�����v�֘A
    void Jump()//�W�����v
    {
        //�X�y�[�X�L�[��LB�{�^����RB�{�^���ŃW�����v
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jumpControl.Jump();
            StopVibration();
        }
    }


    //�U���֘A
    void Trick()//�U��
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^�������������o�t
        {
            attackControl.Trick_Buff();
        }

        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^�������������U��
        {
            attackControl.Trick_attack();
        }

        if(Input.GetButtonDown("Fire3") || Input.GetKeyDown("l"))//L�L�[��A�{�^��������������
        {
            attackControl.Trick_Heal();
        }
    }

    void VibrateController_Attack()//�U�����R���g���[���[���o�C�u����
    {

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
        if (chargeTrickControl.ChargeNow)
        {
            Vibration(chargeTrick_VibrationSpeed);//�o�C�u������
        }
        else
        {
            StopVibration();//�o�C�u���~�߂�
        }
    }


    //�o�C�u�֘A
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
    void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }



}
