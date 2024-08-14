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

public class TrickControl : MonoBehaviour
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
    [Header("�g���b�N�g�p���̑؋󎞊�")]
    [SerializeField] float hoverTime = 0.2f;//�g���b�N�g�p���̑؋󎞊�
    [Header("�؋�I�����ɋN����W�����v�̋���")]
    [SerializeField] float hoverJumpStrength = 2f;//�؋�I�����ɋN����W�����v�̋���
    //private bool tricked;//�g���b�N���������Ă��Ȃ����̔���
    private int trickCount=0;//���̃W�����v�ɂ����g���b�N�̉�
    
    private Coroutine HoverCoroutine;
    AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    Rigidbody rb;
    Controller controller;
    FeverMode feverMode;
    Critical critical;
    
    //public bool Tricked
    //{
    //    get { return tricked; }
    //}

    // Start is called before the first frame update
    void Start()
    {
        A_Trick.ButtonPattern = Button.A;
        B_Trick.ButtonPattern= Button.B;
        X_Trick.ButtonPattern=Button.X;
        Y_Trick.ButtonPattern = Button.Y;
        //tricked = false;
        trickCount = 0;
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        rb = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<Controller>();
        //�������N��������
        audioSource = GetComponent<AudioSource>();
        //
        feverMode= gameObject.GetComponent<FeverMode>();
        critical = gameObject.GetComponent<Critical>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetTrickCount();
        //TrickedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
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
            //�S�Ẵg���b�N�̋��ʏ���
            //tricked = true;//�g���b�N����
            enemy_Hp.Hp -= Damage(button);
            controller.Vibe_Trick();//�o�C�u������
            //�������N��������
            audioSource.PlayOneShot(trickPattern.TrickSound);//���ʉ��̍Đ�
            //�g���b�N�����ɂ��X�R�A�̉��_
            trickCount++;//1��g���b�N����(1�W�����v����)
            feverMode.ChargeFeverPoint(trickCount);//�t�B�[�o�[�Q�[�W�̃`���[�W
            HoverCoroutine = StartCoroutine(HoverJump());
        }
    }

    void ResetTrickCount()
    {
        if (jumpcontrol.JumpNow == false)//���n������1�W�����v���̃g���b�N�񐔂����Z�b�g
        {
            trickCount = 0;
        }
    }

    //���K���N��������
    //�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    //void TrickedtoFalseNoJump()
    //{
    //    if (jumpcontrol.JumpNow == false)//���ʂɐڒn���Ă���Ȃ�
    //    {
    //        tricked = false;//�U�����Ă��Ȃ�
    //    }
    //}

    IEnumerator HoverJump()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;//�d�͂ƃW�����v�̉^�����ꎞ�I�Ɏ~�߂�

        yield return new WaitForSeconds(hoverTime);

        rb.useGravity = true;
        rb.velocity= new(0, hoverJumpStrength, 0);
    }
}
