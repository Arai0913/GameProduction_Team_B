using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���X�^�[�g���̃J�E���g�_�E��
public class JudgeGameStart : MonoBehaviour
{
    [Header("��ʑJ�ڂ��Ă��牽�b�ŃQ�[�����J�n���邩")]
    [SerializeField] float gameStartTime;//��ʑJ�ڂ��Ă��牽�b�ŃQ�[�����J�n���邩
    private float remainingGameStartTime;//���݂̃Q�[���J�n�܂ł̎c�莞��
    private bool isStarted = false;//�Q�[�����J�n���ꂽ��(�J�E���g�_�E���͏I�������)
    private bool isStarted_Moment=false;//�Q�[�����J�n���ꂽ�u��(�J�E���g�_�E���͏I������u��)
    private bool isStartedBeforeFrame=false;//�O�̃t���[����isStarted

    public float RemainingGameStartTime { get { return remainingGameStartTime; } }

    public bool IsStarted { get { return isStarted; } }

    public bool IsStarted_Moment { get { return isStarted_Moment; } }

    void Start()
    {
        remainingGameStartTime = gameStartTime;//���݂̃Q�[���J�n�܂ł̎c�莞�Ԃ�ݒ�
    }

    void Update()
    {
        UpdateCountDownTime();
        UpdateIsStarted_Moment();
        isStartedBeforeFrame = isStarted;
    }

    //�Q�[���J�n�܂ł̎c�莞�Ԃ̍X�V
    //�c��0�b�ɂȂ�����Q�[�����J�n����悤�ɂ���
    void UpdateCountDownTime()
    {
        if (isStarted) return;//�Q�[�����J�n���ꂽ��c�莞�Ԃ̍X�V�����Ȃ�
        //�Q�[�����J�n����Ă��Ȃ��ԁA�c�莞�Ԃ��X�V
       
        remainingGameStartTime -= Time.deltaTime;

        if(remainingGameStartTime<=0) isStarted = true;//�c�莞�Ԃ�0�ȉ��ɂȂ�����Q�[���J�n
    }

    //�Q�[�����J�n���ꂽ�u�Ԃ̍X�V
    void UpdateIsStarted_Moment()
    {
        //�O�̃t���[���ł܂��Q�[���J�n����ĂȂ������݂̃t���[���ŊJ�n����Ă�����Q�[�����J�n���ꂽ�u�Ԃ�true�ɂ���
        if(!isStartedBeforeFrame&&isStarted)
        {
            isStarted_Moment = true;
        }
        else
        {
            isStarted_Moment = false;
        }
    }
}
