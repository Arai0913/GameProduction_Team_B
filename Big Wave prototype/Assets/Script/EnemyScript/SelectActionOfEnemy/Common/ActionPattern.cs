using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s�����e
[System.Serializable]
public class ActionPattern//�s���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
{
    [Header("���s��")]
    [SerializeField] EnemyActionTypeBase[] action;//�s��
    [Header("���s������")]
    [SerializeField] float actionTime;//�s������

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}
