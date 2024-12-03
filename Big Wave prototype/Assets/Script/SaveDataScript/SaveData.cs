using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//�쐬��:���R
//�Z�[�u�f�[�^
//�E�Z�[�u�f�[�^����
//�e�퉹�ʐݒ�(�}�X�^�[��BGM��SE)
//�X�e�[�W���Ƃ̃n�C�X�R�A
//�N���A���x��
public static class SaveData
{
    const string _saveDataName_Audio = "AUDIOVOLUME";//���ʂ̃Z�[�u�f�[�^��
    const string _saveDataName_HighScore = "HIGHSCORE_STAGE";//�n�C�X�R�A�̃Z�[�u�f�[�^��
    const string _saveDataName_ClearLevel = "CLEARLEVEL";//�N���A���x���̃Z�[�u�f�[�^��
    const float defaultHighScore = 0;//�n�C�X�R�A�̏������
    const int defaultClearLevel = 0;//�N���A���x���̏������


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
        return PlayerPrefs.GetFloat(_saveDataName_HighScore+str_stageID,defaultHighScore);
    }

    public static void SaveHighScore(int stageID,float saveScore)//�n�C�X�R�A�̃Z�[�u
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighScore + str_stageID, saveScore);
        PlayerPrefs.Save();
    }

    //�N���A���x���֌W
    public static int GetClearLevel()//�N���A���x���̎擾
    {
        return PlayerPrefs.GetInt(_saveDataName_ClearLevel,defaultClearLevel);
    }

    public static void SaveClearLevel(int saveLevel)//�N���A���x���̃Z�[�u
    {
        PlayerPrefs.SetInt(_saveDataName_ClearLevel, saveLevel);
        PlayerPrefs.Save();
    }
}
