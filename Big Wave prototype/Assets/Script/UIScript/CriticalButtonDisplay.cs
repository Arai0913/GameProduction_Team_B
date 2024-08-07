using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalButtonDisplay : MonoBehaviour
{
    [Header("A�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_AButton;//A�{�^���̃A�C�R��
    [Header("B�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_BButton;//B�{�^���̃A�C�R��
    [Header("X�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_XButton;//X�{�^���̃A�C�R��
    [Header("Y�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_YButton;//Y�{�^���̃A�C�R��
    private int criticalButtonNum;//�\������{�^���̗v�f�ԍ��A���̃N���X���g�����͂܂��ŏ��ɂ���ɒl��������
    Critical critical;
    

     public int CriticalButtonNum
    {
        get { return criticalButtonNum; }
        set { criticalButtonNum = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayButton()//�{�^���\��
    {
        Button DisplayCriricalButton = critical.CriticalButton[criticalButtonNum];//�\������{�^��

        //�w�肳��Ă���{�^����\��
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            if ((Button)i == DisplayCriricalButton)
            {
                ButtonIcon((Button)i).SetActive(true);
            }
            else
            {
                ButtonIcon((Button)i).SetActive(false);
            }
        }
    }

    public void HideButton()//�{�^����S�ĉB��
    {
        //�S�Ẵ{�^�����\��
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            ButtonIcon((Button)i).SetActive(false);
        }
    }


    GameObject ButtonIcon(Button button)
    {
        switch (button)
        {
            case Button.A: return icon_AButton;
            case Button.B: return icon_BButton;
            case Button.Y: return icon_YButton;
            case Button.X: return icon_XButton;
        }
        return null;
    }
}
