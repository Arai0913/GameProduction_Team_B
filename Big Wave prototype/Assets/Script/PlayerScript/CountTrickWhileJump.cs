using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTrickWhileJump : MonoBehaviour
{
    private int trickCount = 0;//���̃W�����v�ɂ����g���b�N�̉�
    JudgeJumpNow judgeJumpNow;

    public int TrickCount
    {
        get { return trickCount; }
    }

    void Start()
    {
        judgeJumpNow=GetComponent<JudgeJumpNow>();
    }

    void Update()
    {
        ResetTrickCount();
    }

    void ResetTrickCount()//�g���b�N�񐔂����Z�b�g(update)
    {
        if (!judgeJumpNow.JumpNow())//���n������(�W�����v���Ă��Ȃ��Ȃ�)
        {
            trickCount = 0;//1�W�����v���̃g���b�N�񐔂����Z�b�g
        }
    }

    public void AddTrickCount()//�g���b�N�񐔂̉��Z(1�񂸂�)�A�g���b�N���Ƀg���b�N�񐔂�1����Z����悤�ɂ���
    {
        trickCount++;
    }
}
