using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�N���A��(�N���A���x��)���Z�[�u����
public class SaveClear : MonoBehaviour
{
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Start()
    {
        UpdateClearLevel();
    }

    void UpdateClearLevel()//�N���A���x���̍X�V
    {
        //���݂̃N���A���x�����Z�[�u�f�[�^������o��
        int pastClearLevel=SaveData.GetClearLevel();
        //���݂̃N���A���x���ƗV�񂾃X�e�[�W�̃��x�����r����
        //�V�񂾃X�e�[�W�̃��x���̕�������������N���A���x�����X�V(�����ɏ��N���A�Ƃ�������)
        if(_currentStageData.Level>pastClearLevel)
        {
            _isFirstClear = true;
            SaveData.SaveClearLevel(_currentStageData.Level);
            Debug.Log("���N���A���߂łƂ��������܂��I���݂̃N���A���x����"+ SaveData.GetClearLevel() +"�ł��I");
        }

    }
}
