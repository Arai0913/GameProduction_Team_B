using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R����
//�Q�[���X�^�[�g���̃X�^�[�g�̏u�Ԃ̉��o
public class DisplayStart_GameStart : MonoBehaviour
{
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text countDownText;//�\��������e�L�X�g
    [Header("�Q�[���J�n���ɕ\�����镶��")]
    [SerializeField] string startText;//�Q�[���J�n���ɕ\�����镶��
    [Header("�Q�[���J�n�̕������o������")]
    [SerializeField] float displayTime_GameStart;//�Q�[���J�n�̕������o������
    [Header("�Q�[���J�n�����u�Ԃɏo�����ʉ�")]
    [SerializeField] AudioClip gameStartSoundEffect;//�Q�[���J�n�����u�Ԃɏo�����ʉ�
    private float remainingdisplayTime_GameStart;//�Q�[���J�n�̕������o���c�莞��
    JudgeGameStart judgeGameStart;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        judgeGameStart = GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
        audioSource = GetComponent<AudioSource>();
        remainingdisplayTime_GameStart = displayTime_GameStart;//�Q�[���J�n�̕������o���c�莞�Ԃ�ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGameStart();
    }

    public void DisplayGameStart_Moment()//�Q�[���J�n�����u�ԂɈ�x�����Ă΂�鏈��
    {
        countDownText.text = startText;//�Q�[���J�n�̕������o��
        audioSource.PlayOneShot(gameStartSoundEffect);//�Q�[���J�n���̌��ʉ����o��
    }

    void DisplayGameStart()//�Q�[�����J�n���Ă��炵�΂炭�Q�[���X�^�[�g�̕�������ʂɕ\������
    {
        bool display = countDownText.enabled;//������\�����Ă��邩

        if (!(judgeGameStart.IsStarted)||!display) return;//�Q�[�����J�n���Ă��Ȃ��������͕�������\���ɂȂ��Ă��鎞�ȉ��̏������Ă΂Ȃ�

        remainingdisplayTime_GameStart -= Time.deltaTime;//�Q�[���J�n�̕������o���c�莞�Ԃ��X�V

        if (remainingdisplayTime_GameStart <= 0)//�Q�[���J�n�̕������o���c�莞�Ԃ��Ȃ��Ȃ�����
        {
            countDownText.enabled = false;//�������\��
        }
    }
}
