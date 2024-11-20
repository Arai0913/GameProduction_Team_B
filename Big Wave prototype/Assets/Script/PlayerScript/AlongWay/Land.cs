using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���e���̌��ʉ��ƓG�̔�_�����[�V�����̃Z�b�g�̏������ꎞ�I�ɔ����Ă܂�
public class Land : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    void Start()
    {
        generate_AlongWay.CriticalTrickEffect.LandAction += LandEffect;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += LandEffect;
    }

    public void LandEffect()
    {
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip);
    }
}
