using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    //������������
    [SerializeField] float jumpPower=20f;//�W�����v��
    [SerializeField] JudgeJumpNow judgeJumpNow;//���݃W�����v���Ă��邩�𔻒肷��
    Rigidbody rb;
    JudgeTouchWave touchWave;

    public bool JumpNow()
    {
        return judgeJumpNow.JumpNow();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        judgeJumpNow.ChangeJumpNowStatus(collision, false);//���n����
    }

    private void OnCollisionExit(Collision collision)
    {
        judgeJumpNow.ChangeJumpNowStatus(collision, true);//�W�����v����
    }

    public void Jump()//�W�����v
    {
        if (touchWave.TouchWaveNow&&!judgeJumpNow.JumpNow())//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
        {
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//�W�����v���鍂���͏�Ɉ��

            //jumpNow = true;//�W�����v����
        }
    }



    /////�����N���X/////

    [System.Serializable]
    private class JudgeJumpNow
    {
        private bool jumpNow=false;//���݃W�����v���Ă��邩

        public bool JumpNow()//���݃W�����v���Ă��邩��Ԃ�(���Ă���Ȃ�true)
        {
            return jumpNow;
        }

        //�n�ʂɐG�ꂽ(���n����)���A�W�����v���Ă��Ȃ�����ɂ���(OnCollisionEnter)�A������other�ɂ͐G�ꂽ�I�u�W�F�N�g�̏���jump�ɂ�false������
        //�n�ʂ��痣�ꂽ���A�W�����v��������ɂ���(OnCollisionExit)�A������other�ɂ͐G�ꂽ�I�u�W�F�N�g�̏���jump�ɂ�true������
        //JumpControl�N���X�ȊO�ɂ͂��̃��\�b�h���g�킹�Ȃ��悤�ɂ���
        public void ChangeJumpNowStatus(Collision collison,bool jump)
        {
            if (collison.gameObject.CompareTag("Ground"))//�G��Ă�����̂��n�ʂł���
            {
                jumpNow = jump;//���݃W�����v���Ă��邩�̏�Ԃ�ς���
            }
        }
    }
}
