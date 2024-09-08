using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//�W�����v�̏���
public class Jump : MonoBehaviour
{
    //������������
    [SerializeField] float jumpPower=20f;//�W�����v��
    Rigidbody rb;
    JudgeTouchWave touchWave;
    JudgeJumpNow judgeJumpNow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        judgeJumpNow= gameObject.GetComponent<JudgeJumpNow>();
    }

    public void JumpTrigger()//�W�����v����
    {
        if (touchWave.TouchWaveNow&&!judgeJumpNow.JumpNow())//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
        {
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//�W�����v���鍂���͏�Ɉ��
        }
    }
}
