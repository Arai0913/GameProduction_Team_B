using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] bool secondForm=false;//���`�Ԃ̗L��
    [SerializeField] float secondFormHp = 500;//���`�ԓ˓������̗�(���̗͖̑����̎����`�ԓ˓�)
    [SerializeField] float firstBeginAttackingTime = 5f;//�G�����ɍU�����n�߂鎞��(����)
    [SerializeField] float minFirstFormBeginAttackingTime = 0.1f;//�G�����ɍU�����n�߂�ŏ�����(���`��)
    [SerializeField] float maxFirstFormBeginAttackingTime = 0.4f;//�G�����ɍU�����n�߂�ő厞��(���`��)
    [SerializeField] float minSecondFormBeginAttackingTime = 0.1f;//�G�����ɍU�����n�߂�ŏ�����(���`��)
    [SerializeField] float maxSecondFormBeginAttackingTime = 0.4f;//�G�����ɍU�����n�߂�ő厞��(���`��)
    private float beginAttackingTime;//�G�����ɍU�����n�߂鎞��
    private float attackTime = 0f;//�G�̍U�����Ǘ����鎞��
    AttackPatternOfEnemy attackPatternOfEnemy;
    Enemy enemy;
   
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        attackPatternOfEnemy = gameObject.GetComponent<AttackPatternOfEnemy>();
        beginAttackingTime = firstBeginAttackingTime;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTiming();
    }

    void AttackTiming()//�G�̍U���^�C�~���O
    {
        attackTime += Time.deltaTime;

        if(attackTime>beginAttackingTime&&enemy.hp<secondFormHp&&secondForm==true)//���`�Ԃ̍s��
        {
            attackTime = 0f;
            beginAttackingTime = Random.Range(minSecondFormBeginAttackingTime, maxSecondFormBeginAttackingTime);
            attackPatternOfEnemy.Attack(2);
        }

        else if(attackTime>beginAttackingTime)//���`�Ԏ��̍s��
        {
            attackTime = 0f;
            beginAttackingTime = Random.Range(minFirstFormBeginAttackingTime, maxFirstFormBeginAttackingTime);
            attackPatternOfEnemy.Attack(1);
        }
    }

    
}
