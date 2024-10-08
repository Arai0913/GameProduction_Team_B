using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�G�̒e(�U��)�̕W�I(�v���C���[)�Ɍ������Ă̒�������
public class EnemyActionTypeShotToTarget1 : EnemyActionTypeBase
{
    [SerializeField] Animator anim;


    [SerializeField] ShotTypeNormalBullet shotTypeNormal;
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
       shotTypeNormal.InitShotTiming();
        actionEffect.Generate();//�G�t�F�N�g����
        anim.SetTrigger("Attack");
    }

    public override void OnUpdate()
    {
       shotTypeNormal.UpdateShotTiming();
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }


    
}
