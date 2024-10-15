using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletSettingTypeNoRigid : BulletSettingTypeBase
{
    [Header("�ˌ��̎��")]
    [SerializeField] ShotType shotType;
    [Header("�e�̃X�s�[�h")]
    [SerializeField] float speed;

    public ShotType ShotType { get { return shotType; } }
    public float Speed { get { return speed; } }
}
