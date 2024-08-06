using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCriticalButtonDisplay : MonoBehaviour
{
    [Header("A�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_AButton;//A�{�^���̃A�C�R��
    [Header("B�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_BButton;//B�{�^���̃A�C�R��
    [Header("X�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_XButton;//X�{�^���̃A�C�R��
    [Header("Y�{�^���̃A�C�R��")]
    [SerializeField] GameObject icon_YButton;//Y�{�^���̃A�C�R��
    Critical critical;
    JumpControl jumpControl;
    TRICKPoint player_TrickPoint;
    // Start is called before the first frame update
    void Start()
    {
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
        jumpControl = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TRICKPoint>();
        //�S�Ẵ{�^�����\��
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            ButtonIcon((Button)i).SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayButton();
    }

    void DisplayButton()//�{�^���\��
    {
        //�W�����v���Ă��鎞�����^���̃g���b�N�Q�[�W�̐���1�{�ȏ゠��Ƃ�
        if (jumpControl.JumpNow && player_TrickPoint.MaxCount > 0)
        {
            Button nextCriricalButton = critical.CriticalButton[1];//���̎w�肳��Ă���{�^��
            //�w�肳��Ă���{�^����\��
            for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
            {
                if ((Button)i == nextCriricalButton)
                {
                    ButtonIcon((Button)i).SetActive(true);
                }
                else
                {
                    ButtonIcon((Button)i).SetActive(false);
                }
            }
        }
        else
        {
            //�S�Ẵ{�^�����\��
            for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
            {
                ButtonIcon((Button)i).SetActive(false);
            }
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
