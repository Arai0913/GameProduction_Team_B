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

    public void JumpTrigger()//�W�����v����
    {
        if (touchWave.TouchWaveNow&&!judgeJumpNow.JumpNow())//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
        {
            judgeJumpNow.StartJump();
            judgeOnceReachedHighestPoint_Jumping.StartJump();
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//�W�����v���鍂���͏�Ɉ��
        }
    }
}
