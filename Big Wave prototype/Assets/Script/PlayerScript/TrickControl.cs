using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum TrickType
{
   type_A,
   type_B, 
   type_X, 
   type_Y
}

[System.Serializable]
class Trick
{
    [Header("����g���b�N(�Q�[�W�{��)")]
    [SerializeField] int trickCost;//����g���b�N(�v���C���[�̍ő�g���b�N��trickCostPercent%������)
    //�������N��������
    [Header("�g���b�N�ɗp������ʉ�")]
    [SerializeField] AudioClip trickSound;//�g���b�N�ɗp������ʉ�
    //
    private TrickType trickPattern;//�U���̎��

    public int TrickCost
    {
        get { return trickCost; }
    }
    public AudioClip TrickSound
    {
        get { return trickSound; }
    }

    public TrickType TrickPattern
    {
        set { trickPattern = value; }
        get { return trickPattern; }
    }
}

public class TrickControl : MonoBehaviour
{
    //���쐬��:���R
    [Header("A�{�^���̃g���b�N")]
    [SerializeField] Trick A_Trick;
    [Header("B�{�^���̃g���b�N")]
    [SerializeField] Trick B_Trick;
    [Header("X�{�^���̃g���b�N")]
    [SerializeField] Trick X_Trick;
    [Header("Y�{�^���̃g���b�N")]
    [SerializeField] Trick Y_Trick;
    [Header("�ʏ펞�̓G�ɗ^����_���[�W")]
    [SerializeField] float damageAmount = 100;//�ʏ펞�̓G�ɗ^����_���[�W
    [Header("�g���b�N�g�p���̑؋󎞊�")]
    [SerializeField] float hoverTime = 0.2f;//�g���b�N�g�p���̑؋󎞊�
    [Header("�؋�I�����ɋN����W�����v�̋���")]
    [SerializeField] float hoverJumpStrength = 2f;//�؋�I�����ɋN����W�����v�̋���
    private bool tricked;//�g���b�N���������Ă��Ȃ����̔���
    private int trickCount=0;//���̃W�����v�ɂ����g���b�N�̉�
    
    private Coroutine HoverCoroutine;
    AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    Controller controller;
    ManagementOfScore managementOfScore;
    ProcessFeverMode processFeverPoint;
    
    public bool Tricked
    {
        get { return tricked; }
    }

    // Start is called before the first frame update
    void Start()
    {
        A_Trick.TrickPattern = TrickType.type_A;
        B_Trick.TrickPattern= TrickType.type_B;
        X_Trick.TrickPattern=TrickType.type_X;
        Y_Trick.TrickPattern = TrickType.type_Y;
        tricked = false;
        trickCount = 0;
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        controller = gameObject.GetComponent<Controller>();
        //�������N��������
        audioSource = GetComponent<AudioSource>();
        //
        managementOfScore = GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();
        processFeverPoint= gameObject.GetComponent<ProcessFeverMode>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetTrickCount();
        TrickedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    }

    float Damage()//�G�ɗ^����_���[�W���v
    {
        return damageAmount* processFeverPoint.CurrentPowerUp_GrowthRate;
    }

    //�g���b�N
    void Trick(Trick trick)
    {
        if (jumpcontrol.JumpNow == true && player_TrickPoint.Consume(trick.TrickCost) && enemy_Hp != null)//�W�����v���Ă��違����g���b�N�������(�����Ńg���b�N����̏���������)���G�����鎞�̂ݍU���\
        {
            switch (trick.TrickPattern)
            {
                case TrickType.type_A:
                    enemy_Hp.Hp -= Damage();
                    break;
                case TrickType.type_B:
                    enemy_Hp.Hp -= Damage();
                    break;
                case TrickType.type_X:
                    enemy_Hp.Hp -= Damage();
                    break;
                case TrickType.type_Y:
                    enemy_Hp.Hp -= Damage();
                    break;
            }

            //�S�Ẵg���b�N�̋��ʏ���
            tricked = true;//�g���b�N����
            controller.Vibe_Trick();//�o�C�u������
                                    //�������N��������
            audioSource.PlayOneShot(trick.TrickSound);//���ʉ��̍Đ�
                                                      //
            managementOfScore.AddTrickScore();//�g���b�N�����ɂ��X�R�A�̉��_
            trickCount++;//1��g���b�N����(1�W�����v����)
            processFeverPoint.ChargeFeverPoint(trickCount);
            HoverCoroutine = StartCoroutine(HoverJump());
        }
    }


    public void Trick_A()
    {
        Trick(A_Trick);
    }

    public void Trick_B()
    {
        Trick(B_Trick);
    }
    public void Trick_X()
    {
        Trick(X_Trick);
    }
    public void Trick_Y()
    {
        Trick(Y_Trick);
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
    void TrickedtoFalseNoJump()
    {
        if (jumpcontrol.JumpNow == false)//���ʂɐڒn���Ă���Ȃ�
        {
            tricked = false;//�U�����Ă��Ȃ�
        }
    }
    IEnumerator HoverJump()
    {
        jumpcontrol.rb.useGravity = false;
        jumpcontrol.rb.velocity = Vector3.zero;//�d�͂ƃW�����v�̉^�����ꎞ�I�Ɏ~�߂�

        yield return new WaitForSeconds(hoverTime);

        jumpcontrol.rb.useGravity = true;
        jumpcontrol.rb.velocity= new(0, hoverJumpStrength, 0);
    }
}
