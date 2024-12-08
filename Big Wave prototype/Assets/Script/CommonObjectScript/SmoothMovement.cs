using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���������炩�ɂ���(Vector3��ԋp)
[System.Serializable]
public class SmoothMovement
{
    [Header("�o�b�t�@�[��")]
    [Tooltip("��������ƒx�����������₷���Ȃ�܂�")]
    [SerializeField] int _bufferNum;//"�o�b�t�@�[���A��������ƒx�����������₷���Ȃ�܂�
    private Vector3[] _posBuffers;
    private int _currentBufferNum=0;//���݃o�b�t�@�[�Ɋi�[����Ă���l�̌��A�����͉��������ĂȂ��̂�0
    private int _nextBufferIndex = 0;//���ɒl������o�b�t�@�[�̗v�f�ԍ�

    public SmoothMovement(int bufferNum)//�R���X�g���N�^
    {
        _bufferNum = bufferNum;
        _currentBufferNum = 0;
        _nextBufferIndex = 0;

        SecureBuffer();
    }

    //�o�b�t�@�[�m��(�R���X�g���N�^��p�����Ɏg���ꍇ�͍ŏ��ɂ�����Ă�)
    public void SecureBuffer()
    {
        _posBuffers=new Vector3[_bufferNum];

        for(int i=0; i<_posBuffers.Length;i++)
        {
            _posBuffers[i]=new Vector3();
        }
    }

    public Vector3 Smooth(Vector3 nowPos)
    {
        //�o�b�t�@�[�Ɍ��݂̒l������
        _posBuffers[_nextBufferIndex]=nowPos;

        //���݃o�b�t�@�[�Ɋi�[����Ă���l�̌����X�V
        

        //���ɒl������o�b�t�@�̗v�f�ԍ����X�V

        //�o�b�t�@�[�Ɋi�[����Ă���S�Ă̒l�̕��ς��Ƃ�
        //���݃o�b�t�@�[�Ɋi�[����Ă���l�̌����A�o�b�t�@�[���ɖ����Ȃ��ꍇ�͌��݊i�[����Ă���l�̌����畽�ς��Ƃ�

        //����ꂽ�l��Ԃ�

        return Vector3.zero;
    }
}
