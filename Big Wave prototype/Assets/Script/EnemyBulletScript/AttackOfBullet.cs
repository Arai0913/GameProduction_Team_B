using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�ɓ����������̏���
public class AttackOfBullet : MonoBehaviour
{
    [Header("�_���[�W��")]
    [SerializeField] float damage;//�_���[�W��
    [Header("�v���C���[�ɓ����������ɒe��������")]
    [SerializeField] bool ifHitDestroy=true;//�v���C���[�ɓ����������ɒe��������
    [Header("�����������̌��ʉ�")]
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    bool hit=false;//����������

    void HitTrigger(Collider t)//�����������̏���
    {
        if (t.gameObject.CompareTag("Player")&&!hit)
        {
            //�v���C���[�Ƀ_���[�W��^����
            HP player_Hp;
            player_Hp = t.GetComponent<HP>();
            player_Hp.Hp -= damage;

            //���ʉ��𗬂�
            if(audioClip!=null&&audioSource!=null)
            {
                audioSource.PlayOneShot(audioClip);
            }

            hit = true;

            if (ifHitDestroy)//true�������������e��������
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider t)
    {
       HitTrigger(t);
    }
}
