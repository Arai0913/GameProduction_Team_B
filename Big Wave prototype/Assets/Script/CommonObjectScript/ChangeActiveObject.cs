using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�\���E��\����Ԃ����Ԃ����炵�ĕύX����
[System.Serializable]
public class ChangeActiveObject
{
    [SerializeField] GameObject _object;
    [Header("�\�����")]
    [SerializeField] bool _active;
    [Header("���b��ɕ\����Ԃ�؂�ւ��邩")]
    [SerializeField] float _changeTime;
    float _currentchangeTime = 0;

    public void UpdateActive()
    {
        _currentchangeTime += Time.deltaTime;

        if(_currentchangeTime>=_changeTime)
        {
            _object.SetActive(_active);
        }
    }
}
