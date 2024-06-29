using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum TrickType
{
    attack,//�U��(�G�Ƀ_���[�W��^����)
    heal,//�̗͉�
    buff,//�o�t
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
    //������������
    [Header("�U���̃g���b�N")]
    [SerializeField] Trick attackTrick;//�U���̃g���b�N
    [Header("�񕜂̃g���b�N")]
    [SerializeField] Trick healTrick;//�񕜂̃g���b�N
    [Header("�o�t�̃g���b�N")]
    [SerializeField] Trick buffTrick;//�o�t�̃g���b�N
    [Header("�ʏ펞�̓G�ɗ^����_���[�W")]
    [SerializeField] float damageAmount = 100;//�ʏ펞�̓G�ɗ^����_���[�W
    [Header("HP�̉񕜗�")]
    [SerializeField] float healAmount = 50;//HP�̉񕜗�
    /*[Header("�U���͑����̃o�t")]
    [SerializeField] bool powerUpBuff=false;//�U���͑����̃o�t
    [Header("�`���[�W�g���b�N�ʑ����̃o�t")]
    [SerializeField] bool chargeTrickBuff=false;//�`���[�W�g���b�N�ʑ����̃o�t*/
    [Header("�g���b�N�����̃o�t")]
    [SerializeField] bool trickBoostBuff = false;//�g���b�N�����̃o�t
    //[SerializeField] float trick_DamageFactor = 0.5f;//�g���b�N�����߂����̃_���[�W�̏㏸��A1�A�Q�A3�An���Ƃ��ꂼ��g���b�N���^�����A�g���b�N����ۂ̎��̃_���[�W��2�A3�A4�A(1+1*n)�{�ɂȂ�
    [Header("�g���b�N�g�p���̑؋󎞊�")]
    [SerializeField] float hoverTime = 0.2f;//�g���b�N�g�p���̑؋󎞊�
    [Header("�؋�I�����ɋN����W�����v�̋���")]
    [SerializeField] float hoverJumpStrength = 2f;//�؋�I�����ɋN����W�����v�̋���
    private bool tricked;//�g���b�N���������Ă��Ȃ����̔���
    private int trickCount=0;//���̃W�����v�ɂ����g���b�N�̉�
    private bool consumedTrickPoint;//�g���b�N�Q�[�W����������ǂ����̔���
    private Coroutine HoverCoroutine;

    AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
    BuffOfPlayer buffOfPlayer;
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
        attackTrick.TrickPattern = TrickType.attack;
        healTrick.TrickPattern = TrickType.heal;
        buffTrick.TrickPattern = TrickType.buff;
        tricked = false;
        trickCount = 0;

        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        player = gameObject.GetComponent<Player>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>(); 
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
        //return damageAmount * buffOfPlayer.PowerUp.CurrentGrowthRate * processFeverPoint.CurrentPowerUp_GrowthRate;
        return damageAmount* buffOfPlayer.TrickBoost.CurrentGrowthRate * processFeverPoint.CurrentPowerUp_GrowthRate;
    }

    float Heal()
    {
        return healAmount * buffOfPlayer.TrickBoost.CurrentGrowthRate;
    }


    //�g���b�N
    void Trick(Trick trick)
    {
        if (jumpcontrol.JumpNow == true && /*player.ConsumeTrickPoint(trick.TrickCost) &&*/ enemy != null)//�W�����v���Ă��違����g���b�N�������(�����Ńg���b�N����̏���������)���G�����鎞�̂ݍU���\
        {
            consumedTrickPoint = false;

            if(trick.TrickPattern == TrickType.buff
                && buffOfPlayer.TrickBoost.BuffStockCount >= buffOfPlayer.TrickBoost.BuffStockMax)
            //�o�t�̃g���b�N���s���A���o�t�̃X�g�b�N���ő吔���܂��Ă���Ȃ�
            {
                return;//�g���b�N�̏������s��Ȃ�
            }

            if (player.ConsumeTrickPoint(trick.TrickCost))
            {
                consumedTrickPoint = true;

                switch (trick.TrickPattern)
                {
                    case TrickType.attack://�G�Ƀ_���[�W��^����
                        buffOfPlayer.TrickBoost.DecrementBuffStock();
                        enemy.Hp -= Damage();
                        break;
                    case TrickType.heal://�v���C���[�̗̑͂��񕜂���
                        buffOfPlayer.TrickBoost.DecrementBuffStock();
                        //player.Hp += healAmount;
                        player.Hp += Heal();
                        break;
                    case TrickType.buff://�v���C���[�Ƀo�t��������
                        /*if (powerUpBuff)
                        {
                            buffOfPlayer.PowerUp.Activate();
                        }
                        if (chargeTrickBuff)
                        {
                            buffOfPlayer.ChargeTrick.Activate();
                        }*/

                        if(trickBoostBuff)
                        {
                            buffOfPlayer.TrickBoost.IncreaseBuffStock();//�o�t�X�g�b�N���̑���
                            buffOfPlayer.TrickBoost.Activate();
                        }
                        break;
                }
            }

            if (consumedTrickPoint)
            {
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
    }

    //�o�t�̃g���b�N(�W�����v����J�L�[��X�{�^�������)
    public void Trick_Buff()
    {
        Trick(buffTrick);
    }

    //�U���̃g���b�N(�W�����v����K�L�[��B�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Trick_attack()
    {
        Trick(attackTrick);
    }

    //�񕜂̃g���b�N(�W�����v����L�L�[��A�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Trick_Heal()
    {
        Trick(healTrick);
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
