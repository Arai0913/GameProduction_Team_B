using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�n�C�X�R�A���Z�[�u����
public class SaveHighScore : MonoBehaviour
{
    [Header("�X�R�A���v")]
    [SerializeField] Score_Total_ _score_Total_;
    [Header("�X�e�[�W�f�[�^")]
    [SerializeField] CurrentStageData _currentStageData;
    const float _defaultHighScore = 0;//������Ԃ̃n�C�X�R�A
    bool _updated = false;//�n�C�X�R�A���X�V������

    public bool Updated { get { return  _updated; } }

    void Start()
    {
        UpdateHighScore();//�n�C�X�R�A�̍X�V����
    }

    void UpdateHighScore()//�n�C�X�R�A�̍X�V����
    {
        //�V�񂾃X�e�[�W�̃n�C�X�R�A���Z�[�u�f�[�^������o��
        string stageNum = _currentStageData.StageID.ToString();
        string highScoreName = "HIGHSCORE_STAGE"+stageNum;
        float pastHighScore=PlayerPrefs.GetFloat(highScoreName,_defaultHighScore);
        //����̃X�R�A�Ɣ�r
        //��������̃X�R�A�̕���������΃n�C�X�R�A�X�V
        if(_score_Total_.Score>pastHighScore)
        {
            _updated = true;
            PlayerPrefs.SetFloat(highScoreName, _score_Total_.Score);  
            PlayerPrefs.Save();
            Debug.Log("�n�C�X�R�A�X�V�I���݂̃n�C�X�R�A��"+ PlayerPrefs.GetFloat(highScoreName, _defaultHighScore)+"�ł��I");
        }
    }
}
