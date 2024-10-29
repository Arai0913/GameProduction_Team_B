using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�Ƀ_���[�W��^����
public class DamageToEnemy : MonoBehaviour
{
    [Header("��{�_���[�W��")]
    [SerializeField] float defaultDamageAmount;//��{�_���[�W��
    [Header("�t�B�[�o�[���[�h���̃_���[�W�̑�����")]
    [SerializeField] float damageGrowthRate_Fever;//�t�B�[�o�[���[�h���̃_���[�W������
    [Header("�N���e�B�J�����̃_���[�W�̑�����")]
    [SerializeField] float damageGrowthRate_Critical;//�N���e�B�J�����̃_���[�W������

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] FeverMode feverMode;
    [SerializeField] Critical critical;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;

    const float damageGrowthRate_Normal=1;//���{(�_���[�W������)
    HP enemy_Hp;
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    public void AccumulateDamage()//�_���[�W���L���[�ɒ~��
    {
        //�_���[�W�v�Z
        float damage = defaultDamageAmount;//��{�_���[�W
        damage *= feverMode.FeverNow?damageGrowthRate_Fever:damageGrowthRate_Normal;//�t�B�[�o�[���[�h�̃_���[�W���Z
        damage *= critical.CriticalNow?damageGrowthRate_Critical:damageGrowthRate_Normal;//�N���e�B�J���_���[�W�̉��Z
        //�L���[�Ƀ_���[�W��o�^
        damageQueue.Enqueue(damage);
    }

    public void CauseDamage()//�G�Ƀ_���[�W��^����
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
