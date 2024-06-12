using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    //������������
    [SerializeField] float jumpPower=9f;//�W�����v��
    private bool jumpNow;//���W�����v���Ă��邩
    //[SerializeField] float jumpPowerAdjustment = 60f;//�W�����v�͒����p�A�������قǍő�g���b�N���̃W�����v�̍������オ��
    Rigidbody rb;
    JudgeTouchWave touchWave;
    Player player;

    public bool JumpNow
    {
        get { return jumpNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//���ɐG�ꂽ���W�����v���Ă��Ȃ�
        {
            //player.ConsumeTRICK();
            jumpNow = false;
        }
    }

    public void Jump()//�W�����v
    {
        if (touchWave.TouchWaveNow&&JumpNow==false)//�W�����v���Ă��Ȃ������g�ɐG��Ă���Ƃ��̂݃W�����v�\
        {
            //if (jumpNow == true) return;
            //this.rb.AddForce(transform.up * jumpPower * (1 + player.trick / jumpPowerAdjustment), ForceMode.Impulse);//!!!!!(�v����)
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//�W�����v���鍂���͏�Ɉ��

            jumpNow = true;//�W�����v����
        }
      
    }
}
