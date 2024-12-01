using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�N���A��(�N���A���x��)���Z�[�u����
public class SaveClear : MonoBehaviour
{
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    const int _defaultClearLevel = 0;//������Ԃ̃N���A���x����0
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Start()
    {
        UpdateClearLevel();
    }

    void UpdateClearLevel()//�N���A���x���̍X�V
    {
        //���݂̃N���A���x�����Z�[�u�f�[�^������o��
        string clearLevelName = "CLEARLEVEL";
        int pastClearLevel=PlayerPrefs.GetInt(clearLevelName,_defaultClearLevel);
        //���݂̃N���A���x���ƗV�񂾃X�e�[�W�̃��x�����r����
        //�V�񂾃X�e�[�W�̃��x���̕�������������N���A���x�����X�V(�����ɏ��N���A�Ƃ�������)
        if(_currentStageData.Level>pastClearLevel)
        {
            _isFirstClear = true;
            PlayerPrefs.SetInt(clearLevelName,_currentStageData.Level);
            PlayerPrefs.Save();
            Debug.Log("���N���A���߂łƂ��������܂��I���݂̃N���A���x����"+ PlayerPrefs.GetInt(clearLevelName, _defaultClearLevel)+"�ł��I");
        }

    }
}
