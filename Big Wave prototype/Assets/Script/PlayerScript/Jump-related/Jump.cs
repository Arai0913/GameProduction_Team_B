using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//�쐬��:���R
//�W�����v�̏���
public class Jump : MonoBehaviour
{
    [Header("�W�����v��")]
    [SerializeField] float jumpPower=20f;//�W�����v��
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Rigidbody rb;
    [SerializeField] JudgeTouchWave touchWave;
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] JudgeOnceReachedHighestPoint_Jumping judgeOnceReachedHighestPoint_Jumping;
    
    public bool Jumpable()//�W�����v�\����
    {
        return touchWave.TouchWaveNow && !judgeJumpNow.JumpNow();//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
    }

    public void JumpTrigger()//�W�����v����
    {
        if (Jumpable())//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
        {
            //�W�����v����
            judgeJumpNow.StartJump();
            judgeOnceReachedHighestPoint_Jumping.StartJump();
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
    }
}
