using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//�쐬��:���R
//���[�r�[�̏�Ԃ����Z�b�g����
public class MovieReset : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;

    public void ResetMovie()
    {
        _videoPlayer.frame = 0;
        _videoPlayer.Pause();
    }
}
