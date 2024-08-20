using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeFever : MonoBehaviour
{
    [Header("�񐔂��Ƃ̗��܂�t�B�[�o�[�|�C���g�̒l")]
    [Header("����:�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������")]
    [SerializeField] float[] chargeFeverPoint;//�񐔂��Ƃ̗��܂�t�B�[�o�[�|�C���g�̒l

    FEVERPoint player_FeverPoint;
    FeverMode feverMode;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GetComponent<FEVERPoint>();
        feverMode=GetComponent<FeverMode>();
    }

    //�t�B�[�o�[�|�C���g�̃`���[�W�A������count�̓g���b�N���������̂���1��̃W�����v���ɂ����g���b�N��
    public void Charge(int count)
    {
        if (!feverMode.FeverNow)//�t�B�[�o�[��ԂłȂ���
        {
            player_FeverPoint.FeverPoint += chargeFeverPoint[count - 1];//�t�B�[�o�[�|�C���g���Z(�g���b�N���邲�Ƃɉ��Z����悤�ɂ���)
        }
    }
}
