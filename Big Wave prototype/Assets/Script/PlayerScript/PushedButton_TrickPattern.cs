using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedButton_TrickPattern : MonoBehaviour
{
    [Header("�ݒ肵�����g���b�N�p�^�[��")]
    [Tooltip("�ݒ肵�����g���b�N�p�^�[���̓{�^���̎�ނ̐��̕������ݒ肵�Ă�������")]
    [SerializeField] TrickPattern[] trickPatterns;//�ݒ肵�����g���b�N�p�^�[��
    TrickPattern currentTrickPattern;//���݂̃g���b�N�p�^�[��

    public TrickPattern CurrentTrickPattern
    {
        get { return currentTrickPattern; }
    }

    public void SetTrickPattern(Button button)//�󂯎�����{�^���̎�ނɉ����Č��݂̃g���b�N�p�^�[����ݒ�
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
