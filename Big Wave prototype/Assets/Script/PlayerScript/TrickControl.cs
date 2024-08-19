using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Button
{
   A,
   B, 
   X, 
   Y
}

[System.Serializable]
public class TrickPattern
{
    [Header("����g���b�N(�Q�[�W�{��)")]
    [SerializeField] int trickCost;//����g���b�N(�v���C���[�̍ő�g���b�N��trickCostPercent%������)
    //���쐬��:����
    [Header("�g���b�N�ɗp������ʉ�")]
    [SerializeField] AudioClip trickSound;//�g���b�N�ɗp������ʉ�
    private Button buttonPattern;//�{�^���̎��

    public int TrickCost
    {
        get { return trickCost; }
    }
    public AudioClip TrickSound
    {
        get { return trickSound; }
    }

    public Button ButtonPattern
    {
        set { buttonPattern = value; }
        get { return buttonPattern; }
    }
}

public partial class TrickControl : MonoBehaviour
{
    //���쐬��:���R
    [Header("A�{�^���̃g���b�N")]
    [SerializeField] TrickPattern A_Trick;
    [Header("B�{�^���̃g���b�N")]
    [SerializeField] TrickPattern B_Trick;
    [Header("X�{�^���̃g���b�N")]
    [SerializeField] TrickPattern X_Trick;
    [Header("Y�{�^���̃g���b�N")]
    [SerializeField] TrickPattern Y_Trick;
    [Header("�ʏ펞�̓G�ɗ^����_���[�W")]
    [SerializeField] float damageAmount = 100;//�ʏ펞�̓G�ɗ^����_���[�W
    [Header("�g���b�N�񐔂̃X�R�A")]
    [SerializeField] Score_TrickCount score_TrickCount;
    [SerializeField] CountTrickWhileJump countTrickWhileJump;//1�W�����v���̃g���b�N�񐔂𐔂���@�\

    AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    Controller controller;
    FeverMode feverMode;
    Critical critical;
    CountTrickCombo countTrickCombo;
    HoverJump hoverJump;
    
    // Start is called before the first frame update
    void Start()
    {
        A_Trick.ButtonPattern = Button.A;
        B_Trick.ButtonPattern= Button.B;
        X_Trick.ButtonPattern=Button.X;
        Y_Trick.ButtonPattern = Button.Y;
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        controller = gameObject.GetComponent<Controller>();
        //�������N��������
        audioSource = GetComponent<AudioSource>();
        //
        feverMode= gameObject.GetComponent<FeverMode>();
        critical = gameObject.GetComponent<Critical>();
        countTrickCombo = gameObject.GetComponent<CountTrickCombo>();
        hoverJump = gameObject.GetComponent<HoverJump>();
    }

    // Update is called once per frame
    void Update()
    {
        countTrickWhileJump.ResetTrickCount(jumpcontrol.JumpNow);
    }

    float Damage(Button button)//�G�ɗ^����_���[�W���v
    {
        return damageAmount* feverMode.CurrentPowerUp_GrowthRate*critical.CriticalDamageRate(button);
    }

    //�g���b�N
    public void Trick(Button button)
    {
        TrickPattern trickPattern = A_Trick;//�����蓖�Ă��ƃG���[���o��̂łƂ肠�����ŏ��Ɋ��蓖�Ă�
        //�����Ŋ��蓖��
        switch (button)
        {
            case Button.A:
                trickPattern = A_Trick;
                break;
            case Button.B:
                trickPattern = B_Trick;
                break;
            case Button.X:
                trickPattern = X_Trick;
                break;
            case Button.Y:
                trickPattern = Y_Trick;
                break;
        }

        if (jumpcontrol.JumpNow == true && enemy_Hp != null && player_TrickPoint.Consume(trickPattern.TrickCost))//�W�����v���Ă��違�G�����鎞�̂ݍU���\������g���b�N�������(�����Ńg���b�N����̏���������)
        {
            //tricked = true;//�g���b�N����
            enemy_Hp.Hp -= Damage(button);
            controller.Vibe_Trick();//�o�C�u������
            countTrickWhileJump.AddTrickCount();//1�W�����v���̃g���b�N�񐔂𑝂₷(��:�t�B�[�o�[�Q�[�W�̃`���[�W�O�ɂ��̏���������)
            feverMode.ChargeFeverPoint(countTrickWhileJump.TrickCount);//�t�B�[�o�[�Q�[�W�̃`���[�W
            score_TrickCount.AddScore();//�g���b�N�ɂ��X�R�A�̉��_
            countTrickCombo.AddCombo();//�R���{�񐔉��Z
            //���쐬��:����
            audioSource.PlayOneShot(trickPattern.TrickSound);//���ʉ��̍Đ�
            //�쐬��:�K��
            hoverJump.HoverDelayJump();//�z�o�[������
        }
    }



    /////�����N���X/////

    //1�W�����v���̃g���b�N�񐔂𐔂���
    [System.Serializable]
    private class CountTrickWhileJump
    {
        private int trickCount = 0;//���̃W�����v�ɂ����g���b�N�̉�

        public int TrickCount
        {
            get { return trickCount; }
        }

        public void ResetTrickCount(bool jumpNow)//�g���b�N�񐔂����Z�b�g(update)
        {
            if (!jumpNow)//���n������
            {
                trickCount = 0;//1�W�����v���̃g���b�N�񐔂����Z�b�g
            }
        }

        public void AddTrickCount()
        {
            trickCount++;
        }
    }
}
