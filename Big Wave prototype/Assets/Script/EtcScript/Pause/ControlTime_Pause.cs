using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime_Pause : MonoBehaviour
{
    JudgePauseNow judgePauseNow;

    void Start()
    {
        judgePauseNow = GetComponent<JudgePauseNow>();
    }

    public void ChangeTimeScale()//�|�[�Y��Ԃɂ���ăQ�[�����Ԃ̑�����ύX
    {
        Time.timeScale = judgePauseNow.PauseNow ? 0 : 1;// �Q�[���̎��Ԍo�߂𐧌䂷��
    }
}
