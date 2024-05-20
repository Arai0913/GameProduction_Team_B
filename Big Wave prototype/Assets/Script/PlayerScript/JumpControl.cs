using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    [HideInInspector] public bool jumpNow;//���W�����v���Ă��邩
    [HideInInspector] public bool touchInsideWaveNow=false;//���ݓ����̔g�ɐG���Ă��邩
    [HideInInspector] public bool touchOutsideWaveNow = false;//���݊O���̔g�ɐG���Ă��邩
    public float jumpPower=9f;//�W�����v��
    //[SerializeField] float jumpPowerAdjustment = 60f;//�W�����v�͒����p�A�������قǍő�g���b�N���̃W�����v�̍������オ��
    Rigidbody rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(touchInsideWaveNow||touchOutsideWaveNow)//�g�ɐG��Ă���Ԃ̂݃W�����v�\
        {
            Jump();//�W�����v
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//���ɐG�ꂽ���W�����v���Ă��Ȃ�
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            //player.ConsumeTRICK();
            jumpNow = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("InsideWave"))//�����̔g�ɐG��Ă���
        {
            touchInsideWaveNow = true;
        }

        else if(other.gameObject.CompareTag("OutsideWave"))//�O���̔g�ɐG��Ă���
        {
            touchOutsideWaveNow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InsideWave"))//�����̔g����o��������̔g�ɐG��Ă��Ȃ�(����)
        {
            touchInsideWaveNow = false;
        }

        else if(other.gameObject.CompareTag("OutsideWave"))//�O���̔g����o����O���̔g�ɐG��Ă��Ȃ�(����)
        {
            touchOutsideWaveNow = false;
        }
    }

    void Jump()//�W�����v���ĂȂ����̂݃W�����v�\(�W�����v������W�����v���Ă锻��ɂ���)�A�W�����v���̃g���b�N�̒l�ɉ����ăW�����v�̍������ω�����
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4)||Input.GetKeyUp("space"))//�X�y�[�X�L�[�ŃW�����v����
        {
            if (jumpNow == true) return;//���ɃW�����v���Ă�����W�����v�ł��Ȃ�


            //this.rb.AddForce(transform.up * jumpPower * (1 + player.trick / jumpPowerAdjustment), ForceMode.Impulse);//!!!!!(�v����)
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//�W�����v���鍂���͈��

            jumpNow = true;//�W�����v����
        }
      
    }
}
