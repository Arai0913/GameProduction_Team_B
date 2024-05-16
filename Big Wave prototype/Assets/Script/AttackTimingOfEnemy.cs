using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;//�G
    [SerializeField] float firstBeginAttackingTime = 5f;//�G�����ɍU�����n�߂鎞��(����)
    [SerializeField] float minBeginAttackingTime = 0.1f;//�G�����ɍU�����n�߂�ŏ�����
    [SerializeField] float maxBeginAttackingTime = 0.4f;//�G�����ɍU�����n�߂�ő厞��
    private float beginAttackingTime;//�G�����ɍU�����n�߂鎞��
    private float attackTime = 0f;//�G�̍U�����Ǘ����鎞��
    AttackPatternOfEnemy attackPatternOfEnemy;
   
    
    // Start is called before the first frame update
    void Start()
    {
        attackPatternOfEnemy = enemy.GetComponent<AttackPatternOfEnemy>();
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

        if(attackTime>beginAttackingTime)
        {
            attackTime = 0f;
            beginAttackingTime = Random.Range(minBeginAttackingTime,maxBeginAttackingTime);
            attackPatternOfEnemy.Attack();
        }
    }

    
}
