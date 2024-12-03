using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSoundEffect : MonoBehaviour
{
    [Header("�N���e�B�J�����̌��ʉ�")]
    [SerializeField] AudioClip criticalSE;//�N���e�B�J�����̌��ʉ�
    [Header("�ʏ��Ԃ̌��ʉ�")]
    [SerializeField] AudioClip normalSE;//�ʏ��Ԃ̌��ʉ�
    [Header("�ő�s�b�`")]
    [SerializeField] float pitchMax;
    [Header("�㏸�s�b�`��")]
    [SerializeField] float pitchUp;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Critical critical;
  
    private float startPitch;
    private void Start()
    {
       startPitch= audioSource.pitch;
    }
    public void PlayTrickSE()//�N���e�B�J���󋵂ɂ���Ė炷����ς���
    {
        AudioClip se=critical.CriticalNow ? criticalSE: normalSE;
        if (critical.CriticalNow&&audioSource.pitch<pitchMax)
        {
            audioSource.pitch += pitchUp;
        }
        else if(!critical.CriticalNow)
        {
          audioSource.pitch =startPitch ;
        }
        audioSource.PlayOneShot(se);
    }
}
