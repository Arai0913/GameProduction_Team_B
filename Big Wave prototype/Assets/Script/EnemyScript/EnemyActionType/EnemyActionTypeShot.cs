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
    [SerializeField] GenerateEffect_Action _generateEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotType.InitShotTiming();
        if (_generateEffect != null) _generateEffect.OnEnter();
        _animTrigger.Start();//���[�V�����̍Đ������̏�����
    }

    public override void OnUpdate()
    {
        shotType.UpdateShotTiming();
        if (_generateEffect != null) _generateEffect.OnUpdate();
        _animTrigger.Update();//���[�V�����̍Đ������̍X�V
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }
}
