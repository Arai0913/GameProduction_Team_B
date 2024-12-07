using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R����
//�Q�[���X�^�[�g���̃X�^�[�g�̏u�Ԃ̉��o
public class DisplayStart_GameStart : MonoBehaviour
{
    [Header("���ʉ��̐ݒ�")]
    [SerializeField] DelayPlaySound _sound;
    [Header("�����̐ݒ�")]
    [SerializeField] DisplayHideText _text;
    bool displayStart = false;//�X�^�[�g�̕�����\������t���O

    void Update()
    {
        DisplayGameStart();
    }

    public void DisplayTrigger()//�Q�[���J�n�����u�ԂɈ�x�����Ă΂�鏈��
    {
        displayStart = true;//�t���O��ON�ɂ���
    }

    void DisplayGameStart()//�Q�[�����J�n���Ă��炵�΂炭�Q�[���X�^�[�g�̕�������ʂɕ\������
    {
        if (!displayStart) return;//�X�^�[�g�̕�����\�����Ȃ��Ԃ͖���

        _sound.Update();
        _text.Update();
    }
}
