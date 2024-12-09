using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShot : EnemyActionTypeBase
{
    [Header("�A�j���[�V�����̐ݒ�")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;
    [Header("�ˌ��ݒ�")]
    [SerializeField] ShotTypeBase shotType;
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotType.InitShotTiming();
        actionEffect.Generate();//�G�t�F�N�g����
        _animTrigger.Start();//���[�V�����̍Đ������̏�����
    }

    public override void OnUpdate()
    {
        shotType.UpdateShotTiming();
        _animTrigger.Update();//���[�V�����̍Đ������̍X�V
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }
}
