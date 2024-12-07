using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//�쐬��:���R
//���[�r�[�̃J�����̏���
public class MovieCameraEvent : MonoBehaviour
{
    [Header("�Q�[������UI")]
    [SerializeField] GameObject _duringGameUI;
    [Header("���[�r�[�̃J����")]
    [Tooltip("�J�����̗D��x�̓Q�[�����̃J�������������ݒ肵�Ēu���Ă�������")]
    [SerializeField] CinemachineBlendListCamera _movieCamera;
    [Header("���[�r�[�̎���")]
    [Tooltip("���̎��ԕ��o������t�F�[�h�A�E�g���n�܂�܂�")]
    [SerializeField] float _movieTime;
    [Header("�t�F�[�h�C���̐ݒ�")]
    [SerializeField] FadeIn _fadeIn;
    [Header("�t�F�[�h�A�E�g�̐ݒ�")]
    [SerializeField] FadeOut _fadeOut;
    float _currentMovieTime;//���[�r�[�̌��݂̎���
    const float _defaultCurrentMovieTime= 0;
    //���[�r�[�̍Đ���
    //��{�̓��[�r�[�������Ă��Ȃ�
    //->�Đ���(�Đ����閽�߂���������)->
    //�I����(�I�����閽�߂��������A�������͎��Ԍo�߂Ŏ����I�ɂ����Ȃ�����)
    //->���[�r�[�������Ă��Ȃ�(�I���������I�������)
    State_Movie _state = State_Movie.off;

    public State_Movie State { get { return _state; } }

    public void Trigger()//���[�r�[�̊J�n
    {
        //���[�r�[�������Ă��Ȃ���ԂłȂ���Ζ���
        if (_state!=State_Movie.off) return;

        //�t�F�[�h�C�����J�n���A
        //�Q�[������UI���\���ɂ��A
        //�J���������[�r�[�p�̂��̂ɐ؂�ւ���
        _currentMovieTime = _defaultCurrentMovieTime;
        _state = State_Movie.playing;//�Đ����Ă����Ԃɂ���
        _fadeIn.StartTrigger();
        _duringGameUI.SetActive(false);
        _movieCamera.enabled = true;
    }

    public void End()//���[�r�[�̏I��(���[�r�[�X�L�b�v���ɂ�����Ă�)
    {
        //���[�r�[�Đ����łȂ���Ζ���
        if (_state != State_Movie.playing) return;

        //�t�F�[�h�C���𒆒f��
        //�t�F�[�h�A�E�g���J�n(�t�F�[�h�A�E�g�����S�ɏI������烀�[�r�[�������Ă��Ȃ���Ԃɂ���)
        _state = State_Movie.ending;//�I�����Ă����Ԃɂ���
        _fadeIn.CancelTrigger();
        _fadeIn.ReturnDefault();
        _fadeOut.StartTrigger();
    }

    void Update()
    {
       UpdateState();
    }

    void UpdateState()//���[�r�[�̍Đ��󋵂̍X�V
    {
        if (_state == State_Movie.off) return;//���[�r�[�������Ă��Ȃ����͓��ɍX�V�͂��Ȃ�

        switch(_state)
        {
            case State_Movie.playing://�Đ���

                //���[�r�[�̎��Ԃ̍X�V(���ԂɂȂ�����I����Ԃɓ���)
                _currentMovieTime += Time.deltaTime;

                if(_currentMovieTime>=_movieTime)
                {
                    End();
                }

                break;


            case State_Movie.ending://�I����

                //�t�F�[�h�A�E�g���I������烀�[�r�[�������Ă��Ȃ����(�������)�ɖ߂�
                if (_fadeOut.FadeState == State_Fade.completed)
                {
                    _fadeOut.ReturnDefault();
                    _movieCamera.enabled = false;//���[�r�[�̃J�������I�t�ɂ���
                    _duringGameUI.SetActive(true);//�Q�[������UI��\����Ԃɂ���
                    _state = State_Movie.off;
                }

                break;
        }
    }
}
