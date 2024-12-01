using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���݃v���C���Ă���X�e�[�W�f�[�^
[CreateAssetMenu(menuName = "ScriptableObjects/StageData/CurrentStageData")]
public class CurrentStageData : ScriptableObject
{
    StageData _currentStageData;//���݂̃X�e�[�W�f�[�^

    public int StageID { get { return _currentStageData.StageID; } }//�X�e�[�W��ID
    public int Level { get { return _currentStageData.Level; } }//�X�e�[�W�̃��x��
    public string StageSceneName { get { return _currentStageData.StageSceneName; } }//�X�e�[�W�V�[����

    public void Rewrite(StageData stageData)//���݂̃X�e�[�W�̏�������
    {
        _currentStageData=stageData;
    }

    public bool NullCheck()//null�`�F�b�N(null�̎���false��Ԃ�)
    {
        return _currentStageData!=null;
    }
}
