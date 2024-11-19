using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSoundEffect : MonoBehaviour
{
    [Header("�N���e�B�J�����̌��ʉ�")]
    [SerializeField] AudioClip criticalSE;//�N���e�B�J�����̌��ʉ�
    [Header("�ʏ��Ԃ̌��ʉ�")]
    [SerializeField] AudioClip normalSE;//�ʏ��Ԃ̌��ʉ�
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Critical critical;

    void Start()
    {
        critical.CriticalAction += PlayTrickSE;
    }

    public void PlayTrickSE(bool critical)//�N���e�B�J���󋵂ɂ���Ė炷����ς���
    {
        AudioClip se=critical? criticalSE: normalSE;
        audioSource.PlayOneShot(se);
    }
}
