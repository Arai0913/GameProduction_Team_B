using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class SkipVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] PlayerInput _playerInput;
    bool _skipped = false;
    const string _actionMapNameAfterSkip = "UI";

    public void Skip()
    {
        if(_skipped) return;

        _skipped = true;

        //������X�L�b�v������
        _videoPlayer.time = _videoPlayer.length-0.5; // �Đ��ʒu���I�����_�ɐݒ�

        //��������[�r�[�̂��̂���UI�ɂ���
        _playerInput.SwitchCurrentActionMap(_actionMapNameAfterSkip);
    }
}
