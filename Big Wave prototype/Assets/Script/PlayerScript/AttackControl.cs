using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackControl : MonoBehaviour
{
    [SerializeField] float strong_TrickCostPercent=50;//���U�����̏���g���b�N(�v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������)
    [SerializeField] float medium_TrickCostPercent=30;//���U�����̏���g���b�N(�v���C���[�̍ő�g���b�N��medium_TrickCostPercent%������)
    [SerializeField] float weak_TrickCostPercent=10;//��U�����̏���g���b�N(�v���C���[�̍ő�g���b�N��weak_TrickCostPercent%������)
    [SerializeField] float strong_Damage = 100;//���U�����̓G�ɗ^����_���[�W
    [SerializeField] float medium_Damage = 60;//���U�����̓G�ɗ^����_���[�W
    [SerializeField] float weak_Damage = 20;//��U�����̓G�ɗ^����_���[�W
    private float trickCost;//����g���b�N
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
    [HideInInspector] public bool attacked;//�U�����������Ă��Ȃ����̔���

    // Start is called before the first frame update
    void Start()
    {
       attacked = false;
       enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
       player = gameObject.GetComponent<Player>();
       jumpcontrol = gameObject.GetComponent<JumpControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack_Strong();//���U��(�Q�[�W�����)
        Attack_Medium();//���U��(�Q�[�W���)
        Attack_Weak();//��U��(�Q�[�W���)
        AttackedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    }

    //���U��(�W�����v����J�L�[��X�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    void Attack_Strong()
    {
        trickCost = player.trickMax * strong_TrickCostPercent / 100;//���U�����̏���g���b�N
        if ((Input.GetButtonDown("Fire1")||Input.GetKeyDown("j"))&& jumpcontrol.jumpNow == true&&trickCost<=player.trick&&enemy!=null)//J�L�[��X�{�^�������������W�����v���Ă��違����g���b�N������違�G�����鎞�̂ݍU���\
        {
            enemy.Damage(strong_Damage);
            attacked = true;//�U������
            player.ConsumeTRICK(trickCost);
        }
    }


    //���U��(�W�����v����K�L�[��B�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    void Attack_Medium()
    {
        trickCost = player.trickMax * medium_TrickCostPercent / 100;//���U�����̏���g���b�N
        if ((Input.GetButtonDown("Fire2") || Input.GetKeyDown("k")) && jumpcontrol.jumpNow == true && trickCost <= player.trick && enemy != null)//K�L�[��B�{�^�������������W�����v���Ă��違����g���b�N������違�G�����鎞�̂ݍU���\
        {
            enemy.Damage(medium_Damage);
            attacked = true;//�U������
            player.ConsumeTRICK(trickCost);
        }
    }


    //��U��(�W�����v����L�L�[��A�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    void Attack_Weak()
    {
        trickCost = player.trickMax * weak_TrickCostPercent / 100;//���U�����̏���g���b�N
        if ((Input.GetButtonDown("Fire3") || Input.GetKeyDown("l")) && jumpcontrol.jumpNow == true && trickCost <= player.trick && enemy != null)//L�L�[��A�{�^�������������W�����v���Ă��違����g���b�N������違�G�����鎞�̂ݍU���\
        {
            enemy.Damage(weak_Damage);
            attacked = true;//�U������
            player.ConsumeTRICK(trickCost);
        }
    }

    //�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    void AttackedtoFalseNoJump()
    {
        if (jumpcontrol.jumpNow == false)//���ʂɐڒn���Ă���Ȃ�
        {
            attacked = false;//�U�����Ă��Ȃ�
        }
    }
}
