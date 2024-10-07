using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType_E
{
    normal,
    homing
}

public enum ShotType_E
{
    forward,
    toPlayer
}

[System.Serializable]
public class Bullet_E 
{
    [Header("�e�̎��")]
    [SerializeField] BulletType_E bulletType;
    [Header("���e�����������ʒu")]
    [SerializeField] Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�

    [SerializeField] Bullet_Normal_E normal;
    [SerializeField] Bullet_Homing_E homing;
    
    private bool shoted;//�e����������

    public BulletType_E BulletType { get { return bulletType; }  }
    public Transform ShotPos { get { return shotPos; } }
    public float DelayTime { get {  return delayTime; } }
    public bool Shoted { get { return shoted; } set { shoted = value; } }
    public Bullet_Normal_E Normal { get { return normal; } }
    public Bullet_Homing_E Homing_E { get { return homing; } }


    //�ʏ�e
    [System.Serializable]
    public class Bullet_Normal_E
    {
        [Header("�ˌ��̎��")]
        [SerializeField] ShotType_E shotType;
        [Header("���e")]
        [SerializeField] GameObject bulletPrefab;//���������e
        [Header("������")]
        [SerializeField] float shotPower;//����

        public ShotType_E ShotType { get { return shotType; } }
        public GameObject BulletPrefab { get { return bulletPrefab; } }
        public float ShotPower { get {  return shotPower; }  }
    }

    //�z�[�~���O�e
    [System.Serializable]
    public class Bullet_Homing_E
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

        public HomingBullet BulletPrefab { get { return bulletPrefab; } }
        public float StartHomingTime { get {  return startHomingTime; } }
        public float HomingTime { get { return homingTime; } }
        public float HomingSpeed { get {  return homingSpeed; } }
        public float Speed { get { return speed; } }
    }
}
