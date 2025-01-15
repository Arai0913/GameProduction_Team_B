using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class FadeInAfterMovie : MonoBehaviour
{
    [Header("����Đ���A�N�e�B�u�ɂ���(�Đ����͔�A�N�e�B�u)�I�u�W�F�N�g")]
    [SerializeField] GameObject[] _activeAfterMovieEnd;//����Đ���A�N�e�B�u�ɂ���(�Đ����͔�A�N�e�B�u)�I�u�W�F�N�g
    [Header("����Đ����ɂ̂݃A�N�e�B�u�ɂ���I�u�W�F�N�g")]
    [SerializeField] GameObject[] _activeDuringMovieObject;//����Đ����ɂ̂݃A�N�e�B�u�ɂ���I�u�W�F�N�g
    [SerializeField] FadeIn_RawImage _fadeIn;
    [SerializeField] VideoPlayer videoPlayer;
    [Header("���֌W")]
    [Header("�ǂ��炩����ɂ���΍Đ��I�����ɉ�����Ȃ��悤�ɂȂ�")]
    [SerializeField] AudioClip _se;
    [SerializeField] AudioSource _audioSource;
    [Header("����֌W")]
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] string _actionMapNameAfterMovie;
    [Header("�X�L�b�v���ɓ���I���̉��b�O�܂Ŕ�΂���")]
    [Header("0�ɂ��Ă��܂��Ɠ��悪�Ō�܂ōĐ�����Ȃ����Ƃ�����܂�")]
    [SerializeField] double _skipTimeBeforeEnd;

    bool _movieEnded=false;//���[�r�[���I��������

    public void Skip()
    {
        if (_movieEnded) return;//���[�r�[�����ɏI�����Ă�Ȃ�X�L�b�v

        _movieEnded = true;

        //������X�L�b�v������
        videoPlayer.time = videoPlayer.length- _skipTimeBeforeEnd;
    }

    void Start()
    {
        Trigger();
    }

    void Trigger()//���[�r�[�J�n�̃g���K�[
    {
        //�Đ���A�N�e�B�u�ɂ���I�u�W�F�N�g����U�B��
        for(int i=0; i<_activeAfterMovieEnd.Length ;i++)
        {
            _activeAfterMovieEnd[i].SetActive(false);
        }

        //�Đ����A�N�e�B�u�ɂ���I�u�W�F�N�g��\��
        for(int i=0; i<_activeDuringMovieObject.Length ;i++)
        {
            _activeDuringMovieObject[i].SetActive(true);
        }


        //���[�r�[�𗬂��n�߂�
        videoPlayer.Play();
        videoPlayer.loopPointReached += MovieEndEvent;
    }

    void MovieEndEvent(VideoPlayer vb)//���[�r�[������I��������ɋN�����C�x���g
    {
        _movieEnded = true;

        //�Đ���A�N�e�B�u�ɂ���I�u�W�F�N�g��\��
        for (int i = 0; i < _activeAfterMovieEnd.Length; i++)
        {
            _activeAfterMovieEnd[i].SetActive(true);
        }

        //�Đ����A�N�e�B�u�ɂ���I�u�W�F�N�g���B��
        for (int i = 0; i < _activeDuringMovieObject.Length; i++)
        {
            _activeDuringMovieObject[i].SetActive(false);
        }

        //�t�F�[�h�C���J�n
        _fadeIn.StartTrigger();

        //��������[�r�[�̂��̂���UI�ɂ���
        _playerInput.SwitchCurrentActionMap(_actionMapNameAfterMovie);

        //�����o��
        if(_audioSource!=null&&_se!=null)
        {
            _audioSource.PlayOneShot(_se);
        }
        
    }
}
