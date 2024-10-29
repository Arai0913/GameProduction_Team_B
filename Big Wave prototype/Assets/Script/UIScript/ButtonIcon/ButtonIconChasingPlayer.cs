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
[System.Serializable]
struct Guide
{
    public float Delay;
    public float MoveSpeed;
}
public class ButtonIconChasingPlayer : MonoBehaviour
{
    [SerializeField] ButtonDisplays[] buttonDisplays;
    [SerializeField] Guide Guide;
    JudgeJumpNow judgeJumpNow;
    TrickPoint player_TrickPoint;
    Critical critical;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        judgeJumpNow= GameObject.FindWithTag("Player").GetComponent<JudgeJumpNow>();
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
        if (judgeJumpNow.JumpNow() == false)
        {
            elapsedTime = 0;
        }
        for(int i=0;i<buttonDisplays.Length ;i++)
        {
            //�W�����v���Ă��鎞�����^���̃g���b�N�Q�[�W�̐����\���������{�^���̗v�f�ԍ���葽������Ƃ��\��
            bool display = (judgeJumpNow.JumpNow() && player_TrickPoint.MaxCount > buttonDisplays[i].buttonNum);

            if(display)//�\�����鎞
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > Guide.Delay * i)
                {
                    Vector3 moveDirection= Vector3.zero;
                    buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
                    switch (critical.CriticalButton[buttonDisplays[i].buttonNum])
                    {
                        case TrickButton.south:
                            {
                                moveDirection= Vector3.down;
                                break;
                            }
                        case TrickButton.west:
                            {
                                moveDirection = Vector3.left;
                                break;
                            }
                        case TrickButton.north:
                            {
                                moveDirection=-Vector3.up;
                                break;
                            }
                        case TrickButton.east:
                            {
                                moveDirection=Vector3.right;
                                break;
                            }
                    }
                    buttonDisplays[i].criticalButtonDisplay.transform.position += moveDirection * Time.deltaTime * Guide.MoveSpeed;
                }
            }
            else//��\�����鎞
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
    }
}
