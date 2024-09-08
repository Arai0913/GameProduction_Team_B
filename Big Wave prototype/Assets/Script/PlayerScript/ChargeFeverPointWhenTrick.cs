using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeFeverPointWhenTrick : MonoBehaviour
{
    [Header("�񐔂��Ƃ̗��܂�t�B�[�o�[�|�C���g�̒l")]
    [Header("����:�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������")]
    [SerializeField] float[] chargeFeverPoint;//�񐔂��Ƃ̗��܂�t�B�[�o�[�|�C���g�̒l

    FeverPoint player_FeverPoint;
    FeverMode feverMode;
    CountTrickWhileJump countTrickWhileJump;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GetComponent<FeverPoint>();
        feverMode=GetComponent<FeverMode>();
        countTrickWhileJump = GetComponent<CountTrickWhileJump>();
    }

    //�t�B�[�o�[�|�C���g�̃`���[�W
    public void Charge()
    {
        int count =countTrickWhileJump.TrickCount;//�g���b�N���������̂���1��̃W�����v���ɂ����g���b�N��(1�W�����v���̃g���b�N�񐔂̉��Z��ɂ��̏���������悤�ɂ���)

        if (!feverMode.FeverNow)//�t�B�[�o�[��ԂłȂ���
        {
            player_FeverPoint.FeverPoint_ += chargeFeverPoint[count - 1];//�t�B�[�o�[�|�C���g���Z(�g���b�N���邲�Ƃɉ��Z����悤�ɂ���)
        }
    }
}
