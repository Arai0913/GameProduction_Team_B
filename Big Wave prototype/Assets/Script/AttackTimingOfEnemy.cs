using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;//敵
    [SerializeField] float firstBeginAttackingTime = 5f;//敵が次に攻撃を始める時間(初回)
    [SerializeField] float minBeginAttackingTime = 0.1f;//敵が次に攻撃を始める最小時間
    [SerializeField] float maxBeginAttackingTime = 0.4f;//敵が次に攻撃を始める最大時間
    private float beginAttackingTime;//敵が次に攻撃を始める時間
    private float attackTime = 0f;//敵の攻撃を管理する時間
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

    void AttackTiming()//敵の攻撃タイミング
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
