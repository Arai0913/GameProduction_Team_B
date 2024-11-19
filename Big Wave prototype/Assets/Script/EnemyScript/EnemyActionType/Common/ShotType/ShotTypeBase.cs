using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ShotTypeBase : MonoBehaviour
{
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    protected float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������

    public virtual void InitShotTiming()//���^�C�~���O�̏�����
    {
        currentDelayTime = 0;
    }

    public virtual void UpdateShotTiming()//���^�C�~���O�̍X�V
    {
        currentDelayTime += Time.deltaTime;
    }

    protected void ResetShoted(BulletSettingTypeBase[] bulletSetting)//�S�Ă̒e�̐ݒ��shoted(����������)�����Z�b�g����(�܂������ĂȂ���Ԃɖ߂�)
    {
        for(int i=0;i<bulletSetting.Length ;i++)
        {
            bulletSetting[i].Shoted = false;
        }
    }

    protected bool NotifyShotTiming(BulletSettingTypeBase bulletSetting)//���^�C�~���O��m�点��
    {
        if (currentDelayTime >= bulletSetting.DelayTime && !bulletSetting.Shoted) return true;
        return false;
    }

    protected GameObject GenerateBullet(BulletSettingTypeBase bulletSetting)//�e���ˑO�ɒe�𐶐����鏈���̈�A
    {
        bulletSetting.Shoted = true;
        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPosVec = bulletSetting.ShotPos.transform.position;//�ʒu
        Quaternion shotRotVec = bulletSetting.ShotPos.transform.rotation;//�p�x
        GameObject bulletObject= Instantiate(bulletSetting.BulletPrefab, shotPosVec, shotRotVec, gamePos.transform);
        return bulletObject;
    }
 
}
