using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType_E
{
    forward,
    toPlayer
}

[System.Serializable]
public class BulletSettingTypeNormal : BulletSettingTypeBase
{
    [Header("�ˌ��̎��")]
    [SerializeField] ShotType_E shotType;
    [Header("������")]
    [SerializeField] float shotPower;//����

    public ShotType_E ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
