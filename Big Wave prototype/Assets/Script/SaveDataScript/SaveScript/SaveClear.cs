using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�N���A���ɂ̂݃Z�[�u�������
//�N���A���x���E�X�e�[�W���Ƃ̃N���A�񐔁E�ő��N���A�^�C�����Z�[�u�E�X�V����A���N���A�ł���Βm�点��
public class SaveClear : MonoBehaviour
{
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Awake()
    {
        UpdateClearLevel();
        UpdateClearCount();
    }

    void UpdateClearLevel()//�N���A���x���̍X�V
    {
        //���݂̃N���A���x�����Z�[�u�f�[�^������o��
        int pastClearLevel=SaveData.GetClearLevel();
        //���݂̃N���A���x���ƗV�񂾃X�e�[�W�̃��x�����r����
        //�V�񂾃X�e�[�W�̃��x���̕�������������N���A���x�����X�V
        if(_currentStageData.Level>pastClearLevel)
        {
            _isFirstClear = true;
            SaveData.SaveClearLevel(_currentStageData.Level);
            Debug.Log("���N���A���߂łƂ��������܂��I���݂̃N���A���x����"+ SaveData.GetClearLevel() +"�ł��I");
        }
    }

    void UpdateClearCount()//�N���A�񐔂̍X�V
    {
        //���݂̃X�e�[�W�̃N���A�񐔂𑝂₷
        SaveData.AddClearCount(_currentStageData.StageID);
    }
}
