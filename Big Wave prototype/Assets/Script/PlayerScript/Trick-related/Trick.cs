using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g���b�N�̔�����(�o�^���ꂽ)�g���b�N���̏������Ă�
public partial class Trick : MonoBehaviour
{
    //���쐬��:���R
    [Header("�g���b�N���̏���(���\�b�h)")]
    [SerializeField] UnityEvent eventsWhenTrick;//�g���b�N���̏���(���\�b�h)
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    //[SerializeField] CountTrickCombo countTrickCombo;
    //[SerializeField] CountTrickWhileJump countTrickWhileJump;
    //[SerializeField] ControllerVibeOfTrick controllerVibeOfTrick;
    //[SerializeField] ChargeFeverPointWhenTrick chargeFeverPointWhenTrick;
    //[SerializeField] Score_TrickCount score_TrickCount;
    //[SerializeField] HoverJump hoverJump;
    //[SerializeField] GenerateEffectAlongWay generateEffectAlongWay;

    HP enemy_Hp;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    //�g���b�N����
    public void TrickTrigger(TrickButton button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//�����ꂽ�{�^���̎�ނ�ݒ�

        if (JudgeSuccessOfTrick())//�g���b�N������
        {
            eventsWhenTrick.Invoke();//�o�^���ꂽ�S�C�x���g���Ă�
            //EventsWhwnTrick();
        }
    }

    //void EventsWhwnTrick()//�g���b�N���̏���(�C�x���g)
    //{
    //    countTrickWhileJump.AddTrickCount();//�W�����v���̃g���b�N�񐔂̉��Z
    //    countTrickCombo.AddCombo();//�g���b�N�R���{�񐔂̉��Z
    //    pushedButton_TrickPattern.TrickEffect();//�g���b�N���̌��ʂ𔭓�
    //    controllerVibeOfTrick.Vibe();//�g���b�N���̃R���g���[���̃o�C�u
    //    chargeFeverPointWhenTrick.Charge();//�t�B�[�o�[�|�C���g�̃`���[�W
    //    score_TrickCount.AddScore();//�g���b�N�񐔂̃X�R�A���Z
    //    hoverJump.HoverJumpTrigger();//�z�o�[�W�����v������
    //    generateEffectAlongWay.ActivateEffect();//���[�v��`���G�t�F�N�g�𐶐�����
    //}

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

