using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R

public class RemainingTimeDisplay : MonoBehaviour
{
    [Header("���\��������e�L�X�g")]
    [SerializeField] TMP_Text Time_UI;//�\��������e�L�X�g
    private int minutes;//�c�莞��(�P�ʂ���)
    private float seconds;//�c�莞��(�P�ʂ��b)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(TimeLimit.RemainingTime/60);//���̍X�V
        seconds= TimeLimit.RemainingTime%60;//�b�̍X�V
        Time_UI.text = "TIME:" + minutes.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
    }
}
