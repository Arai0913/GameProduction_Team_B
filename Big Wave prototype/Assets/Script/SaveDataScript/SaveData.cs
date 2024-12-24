using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//�쐬��:���R
//�Z�[�u�f�[�^
//�E�Z�[�u�f�[�^����
//�e�퉹�ʐݒ�(�}�X�^�[��BGM��SE)
//�X�e�[�W���Ƃ̃n�C�X�R�A�E�N���A��
//�N���A���x��
public static class SaveData
{
    const string _saveDataName_Audio = "AUDIOVOLUME";//���ʂ̃Z�[�u�f�[�^��
    const string _saveDataName_HighScore = "HIGHSCORE_STAGE";//�n�C�X�R�A�̃Z�[�u�f�[�^��
    const string _saveDataName_ClearCount = "CLEARCOUNT_STAGE";//�N���A�񐔂̃Z�[�u�f�[�^��
    const string _saveDataName_ClearLevel = "CLEARLEVEL";//�N���A���x���̃Z�[�u�f�[�^��
    const float _defaultHighScore = 0;//�n�C�X�R�A�̏������
    const int _defaultClearCount = 0;//�N���A�񐔂̏������
    const int _maxClearCount = 9999;//�N���A�񐔂̏��
    const int _defaultClearLevel = 0;//�N���A���x���̏������


    //���ʊ֌W
    public static float GetAudioVolume(AudioType audioType,float noSaveVal)//���ʂ̎擾
    {
        string audioVolumeType=audioType.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_Audio + audioVolumeType, noSaveVal);
    }

    public static void SaveAudioVolume(AudioType audioType,float saveVolume)//���ʂ̃Z�[�u
    {
        string audioVolumeType = audioType.ToString();
        PlayerPrefs.SetFloat(_saveDataName_Audio + audioVolumeType, saveVolume);
        PlayerPrefs.Save();
    }


    //�n�C�X�R�A�֌W
    public static float GetHighScore(int stageID)//�n�C�X�R�A�̎擾
    {
        string str_stageID=stageID.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_HighScore+str_stageID,_defaultHighScore);
    }

    public static void SaveHighScore(int stageID,float saveScore)//�n�C�X�R�A�̃Z�[�u
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighScore + str_stageID, saveScore);
        PlayerPrefs.Save();
    }


    //�N���A�񐔊֌W
    public static int GetClearCount(int stageID)//�N���A�񐔂̎擾
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetInt(_saveDataName_ClearCount + str_stageID, _defaultClearCount);
    }

    public static void AddClearCount(int stageID)//�N���A�񐔂���񑝂₷
    {
        string str_stageID = stageID.ToString();

        //�N���A�񐔂��擾���Ĉ�񑝂₵�Ă���A�Z�[�u
        int currentClearCount=GetClearCount(stageID);
        currentClearCount++;
        if (currentClearCount > _maxClearCount) currentClearCount = _maxClearCount;//�����˔j���Ȃ��悤�ɂ��邽�߂̏���

        PlayerPrefs.SetInt(_saveDataName_ClearCount + str_stageID, currentClearCount);
        PlayerPrefs.Save();
    }


    //�N���A���x���֌W
    public static int GetClearLevel()//�N���A���x���̎擾
    {
        return PlayerPrefs.GetInt(_saveDataName_ClearLevel,_defaultClearLevel);
    }

    public static void SaveClearLevel(int saveLevel)//�N���A���x���̃Z�[�u
    {
        PlayerPrefs.SetInt(_saveDataName_ClearLevel, saveLevel);
        PlayerPrefs.Save();
    }
}
