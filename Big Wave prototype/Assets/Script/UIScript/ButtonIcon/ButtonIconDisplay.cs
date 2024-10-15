using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconDisplay : MonoBehaviour
{
    [Header("���{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_SouthButton;//���{�^���̃A�C�R��
    [Header("�E�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_EastButton;//�E�{�^���̃A�C�R��
    [Header("���{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_WestButton;//���{�^���̃A�C�R��
    [Header("��{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_NorthButton;//��{�^���̃A�C�R��

    public void DisplayButton(TrickButton buttonDisplayed)//�{�^���\���A����(�F��)�{�^����\�����邩�������ɓ����
    {
        //�w�肳��Ă���{�^����\��
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            if ((TrickButton)i == buttonDisplayed)
            {
                ButtonIcon((TrickButton)i).SetActive(true);
            }
            else
            {
                ButtonIcon((TrickButton)i).SetActive(false);
            }
        }
    }

    public void HideButton()//�{�^����S�ĉB��
    {
        //�S�Ẵ{�^�����\��
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            ButtonIcon((TrickButton)i).SetActive(false);
        }
    }


    GameObject ButtonIcon(TrickButton button)
    {
        switch (button)
        {
            case TrickButton.south: return icon_SouthButton;
            case TrickButton.east: return icon_EastButton;
            case TrickButton.north: return icon_NorthButton;
            case TrickButton.west: return icon_WestButton;
        }
        return null;
    }
}
