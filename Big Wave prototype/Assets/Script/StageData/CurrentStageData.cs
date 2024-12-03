using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݃v���C���Ă���X�e�[�W�f�[�^
public class CurrentStageData : MonoBehaviour
{
    const string _stageID_Name = "STAGE_ID";//�X�e�[�WID��ۑ����Ă���f�[�^��
    const string _level_Name = "STAGE_LEVEL";//���x����ۑ����Ă���f�[�^��
    const string _stageSceneName_Name = "STAGE_SCENENAME";//�X�e�[�W�V�[������ۑ����Ă���f�[�^��

    public int StageID
    {
        get { return PlayerPrefs.GetInt(_stageID_Name); }
    }

    public int Level
    {
        get { return PlayerPrefs.GetInt(_level_Name); }
    }

    public string StageSceneName
    {
        get { return PlayerPrefs.GetString(_stageSceneName_Name); }
    }

    public void Rewrite(StageData stageData)//��������
    {
        PlayerPrefs.SetInt(_stageID_Name,stageData.StageID);//�X�e�[�WID�̕ۑ�
        PlayerPrefs.SetInt(_level_Name,stageData.Level);//���x���̕ۑ�
        PlayerPrefs.SetString(_stageSceneName_Name,stageData.StageSceneName);//�X�e�[�W�V�[�����̕ۑ�
        PlayerPrefs.Save();
    }
}
