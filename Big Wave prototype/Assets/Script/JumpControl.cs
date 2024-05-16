using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    public bool jumpNow;//���W�����v���Ă��邩
    public float jumpPower=9f;//�W�����v��
    [SerializeField] float jumpPowerAdjustment = 60f;//�W�����v�͒����p�A�������قǍő�g���b�N���̃W�����v�̍������オ��
    Rigidbody rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
            Jump();//�W�����v
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//���ɐG�ꂽ���W�����v���ĂȂ�����ɂ���
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            //player.ConsumeTRICK();
            jumpNow = false;
        }
    }

    void OnTriggerEnter(Collider t)
    {
        if ((Input.GetKey(KeyCode.JoystickButton5)||Input.GetKey(KeyCode.JoystickButton4)||Input.GetKey("space"))  && t.gameObject.CompareTag("Wave"))
        {
            player.ChargeTRICK();
        
        }
     
    }

    void Jump()//�W�����v���ĂȂ����̂݃W�����v�\(�W�����v������W�����v���Ă锻��ɂ���)�A�W�����v���̃g���b�N�̒l�ɉ����ăW�����v�̍������ω�����
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4)||Input.GetKeyUp("space"))//�X�y�[�X�L�[�ŃW�����v����
        {
            if (jumpNow == true) return;

            this.rb.AddForce(transform.up * jumpPower * (1 + player.trick / jumpPowerAdjustment), ForceMode.Impulse);//!!!!!(�v����)

            jumpNow = true;
        }
      
    }
}
