using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//���݃W�����v���Ă��邩�̔���
public class JudgeJumpNow : MonoBehaviour
{
    [Header("�W�����v���n�߂̎��ɌĂԃC�x���g")]
    [SerializeField] UnityEvent startJumpEvent;
    [Header("���n���ɌĂԃC�x���g")]
    [SerializeField] UnityEvent landEvent;
    [SerializeField] OnCollisionActionEvent onCollisionActionEvent;
    private bool jumpNow = false;//���݃W�����v���Ă��邩

    private void Start()
    {
        onCollisionActionEvent.EnterAction += Landing;
    }

    public bool JumpNow()//���݃W�����v���Ă��邩��Ԃ�(���Ă���Ȃ�true)
    {
        return jumpNow;
    }

    public void StartJump()//���݂̃W�����v���Ă����Ԃɂ���
    {
        jumpNow = true;
        startJumpEvent.Invoke();
    }

    public void Landing(Collision collision)//���n
    {
        if (collision.gameObject.CompareTag("Ground"))//�G��Ă�����̂��n�ʂł���
        {
            jumpNow = false;//���݃W�����v���Ă��邩�̏�Ԃ�ς���
            landEvent.Invoke();
        }
    }
}
