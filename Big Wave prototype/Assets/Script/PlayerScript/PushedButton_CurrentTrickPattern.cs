using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ꂽ�{�^�����猻�݂̃g���b�N�p�^�[�������蓖�Ă�A���݂̃g���b�N�p�^�[���̏��(���ʉ������g���b�N�Ȃ�)�Ɖ����ꂽ�{�^����Ԃ�
public class PushedButton_CurrentTrickPattern : MonoBehaviour
{
    [Header("�ݒ肵�����g���b�N�p�^�[��")]
    [Tooltip("�ݒ肵�����g���b�N�p�^�[���̓{�^���̎�ނ̐��̕������ݒ肵�Ă�������")]
    [SerializeField] TrickPattern[] trickPatterns;//�ݒ肵�����g���b�N�p�^�[��
    TrickPattern currentTrickPattern;//���݂̃g���b�N�p�^�[��

    public Button PushedButton//�����ꂽ�{�^����Ԃ�
    {
        get { return currentTrickPattern.Button; }
    }

    public int TrickCost//�������{�^���ɑΉ�����g���b�N�p�^�[���̏���g���b�N��Ԃ�
    {
        get { return currentTrickPattern.TrickCost; }
    }

    public AudioClip SoundEffect//�������{�^���ɑΉ�����g���b�N�p�^�[���̌��ʉ���Ԃ�
    {
        get { return currentTrickPattern.SoundEffect; }
    }

    public float DamageAmount//�������{�^���ɑΉ�����g���b�N�p�^�[���̃_���[�W�ʂ�Ԃ�
    {
        get { return currentTrickPattern.DamageAmount; }
    }


    public void SetTrickPattern(Button button)//�󂯎�����{�^���̎�ނɉ����Č��݂̃g���b�N�p�^�[����ݒ�(���蓖�Ă�)
    {
        for(int i=0; i< trickPatterns.Length; i++)
        {
            if (button == trickPatterns[i].Button)//�w�肵���{�^���ƃg���b�N�p�^�[���ɐݒ肳��Ă���{�^������v������
            {
                currentTrickPattern = trickPatterns[i];//���݂̃g���b�N�p�^�[�������̃g���b�N�p�^�[���ɐݒ肷��
                return;
            }
        }
    }
}
