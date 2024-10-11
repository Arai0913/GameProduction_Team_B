using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�񐄏�
public class ShotTypeRigidBullet : ShotTypeBase
{
    [Header("��:�e�ɂ͕K��Rigidbody�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeRigid[] bullets;//�e�̐ݒ�
    VectorOfShotType vectorOfShotType;

    void Start()
    {
        vectorOfShotType=GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
    }

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

    void Shot(BulletSettingTypeRigid bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        //�e��Rigidbody���擾
        Rigidbody bulletObjectRb = bulletObject.GetComponent<Rigidbody>();
        //�����������߂�
        Vector3 shotVec=vectorOfShotType.ShotVec(bulletSetting.ShotType,bulletSetting.ShotPos);
        //�U���̌������������ɕύX
        bulletObject.transform.rotation = Quaternion.LookRotation(shotVec, Vector3.up);
        //�e����������
        bulletObjectRb.AddForce(shotVec * bulletSetting.ShotPower, ForceMode.Impulse);
    }

    
}
