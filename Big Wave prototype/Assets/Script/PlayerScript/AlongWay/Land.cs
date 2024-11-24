using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//���e���̌��ʉ��ƓG�̔�_�����[�V�����̃Z�b�g�̏������ꎞ�I�ɔ����Ă܂�
public class Land : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip_Critical;
    [SerializeField] AudioClip clip_Normal;
    [SerializeField] AudioClip clip_Fever;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    void Start()
    {
        generate_AlongWay.NormalTrickEffect.LandAction += LandEffect_Normal;
        generate_AlongWay.CriticalTrickEffect.LandAction += LandEffect;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += LandEffect_Fever;
    }

     public void LandEffect_Normal()//�ʏ펞
    {
        source.PlayOneShot(clip_Normal);
    }
    public void LandEffect()//�N���e�B�J����
    {
        
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip_Critical);
    }
    public void LandEffect_Fever()//�t�B�[�o�[��
    {
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip_Fever);
    }
   
}
