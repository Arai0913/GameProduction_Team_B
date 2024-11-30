using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//��������
public class TimeLimit : MonoBehaviour
{
    [Header("���������ԁi�b�j")]
    [SerializeField] float _timeLimit = 120;//��������(�b)
    private float _remainingTime;//�c�莞��
    bool _timeUp=false;//���Ԑ؂ꂩ
    bool _switch=false;//���ꂪfalse�̎��͎��Ԃ�����Ȃ��Ȃ�
    const float _timeUpRemainingTime = 0;//���Ԑ؂�����c�莞��

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    public float RemainingTime
    {
        get { return _remainingTime; }
    }

    void Start()
    {
        _remainingTime = _timeLimit;
    }

    void Update()
    {
       UpdateTime();
    }

    void UpdateTime()//���Ԃ̍X�V(�X�C�b�`���I�t�̎��͎��Ԃ��~�߂�)
    {
        if (!_switch||_timeUp) return;//�X�C�b�`��OFF�܂��͎��Ԑ؂�̎��͎c�莞�Ԃ�����Ȃ��悤�ɂ���

        _remainingTime -= Time.deltaTime;

        if(_timeLimit<=_timeUpRemainingTime&&!_timeUp)//���Ԑ؂ꎞ
        {
            _timeUp = true;
        }
    }
}
