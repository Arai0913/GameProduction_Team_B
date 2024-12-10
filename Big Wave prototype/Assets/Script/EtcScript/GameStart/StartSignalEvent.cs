using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�^�[�g�̍��}
public class StartSignalEvent : MonoBehaviour
{
    [Header("�t�F�[�h�C���̐ݒ�")]
    [SerializeField] FadeIn _fadeIn;
    [Header("�t�F�[�h�A�E�g���������Ă���t�F�[�h�C�����J�n����܂ł̎���")]
    [SerializeField] float _startFadeInTime;
    [Header("�t�F�[�h�C�����������Ă���Q�[���J�n�܂ł̎���")]
    [SerializeField] float _startGameTime;
    [SerializeField] DisplayStart_GameStart gameStart;
   
    float _currentStartGameTime = 0;
    float _currentStartFadeInTime=0;
    State_GameStartSignal _state = State_GameStartSignal.off;//���}�̏�

    public State_GameStartSignal State {  get { return _state; } }

    public void Trigger()//�X�^�[�g�̍��}�̊J�n
    {
        //���}�������Ă��Ȃ���ԂłȂ���Ζ���(��x�J�n�����炱�̏����͓�x�ƌĂׂȂ�)
        if (_state != State_GameStartSignal.off) return;

        _state = State_GameStartSignal.fadeIn;
    }

    void Update()
    {
        ShowSignal();
    }

    void ShowSignal()
    {
        if (_state == State_GameStartSignal.completed) return;

        switch(_state)
        {
            case State_GameStartSignal.fadeIn://�t�F�[�h�C����

                //�����҂��Ă���t�F�[�h�C�����n�߂�
                _currentStartFadeInTime += Time.deltaTime;

                if(_currentStartFadeInTime>=_startFadeInTime&&_fadeIn.State==State_Fade.off)
                {
                    _fadeIn.StartTrigger();
                }

                //�t�F�[�h�C��������������X�^�[�g�̍��}������
                if(_fadeIn.State==State_Fade.completed)
                {
                    _fadeIn.ReturnDefault();
                    _state = State_GameStartSignal.playing;
                    gameStart.DisplayTrigger();
                }

                break;


            case State_GameStartSignal.playing://���}��

                _currentStartGameTime += Time.deltaTime;

                if(_currentStartGameTime>=_startGameTime)//���}���I������獇�}������Ԃɂ���
                {
                    _state = State_GameStartSignal.completed;
                   
                }

                break;
        }
    }
}
