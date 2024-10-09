using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeNormalBullet : ShotTypeBase
{
    [Header("��:�e�ɂ͕K��Rigidbody�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeNormal[] bullets;//�e�̐ݒ�
    [Header("�v���C���[")]
    [Tooltip("�v���C���[�Ɍ������Č��e��������ΐݒ肵�Ȃ��Ă��悢")]
    [SerializeField] Transform player;//�v���C���[
    public override void InitShotTiming()
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()
    {
        base.UpdateShotTiming();
        for (int i = 0; i < bullets.Length; i++)
        {
            if (NotifyShotTiming(bullets[i]))
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(BulletSettingTypeNormal bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        //�e��Rigidbody���擾
        Rigidbody bulletObjectRb = bulletObject.GetComponent<Rigidbody>();
        //�����������߂�
        Vector3 shotVec=ShotVec(bulletSetting.ShotType,bulletSetting.ShotPos);
        //�U���̌������v���C���[�̂�������ɕύX
        bulletObject.transform.rotation = Quaternion.LookRotation(shotVec, Vector3.up);
        //�e����������
        bulletObjectRb.AddForce(shotVec * bulletSetting.ShotPower, ForceMode.Impulse);
    }

    Vector3 ShotVec(ShotType shotType,Transform shotPos)
    {
        switch(shotType)
        {
            case ShotType.toPlayer:
                return (player.transform.position - shotPos.position).normalized;
            case ShotType.forward:
                return shotPos.forward;
            default:
                return Vector3.zero;
        }
    }
}
