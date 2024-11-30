using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//�쐬��:���R
//�Q�[���X�^�[�g���̃J�E���g�_�E��
public class JudgeGameStart : MonoBehaviour
{
    [Header("��ʑJ�ڂ��Ă��牽�b�ŃQ�[�����J�n���邩")]
    [SerializeField] float gameStartTime;//��ʑJ�ڂ��Ă��牽�b�ŃQ�[�����J�n���邩
    public event Action StartGameAction;//�Q�[���J�n���ɌĂԏ���
    private float remainingGameStartTime;//���݂̃Q�[���J�n�܂ł̎c�莞��
    private bool isStarted = false;//�Q�[�����J�n���ꂽ��(�J�E���g�_�E���͏I�������)
    private bool isStartedBeforeFrame=false;//�O�̃t���[����isStarted

    public float RemainingGameStartTime { get { return remainingGameStartTime; } }

    public bool IsStarted { get { return isStarted; } }

    void Start()
    {
        remainingGameStartTime = gameStartTime;//���݂̃Q�[���J�n�܂ł̎c�莞�Ԃ�ݒ�
    }

    void Update()
    {
        UpdateGameStart();

        //�O�̃t���[���ł܂��Q�[���J�n����ĂȂ������݂̃t���[���ŊJ�n����Ă�����Q�[���J�n�u�Ԃ̏������s��
        if(!isStartedBeforeFrame&&isStarted)
        {
            StartGameAction?.Invoke();
        }

        isStartedBeforeFrame = isStarted;//�O�̃t���[���̃Q�[���J�n�󋵂��L�^
    }

    //�Q�[���J�n�󋵂̍X�V
    //�c��0�b�ɂȂ�����Q�[���J�n����
    void UpdateGameStart()
    {
        if (isStarted) return;//�Q�[�����J�n���ꂽ��c�莞�Ԃ̍X�V�����Ȃ�
        //�Q�[�����J�n����Ă��Ȃ��ԁA�c�莞�Ԃ��X�V
       
        remainingGameStartTime -= Time.deltaTime;

        if(remainingGameStartTime<=0) isStarted = true;//�c�莞�Ԃ�0�ȉ��ɂȂ�����Q�[���J�n
    }
}
