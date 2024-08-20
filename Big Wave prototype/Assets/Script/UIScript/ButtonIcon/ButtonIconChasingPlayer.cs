using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct ButtonDisplays
{
    [Header("�\���������{�^���̗v�f�ԍ�")]
    [Tooltip("���ݎw�肳��Ă���{�^����\���������Ȃ�0�A��ԖڂɎw�肳��Ă���{�^���Ȃ�1...")]
    [SerializeField] internal int buttonNum;//�\���������{�^���̗v�f�ԍ�
    [Header("�\�������{�^��")]
    [SerializeField] internal ButtonIconDisplay criticalButtonDisplay;//�\�������{�^��
}

public class ButtonIconChasingPlayer : MonoBehaviour
{
    [SerializeField] ButtonDisplays[] buttonDisplays;
    JumpControl jumpControl;
    TrickPoint player_TrickPoint;
    Critical critical;

    // Start is called before the first frame update
    void Start()
    {

        jumpControl = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAndHideButton();
    }

    void DisplayAndHideButton()//�{�^���\���Ɣ�\��
    {
        bool display = (jumpControl.JumpNow() && player_TrickPoint.MaxCount > 0);//�W�����v���Ă��鎞�����^���̃g���b�N�Q�[�W�̐���1�{�ȏ゠��Ƃ��\��

        if (display)
        {
            for(int i=0; i<buttonDisplays.Length;i++)
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
            }
        }
        else
        {
            for (int i = 0; i < buttonDisplays.Length; i++)
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
            
    }
}
