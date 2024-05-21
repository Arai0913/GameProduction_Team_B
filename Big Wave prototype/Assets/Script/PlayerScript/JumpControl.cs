using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    [HideInInspector] public bool jumpNow;//���W�����v���Ă��邩
    public float jumpPower=9f;//�W�����v��
    //[SerializeField] float jumpPowerAdjustment = 60f;//�W�����v�͒����p�A�������قǍő�g���b�N���̃W�����v�̍������オ��
    Rigidbody rb;
    TouchWave touchWave;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<TouchWave>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(touchWave.touchWaveNow)//�g�ɐG��Ă���Ԃ̂݃W�����v�\
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
