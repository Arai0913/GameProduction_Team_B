using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JudgePauseNow : MonoBehaviour
{
    [SerializeField] UnityEvent pauseEvents;
    [SerializeField] UnityEvent resumeEvents;
    bool pauseNow = false;

    public bool PauseNow
    {
        get { return pauseNow; }
    }

    public void SwitchPause()//�|�[�Y��Ԃ𔽓]
    {
        pauseNow=!pauseNow;

        if(pauseNow)//�|�[�Y��
        {
            pauseEvents.Invoke();
        }
        else//�ĉ
        {
            resumeEvents.Invoke();
        }
    }
}
