using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    forward,
    toPlayer
}

[System.Serializable]
public class BulletSettingTypeNormal : BulletSettingTypeBase
{
    [Header("�ˌ��̎��")]
    [SerializeField] ShotType shotType;
    [Header("������")]
    [SerializeField] float shotPower;//����

    public ShotType ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
