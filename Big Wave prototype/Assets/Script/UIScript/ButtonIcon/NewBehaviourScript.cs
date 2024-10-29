using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
struct ButtonDisplayS
{
    [Header("�\���������{�^���̗v�f�ԍ�")]
    [Tooltip("���ݎw�肳��Ă���{�^����\���������Ȃ�0�A��ԖڂɎw�肳��Ă���{�^���Ȃ�1...")]
    [SerializeField] internal int buttonNum;//�\���������{�^���̗v�f�ԍ�
    [Header("�\�������{�^��")]
    [SerializeField] internal ButtonIconDisplay criticalButtonDisplay;//�\�������{�^��

}

public class NewBehaviour : MonoBehaviour
{
    [SerializeField] ButtonDisplayS[] buttonDisplays;

    JudgeJumpNow judgeJumpNow;
    TrickPoint player_TrickPoint;
    Critical critical;


    // Start is called before the first frame update
    void Start()
    {
        judgeJumpNow = GameObject.FindWithTag("Player").GetComponent<JudgeJumpNow>();
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
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            //�W�����v���Ă��鎞�����^���̃g���b�N�Q�[�W�̐����\���������{�^���̗v�f�ԍ���葽������Ƃ��\��
            bool display = (judgeJumpNow.JumpNow() && player_TrickPoint.MaxCount > buttonDisplays[i].buttonNum);

            if (display)//�\�����鎞
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
            }
            else//��\�����鎞
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
    }
}
