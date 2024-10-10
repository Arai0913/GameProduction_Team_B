using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShot : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("�ˌ��ݒ�")]
    [SerializeField] ShotTypeBase shotType;
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotType.InitShotTiming();
        actionEffect.Generate();//�G�t�F�N�g����
        animController.AnimControl_Trigger(animName);
    }

    public override void OnUpdate()
    {
        shotType.UpdateShotTiming();
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }
}
