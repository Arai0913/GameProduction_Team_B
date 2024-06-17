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
    [Header("�G�ɗ^����_���[�W")]
    [SerializeField] float damageAmount = 100;//�G�ɗ^����_���[�W
    [Header("HP�̉񕜗�")]
    [SerializeField] float healAmount = 50;//HP�̉񕜗�
    [Header("�U���͑����̃o�t")]
    [SerializeField] bool powerUpBuff=false;//�U���͑����̃o�t
    [Header("�`���[�W�g���b�N�ʑ����̃o�t")]
    [SerializeField] bool chargeTrickBuff=false;//�`���[�W�g���b�N�ʑ����̃o�t
    //[SerializeField] float trick_DamageFactor = 0.5f;//�g���b�N�����߂����̃_���[�W�̏㏸��A1�A�Q�A3�An���Ƃ��ꂼ��g���b�N���^�����A�g���b�N����ۂ̎��̃_���[�W��2�A3�A4�A(1+1*n)�{�ɂȂ�
    private bool tricked;//�g���b�N���������Ă��Ȃ����̔���
    AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
    BuffOfPlayer buffOfPlayer;
   
    
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
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        player = gameObject.GetComponent<Player>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>(); 
        //�������N��������
        audioSource = GetComponent<AudioSource>();
        //
    }

    // Update is called once per frame
    void Update()
    {
        TrickedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    }

    //�U��
    void Trick(Trick trick)
    {
        if (jumpcontrol.JumpNow == true && player.ConsumeCharge(trick.TrickCost) && enemy != null)//�W�����v���Ă��違����g���b�N�������(�����Ńg���b�N����̏���������)���G�����鎞�̂ݍU���\
        {
            switch (trick.TrickPattern)
            {
                case TrickType.attack://�G�Ƀ_���[�W��^����
                    //�g���b�N�����܂��Ă���Ƃ��قǃ_���[�W���㏸����悤�ɂȂ��Ă���
                    //enemy.Hp -= strength_Damage * (1 + trickPercentage * trick_DamageFactor);
                    enemy.Hp -= damageAmount * buffOfPlayer.PowerUp.CurrentGrowthRate;
                    break;
                case TrickType.heal://�v���C���[�̗̑͂��񕜂���
                    player.Hp += healAmount;
                    break;
                case TrickType.buff://�v���C���[�Ƀo�t��������
                    if (powerUpBuff)
                    {
                        buffOfPlayer.PowerUpBuff();
                    }
                    if (chargeTrickBuff)
                    {
                        buffOfPlayer.ChargeTrickBuff();
                    }
                    Debug.Log("Buff");
                    break;
            }

            //�S�Ẵg���b�N�̋��ʏ���
            tricked = true;//�U������
            //�������N��������
            audioSource.PlayOneShot(trick.TrickSound);//���ʉ��̍Đ�
            //
        }
    }

    //���U��(�W�����v����J�L�[��X�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Trick_Buff()
    {
        Trick(buffTrick);
    }

    //���U��(�W�����v����K�L�[��B�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Trick_attack()
    {
        Trick(attackTrick);
    }

    //��U��(�W�����v����L�L�[��A�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Trick_Heal()
    {
        Trick(healTrick);
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
}
