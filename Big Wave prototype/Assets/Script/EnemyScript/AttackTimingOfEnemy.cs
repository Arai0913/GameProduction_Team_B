using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
class FormAttackTiming//�`��
{
    public float formHp;//�w��`�ԓ˓������̗�(���̗͈̑ȉ��̎����̌`�ԓ˓�)
    public float minBeginAttackingTime;//�G�����ɍU�����n�߂�ŏ�����
    public float maxBeginAttackingTime;//�G�����ɍU�����n�߂�ő厞��
}

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] float firstBeginAttackingTime = 5f;//�G�����ɍU�����n�߂鎞��(����)
    [SerializeField] FormAttackTiming[] form;//�`�Ԃ��Ƃ̍U���^�C�~���O�Ɠ˓������̗͂̔z��
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

        form[0].formHp = enemy.hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTiming();
    }

    void AttackTiming()//�G�̍U���^�C�~���O
    {
        attackTime += Time.deltaTime;

        if(attackTime > beginAttackingTime)
        {
            for (int i = form.Length-1; 0<=i ; i--)//�w��̗͈ȉ��ł��̌`�Ԃ̍s��������(�ŏI�`�Ԃ̏������珇�Ɍ��Ă���)
            {
                if (enemy.hp <= form[i].formHp)//i+1�`�Ԗڂ̏������m�F
                {
                    attackTime = 0f;
                    beginAttackingTime = Random.Range(form[i].minBeginAttackingTime, form[i].maxBeginAttackingTime);
                    attackPatternOfEnemy.Attack(i+1);
                    break;
                }
            }
        }
    }

    
}
