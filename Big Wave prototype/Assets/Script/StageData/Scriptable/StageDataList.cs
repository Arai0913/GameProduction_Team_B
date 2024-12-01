using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W�f�[�^�̃��X�g
[CreateAssetMenu(menuName = "ScriptableObjects/StageData/StageDataList")]
public class StageDataList : ScriptableObject
{
    [Header("�X�e�[�W���Ƃ̃f�[�^")]
    [Header("�v�f�ԍ��ƃX�e�[�W��ID�͍��킹�Ă����Ă�������(ID�̈�Ӑ���ۂ���)")]
    [SerializeField] StageData[] _stageDatas;//�X�e�[�W���Ƃ̃f�[�^

    public StageData Get(int dataID)
    {
        //�v�f�ԍ����͈͊O�̏ꍇ���X�g�ɂ��̃f�[�^���Ȃ��|��`����
        if(dataID<0||_stageDatas.Length<=dataID)
        {
            Debug.Log("����ID�̃f�[�^�̓��X�g�ɂ���܂���");
            return null;
        }

        //�v�f�ԍ���ID�������ĂȂ������ꍇ�f�o�b�O���O�Ƀ��X�g�ɕs��������|��`����
        if (dataID != _stageDatas[dataID].StageID)
        {
            Debug.Log("�v�f�ԍ���ID�����v���܂���I���X�g�ɕs��������܂��I");
            return null;
        }

        //���ɕs����������΃f�[�^��n��
        return _stageDatas[dataID];
    }
}
