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
    [SerializeField] internal CriticalButtonDisplay criticalButtonDisplay;//�\�������{�^��
}

public class ChasePlayerButton : MonoBehaviour
{
    [SerializeField] ButtonDisplays[] buttonDisplays;
    JumpControl jumpControl;
    TRICKPoint player_TrickPoint;
    // Start is called before the first frame update
    void Start()
    {

        jumpControl = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TRICKPoint>();
        AssignButtonNum();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAndHideButton();
    }

    void DisplayAndHideButton()//�{�^���\���Ɣ�\��
    {
        if (jumpControl.JumpNow && player_TrickPoint.MaxCount > 0)//�W�����v���Ă��鎞�����^���̃g���b�N�Q�[�W�̐���1�{�ȏ゠��Ƃ�
        {
            for(int i=0; i<buttonDisplays.Length;i++)
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton();
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

    void AssignButtonNum()//�ݒ肵���S�Ẵ{�^���ɕ\���������{�^���̗v�f�ԍ��̊��蓖��
    {
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            buttonDisplays[i].criticalButtonDisplay.CriticalButtonNum = buttonDisplays[i].buttonNum;//�\���������{�^���̗v�f�ԍ��̊��蓖��
        }
    }
}
