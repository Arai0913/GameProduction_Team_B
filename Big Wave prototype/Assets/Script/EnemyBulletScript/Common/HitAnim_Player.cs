using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɔ�e���[�V����������
[System.Serializable]
public class HitAnim_Player
{
    [Header("�_���[�W�����̖��O")]
    [SerializeField] string damageParaName;//�_���[�W�����̖��O

    public void DamageMotionTrigger(Collider p)//�v���C���[�̃_���[�W���[�V����
    {
        Animator playerAnimator;
        playerAnimator=p.GetComponentInChildren<Animator>();

        playerAnimator.SetTrigger(damageParaName);
    }
}
