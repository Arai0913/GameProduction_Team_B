using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BulletSettingTypeBase 
{
    [Header("���e")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("���e�����������ʒu")]
    [SerializeField] protected Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] protected float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    protected bool shoted;//�e����������

    public virtual GameObject BulletPrefab { get { return bulletPrefab; } }
    public Transform ShotPos { get { return shotPos; } }
    public float DelayTime { get { return delayTime; } }
    public bool Shoted { get { return shoted; } set { shoted = value; } }
}
