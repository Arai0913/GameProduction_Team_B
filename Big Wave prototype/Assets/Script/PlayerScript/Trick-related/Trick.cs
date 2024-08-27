using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//�g���b�N�̔�����(�o�^���ꂽ)�g���b�N���̏������Ă�
public partial class Trick : MonoBehaviour
{
    //���쐬��:���R
    [Header("�g���b�N���̏���(���\�b�h)")]
    [SerializeField] UnityEvent eventsWhenTrick;//�g���b�N���̏���(���\�b�h)
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    HP enemy_Hp;
    JudgeJumpNow judgeJumpNow;
    TrickPoint player_TrickPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        pushedButton_TrickPattern=gameObject.GetComponent<PushedButton_CurrentTrickPattern>();
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        judgeJumpNow=GetComponent<JudgeJumpNow>();
        player_TrickPoint = gameObject.GetComponent<TrickPoint>();
    }

    //�g���b�N����
    public void TrickTrigger()
    {
        if(JudgeSuccessOfTrick())//�g���b�N������
        {
            eventsWhenTrick.Invoke();//�o�^���ꂽ�S�C�x���g���Ă�
        }
    }

    bool JudgeSuccessOfTrick()//�g���b�N�������̔���(�����ł����true��Ԃ�)
    {
        int trickCost = pushedButton_TrickPattern.TrickCost;//�g���b�N����ʁA�����ꂽ�{�^���ɑΉ������g���b�N�p�^�[���̃g���b�N�����

        //�W�����v���Ă��違�G�����鎞�̂ݍU���\������g���b�N�������(�����Ńg���b�N����̏���������)
        if (judgeJumpNow.JumpNow() == true && enemy_Hp != null && player_TrickPoint.Consume(trickCost))
        {
            return true;//�g���b�N����
        }

        return false;//�g���b�N���s
    }

    //�쐬��:�K��

    //private bool tricked;//�g���b�N���������Ă��Ȃ����̔���

    //public bool Tricked
    //{
    //    get { return tricked; }
    //}

    //void Start()
    //{
    //tricked = false;
    //}

    //void Update()
    //{
    //TrickedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    //}

    //�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    //void TrickedtoFalseNoJump()
    //{
    //    if (jumpcontrol.JumpNow == false)//���ʂɐڒn���Ă���Ȃ�
    //    {
    //        tricked = false;//�U�����Ă��Ȃ�
    //    }
    //}
}

