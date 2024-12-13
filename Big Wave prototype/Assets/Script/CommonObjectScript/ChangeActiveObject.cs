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
    bool _changed = false;//�ύX������

    public ChangeActiveObject(GameObject gameObject,bool active,float changeTime)//�R���X�g���N�^
    {
        _object = gameObject;
        _active = active;
        _changeTime = changeTime;
    }

    public ChangeActiveObject()//�f�t�H���g�R���X�g���N�^
    {
        _object = null;
        _active = false;
        _changeTime=0;
    }

    public void UpdateActive()
    {
        if(_changed) return;

        _currentchangeTime += Time.deltaTime;

        if(_currentchangeTime>=_changeTime)
        {
            _object.SetActive(_active);
            _changed = true;
        }
    }
}
