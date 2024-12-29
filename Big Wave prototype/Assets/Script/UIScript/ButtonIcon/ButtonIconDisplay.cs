using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconDisplay : MonoBehaviour
{
    [Header("�{�^���̃A�C�R��")]
    [SerializeField] GetTrickButton<GameObject> icon_Button;//�{�^���̃A�C�R��

    public void DisplayButton(TrickButton buttonDisplayed)//�{�^���\���A����(�F��)�{�^����\�����邩�������ɓ����
    {
        //�w�肳��Ă���{�^����\��
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            if ((TrickButton)i == buttonDisplayed)
            {
                icon_Button.Get((TrickButton)i).SetActive(true);
            }
            else
            {
                icon_Button.Get((TrickButton)i).SetActive(false);
            }
        }
    }

    public void HideButton()//�{�^����S�ĉB��
    {
        //�S�Ẵ{�^�����\��
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            icon_Button.Get((TrickButton)i).SetActive(false);
        }
    }
}
