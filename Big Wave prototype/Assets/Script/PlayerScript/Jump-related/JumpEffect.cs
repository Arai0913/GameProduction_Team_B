using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] GameObject _waterSplashEffect;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _jumpSE;

    void Start()
    {
        _judgeJumpNow.SwitchJumpNowAction += Effect;
    }

    public void Effect(bool switchJumpNow)
    {
        _waterSplashEffect.SetActive(!switchJumpNow);//�����Ԃ����W�����v�J�n���ɏ����A���n���ɏo��

        //�W�����v�J�n
        if (switchJumpNow)
        {
            _audioSource.PlayOneShot(_jumpSE);//�W�����v�̌��ʉ���炷
        }
        //���n��
        else
        {

        }
    }
}
