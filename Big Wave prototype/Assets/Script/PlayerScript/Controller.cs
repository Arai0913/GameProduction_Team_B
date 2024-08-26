using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//���쐬��:���R

public class Controller : MonoBehaviour
{
    [SerializeField] ControllerOfJump controllerOfJump;//�W�����v�֌W�̃R���g���[���[�̏����A(��)[SerializeField]�����Ȃ��ƃG���[�N�����Ⴄ
    [Header("�|�[�Y�֌W")]
    [SerializeField] ControllerOfPause controllerOfPause;//�|�[�Y�֌W�̃R���g���[���[�̏���
    [Header("�g���b�N�֌W")]
    [SerializeField] ControllerOfTrick controllerOfTrick;//�g���b�N�֌W�̃R���g���[���̏���
    [Header("�g���b�N�̃`���[�W�֌W")]
    [SerializeField] ControllerOfChargeTrick controllerOfChargeTrick;//�g���b�N�̃`���[�W�֌W�̃R���g���[���̏���

    JumpControl jumpControl;
    ChargeTrickPoint chargeTrick;
    TrickControl trickControl;
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrick = gameObject.GetComponent<ChargeTrickPoint>();
        trickControl= gameObject.GetComponent<TrickControl>();
        pushedButton_TrickPattern=gameObject.GetComponent<PushedButton_CurrentTrickPattern>();

        controllerOfJump.Start(jumpControl);
        controllerOfTrick.Start(trickControl, pushedButton_TrickPattern ,gamepad);
        controllerOfChargeTrick.Start(chargeTrick, gamepad);
    }

    // Update is called once per frame
    void Update()
    {
        controllerOfJump.Update();
        controllerOfPause.Update();
        controllerOfTrick.Update();
        controllerOfChargeTrick.Update();
    }

    public void Vibe_Trick()//�g���b�N�̃o�C�u
    {
        controllerOfTrick.Vibe();
    }



    /////�����N���X/////

    [System.Serializable]
    private class ControllerOfPause//�|�[�Y�֌W�̃R���g���[���[�̏���
    {
        [Header("�|�[�Y���")]
        [SerializeField] PauseControl pauseControl;//�|�[�Y���

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // P�L�[�������ꂽ��
            {
                pauseControl.TogglePause(); // �|�[�Y�̐؂�ւ�
            }
        }
    }




    [System.Serializable]
    private class ControllerOfJump//�W�����v�֌W�̃R���g���[���[�̏���
    {
        JumpControl jumpControl;

        public void Start(JumpControl j)
        {
            jumpControl = j;
        }

        public void Update()//�W�����v
        {
            //�X�y�[�X�L�[��LB�{�^����RB�{�^���ŃW�����v
            if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
            {

                jumpControl.Jump();
            }
        }
    }





    [System.Serializable]
    private class ControllerOfTrick//�g���b�N�֌W�̃R���g���[���[�̏���
    {
        [Header("�g���b�N�����߂����̃o�C�u�̑���")]
        [Range(0, 1)]
        [SerializeField] float vibrationSpeed = 1f;//�g���b�N�����߂����̃o�C�u�̑���
        [Header("�g���b�N�����߂����̐U���̎���")]
        [SerializeField] float vibeTime = 0.2f;//�g���b�N�����߂����̐U���̎���
        private float remainingVibeTime = 0f;//�g���b�N�̐U���̎c�莞��(�����p)

        TrickControl trickControl;
        PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
        Gamepad gamepad;

        public void Start(TrickControl t, PushedButton_CurrentTrickPattern p ,Gamepad g)
        {
            trickControl = t;
            pushedButton_TrickPattern = p;
            gamepad = g;
        }

        public void Update()
        {
            Trick();

            VibrateController();
        }

        void Trick()//�g���b�N
        {
            if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//H�L�[��Y�{�^��
            {
                Trick_Process(Button.Y);
            }
            else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("j"))//J�L�[��X�{�^��
            {
                Trick_Process(Button.X);
            }
            else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("k"))//K�L�[��B�{�^��
            {
                Trick_Process(Button.B);
            }
            else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("l"))//L�L�[��A�{�^��
            {
                Trick_Process(Button.A);
            }

            //����(���R)�̃R���g���[���[�p
            //if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//H�L�[��Y�{�^��
            //{
            //    Trick_Process(Button.Y);
            //}
            //else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//J�L�[��X�{�^��
            //{
            //    Trick_Process(Button.X);
            //}
            //else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//K�L�[��B�{�^��
            //{
            //    Trick_Process(Button.B);
            //}
            //else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("l"))//L�L�[��A�{�^��
            //{
            //     Trick_Process(Button.A);
            //}
        }

        void Trick_Process(Button button)
        {
            pushedButton_TrickPattern.SetTrickPattern(button);//�����ꂽ�{�^���̎�ނ�ݒ�
            trickControl.Trick();//�g���b�N
        }


        void VibrateController()//�g���b�N���R���g���[���[���o�C�u����
        {
            remainingVibeTime -= Time.deltaTime;

            if (gamepad != null)
            {
                if (remainingVibeTime > 0)
                {
                    gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//�o�C�u������
                }
                else
                {
                    gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
                }
            }
        }

        public void Vibe()//�g���b�N���Ƀo�C�u���Ăق����Ƃ�������Ă�
        {
            remainingVibeTime = vibeTime;
        }
    }





    [System.Serializable]
    private class ControllerOfChargeTrick//�g���b�N�̃`���[�W�֌W�̏���
    {
        [Header("�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���")]
        [Range(0, 1)]
        [SerializeField] float vibrationSpeed = 1f;//�g���b�N���`���[�W���Ă��鎞�̃o�C�u�̑���

        ChargeTrickPoint chargeTrick;
        Gamepad gamepad;

        public void Start(ChargeTrickPoint c, Gamepad g)
        {
            chargeTrick = c;
            gamepad = g;
        }

        public void Update()
        {
            ChargeStandbyOn();

            VibrateController();
        }

        void ChargeStandbyOn()//�g�ɐG��ăg���b�N���`���[�W�ł���悤�ɂ���
        {
            //�X�y�[�X�L�[��{�^���������Ă���Ԃ͔g�ɐG��ă`���[�W���ł���悤�ɂȂ�
            if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
            {
                chargeTrick.ChargeStandby = true;
            }
            else
            {
                chargeTrick.ChargeStandby = false;
            }
        }

        void VibrateController()//�`���[�W���Ă���ԃR���g���[�����U��
        {
            if (gamepad != null)
            {
                if (chargeTrick.ChargeNow())
                {
                    gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//�o�C�u������
                }
                else
                {
                    gamepad.SetMotorSpeeds(0f, 0f);//�o�C�u���~�߂�
                }
            }
        }
    }



}






