using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeNoRigidBullet : ShotTypeBase
{
    [Header("��:�e�ɂ͕K��NoRigidBullet�������I�u�W�F�N�g�����邱��")]
    [SerializeField] BulletSettingTypeNoRigid[] bullets;//�e�̐ݒ�
    VectorOfShotType vectorOfShotType;

    // Start is called before the first frame update
    void Start()
    {
        vectorOfShotType = GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
    }

    public override void InitShotTiming()//���^�C�~���O�̏�����
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()//���^�C�~���O�̍X�V
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

    void Shot(BulletSettingTypeNoRigid bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        //�����������߂�
        Vector3 shotVec = vectorOfShotType.ShotVec(bulletSetting.ShotType, bulletSetting.ShotPos);

        NoRigidBullet noRigidBullet=bulletObject.GetComponentInChildren<NoRigidBullet>();

        //�e�̐ݒ������(NoRigidBullet���擾�o���ĂȂ�������G���[���b�Z�[�W���o��)
        if(noRigidBullet==null)
        {
            Debug.Log("�e�v���n�u��NoRigidBullet�����Ă܂���I");
            return;
        }

        noRigidBullet.SetBullet(bulletSetting.Speed, shotVec);
    }
}
