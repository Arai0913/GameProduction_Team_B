using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�Q�[���J�n�̃J�E���g�_�E��������
public class DisplayCountDownGameStart : MonoBehaviour
{
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text countDownText;//�\��������e�L�X�g
    [Header("�Q�[���J�n���ɕ\�����镶��")]
    [SerializeField] string startText;//�Q�[���J�n���ɕ\�����镶��
    [Header("�Q�[���J�n�̕������o������")]
    [SerializeField] float displayTime_GameStart;//�Q�[���J�n�̕������o������
    [Header("�c��b�����ς�邲�Ƃɏo�����ʉ�")]
    [SerializeField] AudioClip countDownSoundEffect;//�c��b�����ς�邲�Ƃɏo�����ʉ�
    [Header("�Q�[���J�n�����u�Ԃɏo�����ʉ�")]
    [SerializeField] AudioClip gameStartSoundEffect;//�Q�[���J�n�����u�Ԃɏo�����ʉ�
    private float remainingdisplayTime_GameStart;//�Q�[���J�n�̕������o���c�莞��
    private int remainingGameStartTimeBeforeFrame_Display;//�O�t���[���̃Q�[���J�n�܂ł̎c�莞��(�����̂�)
    JudgeGameStart judgeGameStart;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        judgeGameStart=GetComponent<JudgeGameStart>();
        audioSource = GetComponent<AudioSource>();
        remainingdisplayTime_GameStart = displayTime_GameStart;//�Q�[���J�n�̕������o���c�莞�Ԃ�ݒ�
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    void CountDown()//�Q�[���J�n�̃J�E���g�_�E��
    {
        if (remainingdisplayTime_GameStart <= 0) return;//�Q�[���J�n�̕������o���c�莞�Ԃ��Ȃ��Ȃ�����J�E���g�_�E�������Ȃ��Ȃ�


        bool gameStart = judgeGameStart.IsStarted;//�Q�[�����J�n���ꂽ��

        if (gameStart)//�Q�[�����J�n���ꂽ��
        {
            DisplayGameStart();//�Q�[���J�n�̕�����\��
        }
        else//�܂��Q�[�����J�n����Ă��Ȃ��Ȃ�
        {
            DisplayRemainingTime();//�J�n�܂ł̎c�莞�Ԃ�\��
        }
    }

    void DisplayGameStart()//�Q�[���J�n�̕�����\��
    {
        if(judgeGameStart.IsStarted_Moment)//�Q�[�����J�n���ꂽ�u��
        {
            countDownText.text = startText;//�Q�[���J�n�̕������o��
            audioSource.PlayOneShot(gameStartSoundEffect);//�Q�[���J�n���̌��ʉ����o��
        }
        
        remainingdisplayTime_GameStart -= Time.deltaTime;//�Q�[���J�n�̕������o���c�莞�Ԃ��X�V

        if(remainingdisplayTime_GameStart<=0)//�Q�[���J�n�̕������o���c�莞�Ԃ��Ȃ��Ȃ�����
        {
            countDownText.enabled = false;//�������\��
        }
    }

    void DisplayRemainingTime()//�J�n�܂ł̎c�莞�Ԃ�\��
    {
        int remainingGameStartTime_Display = (int)Mathf.Ceil(judgeGameStart.RemainingGameStartTime);//�\������c�莞��(�Ⴆ��3�`2.00...1�Ȃ�3�A2�`1.00...1�Ȃ�2�ɂȂ�)

        //�O�t���[���ƕ\������c�莞�Ԃ��������(�ς���Ă�����)���ʉ����o��
        if(remainingGameStartTimeBeforeFrame_Display!=remainingGameStartTime_Display)
        {
            audioSource.PlayOneShot(countDownSoundEffect);//�Q�[���J�n���̌��ʉ����o��
        }

        countDownText.text = remainingGameStartTime_Display.ToString("0"); 

        remainingGameStartTimeBeforeFrame_Display=remainingGameStartTime_Display;
    }
}
