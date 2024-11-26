using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�Ƀ_���[�W��^����
//�d�l�̕ύX(�N���e�B�J���łȂ��Ă��_���[�W��^�����Ă����̂��N���e�B�J���łȂ��ƃ_���[�W��^�����Ȃ��悤�ɂ��܂���)
public class DamageToEnemy : MonoBehaviour
{
    [Header("�ʏ�_���[�W��")]
    [SerializeField] float normalDamageAmount;//�ʏ�_���[�W��
    [Header("�N���e�B�J���_���[�W��")]
    [SerializeField] float criticalDamageAmount;//�N���e�B�J���_���[�W��
    [Header("�t�B�[�o�[���[�h���̃_���[�W�̑�����")]
    [SerializeField] float damageGrowthRate_Fever;//�t�B�[�o�[���[�h���̃_���[�W������

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] FeverMode feverMode;
    [SerializeField] Critical critical;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    const float damageGrowthRate_Normal=1;//���{(�_���[�W������)
    HP enemy_Hp;
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponentInChildren<HP>();
        generate_AlongWay.CriticalTrickEffect.LandAction += CauseDamage;
        generate_AlongWay.NormalTrickEffect.LandAction += CauseDamage;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += CauseDamage;
    }

    public void AccumulateDamage()//�_���[�W���L���[�ɒ~��
    {
        //�_���[�W�v�Z
        float damage = critical.CriticalNow ? criticalDamageAmount : normalDamageAmount;//�_���[�W��
        damage *= feverMode.FeverNow ? damageGrowthRate_Fever : damageGrowthRate_Normal;//�t�B�[�o�[���[�h�̃_���[�W���Z
        //�L���[�Ƀ_���[�W��o�^
        damageQueue.Enqueue(damage);
    }

    public void CauseDamage()//�G�Ƀ_���[�W��^����
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
