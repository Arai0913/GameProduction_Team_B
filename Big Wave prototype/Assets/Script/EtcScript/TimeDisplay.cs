using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
   //�������N��������
    public TMP_Text Time_UI;//�\��������e�L�X�g
    public static float seconds;//�b
    public static int minute;//��
    private float oldSeconds;//�ߋ��̕b�Bseconds�Ɣ�r����
    public static  bool sceneSwitch;//���C���̃V�[������n�܂��Ă��鎖�����m
   

    void Start()
    {
        sceneSwitch = true;
        minute = 2;
        seconds = 0f;
        oldSeconds = 0f;
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <0f)//�b��0����������番�����炵��59�b�ɂ���
        {
            minute--;
            seconds += 60;
        }
        if (seconds != oldSeconds)
        {
            Time_UI.text = "TIME:" + minute.ToString("00") + ":" + Mathf.Floor(seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
