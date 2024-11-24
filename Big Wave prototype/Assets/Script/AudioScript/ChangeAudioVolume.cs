using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//�쐬��:���R
//���ʂ��o�[�Œ��߂���
public class ChangeAudioVolume : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    [Header("���ʂ̖��O")]
    [SerializeField] string _audioTypeName;
    [Header("���ߗp�X���C�_�[")]
    [SerializeField] Slider _slider;

    void Start()
    {
        //�o�[�̒l�Ɍ��݂̉��ʂ�����
        _audioMixer.GetFloat(_audioTypeName, out float audioVolume);
        _slider.value = audioVolume;
    }

   public void SetAudioVolume(float volume)
    {
        _audioMixer.SetFloat(_audioTypeName, volume);
    }
}
