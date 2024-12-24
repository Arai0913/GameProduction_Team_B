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
    [Header("�N���A�^�C�����擾���邽�߂̃R���|�[�l���g")]
    [SerializeField] Score_TimeLimit_ _score_timelimit;
    const int _judgeFirstClear_ClearCount = 0;//���N���A�Ɣ��肷��N���A��(0��ł���΁A���N���A�ƂȂ�)
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Awake()
    {
        JudgeFirstClear();
        UpdateClearLevel();
        UpdateClearCount();
        UpdateHighClearTime();
    }

    void JudgeFirstClear()//���N���A������
    {
        //�X�V�O�̃X�e�[�W�̃N���A�񐔂�0��ł���Ώ��N���A�Ƃ�������
        int currentClearCount = SaveData.GetClearCount(_currentStageData.StageID);

        _isFirstClear = (currentClearCount == _judgeFirstClear_ClearCount);

        if(_isFirstClear) Debug.Log("���N���A���߂łƂ��������܂��I");
    }

    void UpdateClearLevel()//�N���A���x���̍X�V
    {
        //���݂̃N���A���x�����Z�[�u�f�[�^������o��
        int pastClearLevel=SaveData.GetClearLevel();
        //�N���A���x���̍X�V
        if(_currentStageData.Level>pastClearLevel)
        {
            SaveData.SaveClearLevel(_currentStageData.Level);
        }
    }

    void UpdateClearCount()//�N���A�񐔂̍X�V
    {
        //���݂̃X�e�[�W�̃N���A�񐔂𑝂₷
        SaveData.AddClearCount(_currentStageData.StageID);
    }

    void UpdateHighClearTime()//�ő��N���A�^�C���̍X�V
    {
        float currentHighClearTime = SaveData.GetHighClearTime(_currentStageData.StageID);//���݂̍ő��N���A�^�C�����擾
        float thisClearTime = _score_timelimit.ClearTime;//���݂̃N���A�^�C�����擾

        bool fasterThis = currentHighClearTime > thisClearTime;//����̕���������

        //�ő��N���A�^�C���̍X�V(���N���A�ł���Ίm��ōX�V�A�܂��N���A�^�C��������̕����͂₯��΍X�V)
        if(_isFirstClear||fasterThis)
        {
            SaveData.SaveHighClearTime(_currentStageData.StageID, thisClearTime);
        }
    }
}
