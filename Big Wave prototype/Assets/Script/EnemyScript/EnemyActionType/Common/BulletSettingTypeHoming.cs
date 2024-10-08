using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettingTypeHoming : BulletSettingTypeBase
{
    [Header("���˂���ĉ��b�ォ��z�[�~���O���n�߂邩")]
    [SerializeField] float startHomingTime;//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩
    [Header("���b�ԃz�[�~���O���邩")]
    [SerializeField] float homingTime;//���b�ԃz�[�~���O���邩
    [Header("�W�I�Ɍ������x")]
    [Tooltip("1�b�Ԃ�homingSpeed�x�̑��x�Ō����܂�")]
    [SerializeField] float homingSpeed;//�W�I�Ɍ������x
    [Header("�e�̈ړ����x")]
    [SerializeField] float speed;//�e�̈ړ����x

    public float StartHomingTime { get { return startHomingTime; } }
    public float HomingTime { get { return homingTime; } }
    public float HomingSpeed { get { return homingSpeed; } }
    public float Speed { get { return speed; } }
}
