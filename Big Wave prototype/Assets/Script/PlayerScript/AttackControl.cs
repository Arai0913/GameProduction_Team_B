using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AttackControl : MonoBehaviour
{
    //������������
    [SerializeField] float strong_TrickCostPercent=50;//���U�����̏���g���b�N(�v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������)
    [SerializeField] float medium_TrickCostPercent=30;//���U�����̏���g���b�N(�v���C���[�̍ő�g���b�N��medium_TrickCostPercent%������)
    [SerializeField] float weak_TrickCostPercent=10;//��U�����̏���g���b�N(�v���C���[�̍ő�g���b�N��weak_TrickCostPercent%������)
    [SerializeField] float strong_Damage = 100;//���U�����̓G�ɗ^����_���[�W
    [SerializeField] float medium_Damage = 60;//���U�����̓G�ɗ^����_���[�W
    [SerializeField] float weak_Damage = 20;//��U�����̓G�ɗ^����_���[�W
    [SerializeField] float trick_DamageFactor = 0.5f;//�g���b�N�����߂����̃_���[�W�̏㏸��A1�A�Q�A3�An���Ƃ��ꂼ��g���b�N���^�����A�g���b�N����ۂ̎��̃_���[�W��2�A3�A4�A(1+1*n)�{�ɂȂ�
    //�������N��������
    [SerializeField] AudioClip attackSound;//�U���ɗp������ʉ��B���P�̗]�n����
    private bool attacked;//�U�����������Ă��Ȃ����̔���
   �@AudioSource audioSource;//�v���C���[���特���o���ׂ̏��u�B
    //
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
   
    
    public bool Attacked
    {
        get { return attacked; }
    }

    // Start is called before the first frame update
    void Start()
    {
       attacked = false;
       enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
       player = gameObject.GetComponent<Player>();
       jumpcontrol = gameObject.GetComponent<JumpControl>();
        //�������N��������
        audioSource = GetComponent<AudioSource>();
        //
    }

    // Update is called once per frame
    void Update()
    {
        AttackedtoFalseNoJump();//�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    }

    //�U��
    void Attack(float strength_TrickCostPercent,float strength_Damage)
    {
        float trickPercentage = player.Trick / player.TrickMax;//�v���C���[�̃g���b�N��(�ő�l�ɑ΂��Ă̌��݂̃g���b�N�̒l)����
        float trickCost = player.TrickMax * strength_TrickCostPercent / 100;//����g���b�N
        if (jumpcontrol.JumpNow == true && trickCost <= player.Trick && enemy != null)//�W�����v���Ă��違����g���b�N������違�G�����鎞�̂ݍU���\
        {
            //player.AttackVibration(1.0f);
            //�������N��������
            audioSource.PlayOneShot(attackSound);//���ʉ��̍Đ�
            //
            enemy.Hp-=strength_Damage * (1 + trickPercentage * trick_DamageFactor);//�g���b�N�����܂��Ă���Ƃ��قǃ_���[�W���㏸����悤�ɂȂ��Ă���
            attacked = true;//�U������
            player.Trick-=trickCost;//�g���b�N����
        }
    }

    //���U��(�W�����v����J�L�[��X�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Attack_Strong()
    {
        Attack(strong_TrickCostPercent,strong_Damage);
    }

    //���U��(�W�����v����K�L�[��B�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Attack_Medium()
    {
        Attack(medium_TrickCostPercent, medium_Damage);
    }

    //��U��(�W�����v����L�L�[��A�{�^�������)
    //����g���b�N�̓v���C���[�̍ő�g���b�N��strong_TrickCostPercent%������
    public void Attack_Weak()
    {
        Attack(weak_TrickCostPercent, weak_Damage);
    }



    //���K���N��������
    //�W�����v���Ă��Ȃ����U�����Ă��Ȃ�����ɂ���
    void AttackedtoFalseNoJump()
    {
        if (jumpcontrol.JumpNow == false)//���ʂɐڒn���Ă���Ȃ�
        {
            attacked = false;//�U�����Ă��Ȃ�
        }
    }


    //private IEnumerator StopVibration()//�U�����~�߂�
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    if (player.gamepad != null)
    //    {
    //        player.gamepad.SetMotorSpeeds(0, 0);
    //    }
    //}
}
