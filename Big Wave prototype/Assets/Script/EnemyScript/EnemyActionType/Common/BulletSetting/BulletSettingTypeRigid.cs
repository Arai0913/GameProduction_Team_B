using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class BulletSettingTypeRigid : BulletSettingTypeBase
{
    [Header("�ˌ��̎��")]
    [SerializeField] ShotType shotType;
    [Header("������")]
    [SerializeField] float shotPower;//����

    public ShotType ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
