using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [Header("�\����Ԃ�؂�ւ���I�u�W�F�N�g")]
    [SerializeField] ChangeActiveObject[] _changeObjects;
    bool _startMotion = false;

    public void Trigger()
    {
        //_player_animator.SetTrigger(_deadTriggerName);
        Debug.Log("�������������������I�I�I(�f����)");//���[�V����������܂ł͑���Ƀf�o�b�O���O�ŃT�[�t�N�̒f�����ł������Ă����܂�
        _startMotion = true;
    }

    void Update()
    {
        UpdateChangeActive();
    }

    void UpdateChangeActive()
    {
        if (!_startMotion) return;

        for (int i = 0; i < _changeObjects.Length; i++)
        {
            _changeObjects[i].UpdateActive();
        }
    }
}
