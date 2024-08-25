using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class TrickDamage : MonoBehaviour
{
    HP enemy_Hp;
    PushedButton_TrickPattern pushedButton_TrickPattern;
    FeverMode feverMode;
    Critical critical;
    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        pushedButton_TrickPattern =GetComponent<PushedButton_TrickPattern>();
        feverMode=GetComponent<FeverMode>();
        critical=GetComponent<Critical>();
    }

    public void Damage()
    {
        enemy_Hp.Hp -= DamageAmount();
    }

    float DamageAmount()//�_���[�W���v
    {
        float damage = pushedButton_TrickPattern.CurrentTrickPattern.DamageAmount;//��{�_���[�W
        damage *= feverMode.CurrentPowerUp_GrowthRate;//�t�B�[�o�[���[�h�̃_���[�W���Z
        damage *= critical.CriticalDamageRate(pushedButton_TrickPattern.CurrentTrickPattern.Button);//�N���e�B�J���_���[�W�̉��Z
        return damage;
    }
}
