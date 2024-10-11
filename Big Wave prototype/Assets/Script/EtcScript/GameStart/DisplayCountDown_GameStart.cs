using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�Q�[���X�^�[�g���̃J�E���g�_�E���̉��o
public class DisplayCountDown_GameStart : MonoBehaviour
{
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text countDownText;//�\��������e�L�X�g
    [Header("�c��b�����ς�邲�Ƃɏo�����ʉ�")]
    [SerializeField] AudioClip countDownSoundEffect;//�c��b�����ς�邲�Ƃɏo�����ʉ�
    private int remainingGameStartTimeBeforeFrame_Display;//�O�t���[���̃Q�[���J�n�܂ł̎c�莞��(�����̂�)
    JudgeGameStart judgeGameStart;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        judgeGameStart = GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCountDown();//�J�E���g�_�E���̕\��
    }

    void DisplayCountDown()//�J�E���g�_�E���̕\��
    {
        if (judgeGameStart.IsStarted) return;//�Q�[�����J�n������J�E���g�_�E�������Ȃ��Ȃ�

        int remainingGameStartTime_Display = (int)Mathf.Ceil(judgeGameStart.RemainingGameStartTime);//�\������c�莞��(�Ⴆ��3�`2.00...1�Ȃ�3�A2�`1.00...1�Ȃ�2�ɂȂ�)

        //�O�t���[���ƕ\������c�莞�Ԃ��������(�ς���Ă�����)���ʉ����o��
        if (remainingGameStartTimeBeforeFrame_Display != remainingGameStartTime_Display)
        {
            audioSource.PlayOneShot(countDownSoundEffect);//�Q�[���J�n���̌��ʉ����o��
        }

        countDownText.text = remainingGameStartTime_Display.ToString("0");

        remainingGameStartTimeBeforeFrame_Display = remainingGameStartTime_Display;
    }
}
