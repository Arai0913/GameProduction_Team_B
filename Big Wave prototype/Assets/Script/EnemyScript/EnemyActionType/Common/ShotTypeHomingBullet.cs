using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeHomingBullet : ShotTypeBase
{
    [Header("��:�e�ɂ͕K��HomingBullet�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeHoming[] bullets;//�e�̐ݒ�
    public override void InitShotTiming()
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()
    {
        base.UpdateShotTiming();
        for(int i=0; i<bullets.Length;i++)
        {
            if (NotifyShotTiming(bullets[i]))
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(BulletSettingTypeHoming bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        HomingBullet homingBulletObject=bulletObject.GetComponent<HomingBullet>();
        //�z�u�����z�[�~���O�e�̐ݒ�
        homingBulletObject.SetHomingBullet(bulletSetting.StartHomingTime, bulletSetting.HomingTime, bulletSetting.HomingSpeed, bulletSetting.Speed);
    }
}
