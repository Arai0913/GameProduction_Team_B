using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconDisplay : MonoBehaviour
{
    [Header("A�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_AButton;//A�{�^���̃A�C�R��
    [Header("B�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_BButton;//B�{�^���̃A�C�R��
    [Header("X�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_XButton;//X�{�^���̃A�C�R��
    [Header("Y�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_YButton;//Y�{�^���̃A�C�R��

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

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
            case TrickButton.A: return icon_AButton;
            case TrickButton.B: return icon_BButton;
            case TrickButton.Y: return icon_YButton;
            case TrickButton.X: return icon_XButton;
        }
        return null;
    }
}
