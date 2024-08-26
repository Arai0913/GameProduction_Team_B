using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public partial class TrickControl : MonoBehaviour
{
    //���쐬��:���R
    [Header("�g���b�N���̏���(���\�b�h)")]
    [SerializeField] UnityEvent eventsWhenTrick;//�g���b�N���̏���(���\�b�h)
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    HP enemy_Hp;
    JumpControl jumpcontrol;
    TrickPoint player_TrickPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        pushedButton_TrickPattern=gameObject.GetComponent<PushedButton_CurrentTrickPattern>();
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TrickPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
    }

    //�g���b�N
    public void Trick()
    {
        int trickCost = pushedButton_TrickPattern.TrickCost;//�g���b�N����ʁA�����ꂽ�{�^���ɑΉ������g���b�N�p�^�[���̃g���b�N�����

        if (jumpcontrol.JumpNow() == true && enemy_Hp != null && player_TrickPoint.Consume(trickCost))//�W�����v���Ă��違�G�����鎞�̂ݍU���\������g���b�N�������(�����Ńg���b�N����̏���������)
        {
            eventsWhenTrick.Invoke();//�o�^���ꂽ�S�C�x���g���Ă�
        }
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

