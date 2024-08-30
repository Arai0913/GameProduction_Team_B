using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//X�{�^�����������Ƃ��̃g���b�N�p�^�[���̌���
public class TrickPatternTypeX : TrickPatternTypeBase
{
    [Header("�g���b�N�ɗp������ʉ�")]
    [SerializeField] AudioClip soundEffect;//�g���b�N�ɗp������ʉ�
    [Header("�G�ɗ^����_���[�W")]
    [SerializeField] float damageAmount = 100;//�G�ɗ^����_���[�W
    [Header("���𗬂����߂̃R���|�[�l���g")]
    [SerializeField] AudioSource audioSource;
    HP enemy_Hp;
    FeverMode feverMode;
    Critical critical;

    void Start()
    {
        button = Button.X;//�{�^��A��ݒ�
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        feverMode = GameObject.FindWithTag("Player").GetComponent<FeverMode>();
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
    }

    public override void TrickEffect()//�g���b�N�̌���
    {
        base.TrickEffect();
        audioSource.PlayOneShot(soundEffect);//���ʉ����Đ�
        enemy_Hp.Hp -= TotalDamageAmount();//�G�Ƀ_���[�W��^����
    }

    float TotalDamageAmount()//�_���[�W���v���Z�o
    {
        float damage = damageAmount;//��{�_���[�W(�����ꂽ�{�^���ɑΉ��������݂̃g���b�N�p�^�[������擾)
        damage *= feverMode.CurrentPowerUp_GrowthRate;//�t�B�[�o�[���[�h�̃_���[�W���Z
        damage *= critical.CriticalDamageRate(button);//�N���e�B�J���_���[�W�̉��Z
        return damage;
    }
}
