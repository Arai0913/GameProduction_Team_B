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
    [SerializeField] AudioSource audioSource;
    private float remainingdisplayTime_GameStart;//�Q�[���J�n�̕������o���c�莞��
    bool displayStart = false;//�X�^�[�g�̕�����\������t���O

    void Update()
    {
        DisplayGameStart();
    }

    public void DisplayTrigger()//�Q�[���J�n�����u�ԂɈ�x�����Ă΂�鏈��
    {
        countDownText.text = startText;//�Q�[���J�n�̕����ɂ���
        audioSource.PlayOneShot(gameStartSoundEffect);//�Q�[���J�n���̌��ʉ����o��
        displayStart = true;//�t���O��ON�ɂ���
        remainingdisplayTime_GameStart = displayTime_GameStart;//�Q�[���J�n�̕������o���c�莞�Ԃ�ݒ�
        countDownText.enabled = true;//������\��
    }

    void DisplayGameStart()//�Q�[�����J�n���Ă��炵�΂炭�Q�[���X�^�[�g�̕�������ʂɕ\������
    {
        if (!displayStart) return;//�X�^�[�g�̕�����\�����Ȃ��Ԃ͖���

        remainingdisplayTime_GameStart -= Time.deltaTime;//�Q�[���J�n�̕������o���c�莞�Ԃ��X�V

        if (remainingdisplayTime_GameStart <= 0)//�Q�[���J�n�̕������o���c�莞�Ԃ��Ȃ��Ȃ�����
        {
            countDownText.enabled = false;//�������\��
            displayStart = false;//�t���O��OFF�ɂ���
        }
    }
}
