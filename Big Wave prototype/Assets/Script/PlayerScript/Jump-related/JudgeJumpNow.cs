using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݃W�����v���Ă��邩�̔���
public class JudgeJumpNow : MonoBehaviour
{
    private bool jumpNow = false;//���݃W�����v���Ă��邩

    public bool JumpNow()//���݃W�����v���Ă��邩��Ԃ�(���Ă���Ȃ�true)
    {
        return jumpNow;
    }

    public void StartJump()//���݂̃W�����v���Ă����Ԃɂ���
    {
        jumpNow = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//�G��Ă�����̂��n�ʂł���
        {
            jumpNow = false;//���݃W�����v���Ă��邩�̏�Ԃ�ς���
        }
    }
}
