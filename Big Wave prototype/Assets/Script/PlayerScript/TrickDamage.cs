using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

//�g���b�N���̃_���[�W���Z�o���ēG�Ƀ_���[�W��^����
public class TrickDamage : MonoBehaviour
{
    HP enemy_Hp;
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    FeverMode feverMode;
    Critical critical;
    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        pushedButton_TrickPattern =GetComponent<PushedButton_CurrentTrickPattern>();
        feverMode=GetComponent<FeverMode>();
        critical=GetComponent<Critical>();
    }

    public void Damage()//�G�Ƀ_���[�W��^����
    {
        enemy_Hp.Hp -= TotalDamageAmount();
    }

    float TotalDamageAmount()//�_���[�W���v���Z�o
    {
        float damage = pushedButton_TrickPattern.DamageAmount;//��{�_���[�W(�����ꂽ�{�^���ɑΉ��������݂̃g���b�N�p�^�[������擾)
        damage *= feverMode.CurrentPowerUp_GrowthRate;//�t�B�[�o�[���[�h�̃_���[�W���Z
        damage *= critical.CriticalDamageRate(pushedButton_TrickPattern.PushedButton);//�N���e�B�J���_���[�W�̉��Z
        return damage;
    }
}
