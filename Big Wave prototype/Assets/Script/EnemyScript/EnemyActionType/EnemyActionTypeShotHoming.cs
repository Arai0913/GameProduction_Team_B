using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShotHoming : EnemyActionTypeBase
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
    [SerializeField] Transform shotPosObject;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    private bool shoted;//�e����������
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        shoted = false;
        actionEffect.Generate();//�G�t�F�N�g����
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime >= delayTime && !shoted)//�w��̒x�����ԂɒB�������܂��e�������Ă��Ȃ���
        {
            Shot();
        }
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        
    }

    void Shot()
    {
        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPos = shotPosObject.transform.position;//�ʒu
        Quaternion shotRot = shotPosObject.transform.rotation;//�p�x
        //�U����z�u����
        HomingBullet bullet = Instantiate(bulletPrefab, shotPos, shotRot, gamePos.transform);
        //�z�u�����z�[�~���O�e�̐ݒ�
        bullet.SetHomingBullet(startHomingTime, homingTime, homingSpeed,speed);
        shoted = true;
    }
}
