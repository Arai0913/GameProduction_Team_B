using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResultDisplay : MonoBehaviour
{
    public TMP_Text Result_UI;
   
    // Start is called before the first frame update
    void Start()
    {
        if (TimeDisplay.sceneSwitch != false)//�N���A��ʂɈڍs���������m�F�����炻�̎��_�̎��Ԃ�\������
        {
            Result_UI.text = "ClearTime: " + TimeDisplay.minute.ToString("00") + ":" + TimeDisplay.seconds.ToString("00");
        }
        else
        {
            Result_UI.text = "ClearTime:00:00";
        }
    }

    // Update is called once per frame
   
}
