using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class BulletTypeShotHoming
{
    [Header("���z�[�~���O����e")]
    [SerializeField] HomingBullet bulletPrefab;//�z�[�~���O�e
    [Header("���˂���ĉ��b�ォ��z�[�~���O���n�߂邩")]
    [SerializeField] float startHomingTime;//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩
    [Header("���b�ԃz�[�~���O���邩")]
    [SerializeField] float homingTime;//���b�ԃz�[�~���O���邩
    [Header("�W�I�Ɍ������x")]
    [Tooltip("1�b�Ԃ�homingSpeed�x�̑��x�Ō����܂�")]
    [SerializeField] float homingSpeed;//�W�I�Ɍ������x
    [Header("�e�̈ړ����x")]
    [SerializeField] float speed;//�e�̈ړ����x
    [Header("���e�����������ʒu�Ɗp�x")]
    [SerializeField] Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    private bool shoted;//�e����������

    public HomingBullet BulletPrefab
    {
        get { return bulletPrefab; }
    }

    public Transform ShotPos
    {
        get { return shotPos; }
    }

    public void OnEnter()//�s���J�n���ɌĂ�
    {
        shoted = false;
    }

    public bool JudgeShot(float currentDelayTime)//������true��Ԃ�
    {
        if (currentDelayTime >= delayTime && !shoted)//�w��̒x�����ԂɒB�������܂��e�������Ă��Ȃ���
        {
            return true;
        }

        return false;
    }

    public void SettingHomingBullet(HomingBullet bullet)//�z�u�����z�[�~���O�e�̐ݒ�
    {
        bullet.SetHomingBullet(startHomingTime, homingTime, homingSpeed, speed);
        shoted = true;
    }
}

public class EnemyActionTypeRepeatedShotHoming : EnemyActionTypeBase
{
    [Header("�e�̐ݒ�")]
    [SerializeField] BulletTypeShotHoming[] bullets;//�e�̐ݒ�
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        actionEffect.Generate();//�G�t�F�N�g����
        for(int i=0;i<bullets.Length ;i++)
        {
            bullets[i].OnEnter();
        }
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        for(int i=0;i<bullets.Length ;i++)
        {
            if (bullets[i].JudgeShot(currentDelayTime))
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(BulletTypeShotHoming bullet)
    {
        HomingBullet bulletObject= Instantiate(bullet.BulletPrefab, bullet.ShotPos.position, bullet.ShotPos.rotation, gamePos.transform);
        bullet.SettingHomingBullet(bulletObject);
    }
}
