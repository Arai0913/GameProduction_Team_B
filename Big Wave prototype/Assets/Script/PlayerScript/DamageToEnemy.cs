using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    HP enemy_Hp;
    [SerializeField] FeverMode feverMode;
    [SerializeField] Critical critical;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    public void AccumulateDamage(float defaultDamage)//�_���[�W���L���[�ɒ~��
    {
        //�_���[�W�v�Z
        float damage = defaultDamage;//��{�_���[�W(�����ꂽ�{�^���ɑΉ��������݂̃g���b�N�p�^�[������擾)
        damage *= feverMode.CurrentPowerUp_GrowthRate;//�t�B�[�o�[���[�h�̃_���[�W���Z
        damage *= critical.CriticalDamageRate(pushedButton_CurrentTrickPattern.PushedButton);//�N���e�B�J���_���[�W�̉��Z
        //�L���[�Ƀ_���[�W��o�^
        damageQueue.Enqueue(damage);
    }

    public void CauseDamage()//�G�Ƀ_���[�W��^����
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
