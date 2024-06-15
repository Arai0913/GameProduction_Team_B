using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffOfPlayer : MonoBehaviour
{
    [Header("�U���̓A�b�v�̃o�t�̌��ʎ���(�b)")]
    [SerializeField] float powerUpBuffTime = 20f;//�U���̓A�b�v�̃o�t�̌��ʎ���(�b)
    [Header("�U���͑�����(�{��)")]
    [SerializeField] float powerUpGrowthRate=1;//�U���͑�����(�{��)
    [Header("�U���̓A�b�v�̃o�t���̃G�t�F�N�g")]
    [SerializeField] GameObject powerUpBuffEffect;//�U���̓A�b�v�̃o�t���̃G�t�F�N�g
    [Header("�`���[�W�g���b�N�ʑ����̃o�t�̌��ʎ���(�b)")]
    [SerializeField] float chargeTrickBuffTime = 20f;//�`���[�W�g���b�N�ʑ����̃o�t�̌��ʎ���(�b)
    [Header("�`���[�W�g���b�N�ʑ�����(�{��)")]
    [SerializeField] float chargeTrickGrowthRate=1;//�`���[�W�g���b�N�ʑ�����(�{��)
    [Header("�`���[�W�g���b�N�ʑ����̃o�t�̃G�t�F�N�g")]
    [SerializeField] GameObject chargeTrickBuffEffect;//�`���[�W�g���b�N�ʑ����̃o�t�̃G�t�F�N�g
    private float currentPowerUpGrowthRate = 1f;//���݂̍U���͑�����(�{��)�A�o�t���������ĂȂ�����1�A�������Ă���Ƃ���powerUpGrowthRate�ɂȂ�
    private float currentChargeTrickGrowthRate = 1f;//���݂̃`���[�W�g���b�N�ʑ�����(�{��)�A�o�t���������ĂȂ�����1�A�������Ă���Ƃ���chargeTrickGrowthRate�ɂȂ�
    private float powerUpBuffRemainingTime = 0f;//�U���̓A�b�v�̃o�t���ʂ̎c�莞��(�b)
    private float chargeTrickBuffRemainingTime = 0f;//�`���[�W�g���b�N�ʑ����̃o�t���ʂ̎c�莞��(�b)

    public float CurrentPowerUpGrowthRate
    {
        get { return currentPowerUpGrowthRate; }
    }

    public float CurrentChargeTrickGrowthRate
    {
        get {return currentChargeTrickGrowthRate; }
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUpBuffEffect.SetActive(false);
        chargeTrickBuffEffect.SetActive(false);
        currentPowerUpGrowthRate = 1f;
        currentChargeTrickGrowthRate = 1f;
        powerUpBuffRemainingTime = 0f;
        chargeTrickBuffRemainingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpBuffEffectTime();//�U���̓A�b�v�o�t�̎��Ԃƌ��ʂ��Ǘ�

        ChargeTrickBuffEffectTime();//�`���[�W�g���b�N�ʑ����o�t�̎��Ԃƌ��ʂ��Ǘ�
    }

    void PowerUpBuffEffectTime()//�U���̓A�b�v�o�t�̎��Ԃƌ��ʂ��Ǘ�
    {
        powerUpBuffRemainingTime -= Time.deltaTime;

        if(powerUpBuffRemainingTime>0)
        {
            currentPowerUpGrowthRate = powerUpGrowthRate;
            powerUpBuffEffect.SetActive(true);
        }
        else
        {
            currentPowerUpGrowthRate = 1;
            powerUpBuffEffect.SetActive(false);
        }
    }

    void ChargeTrickBuffEffectTime()//�`���[�W�g���b�N�ʑ����o�t�̎��Ԃƌ��ʂ��Ǘ�
    {
        chargeTrickBuffRemainingTime -= Time.deltaTime;

        if(chargeTrickBuffRemainingTime>0)
        {
            currentChargeTrickGrowthRate = chargeTrickGrowthRate;
            chargeTrickBuffEffect.SetActive(true);
        }
        else
        {
            currentChargeTrickGrowthRate= 1;
            chargeTrickBuffEffect.SetActive(false);
        }
    }

    public void PowerUpBuff()//�U���̓A�b�v�̃o�t�������鎞�ɌĂяo��
    {
        powerUpBuffRemainingTime = powerUpBuffTime;
    }

    public void ChargeTrickBuff()//�`���[�W�g���b�N�ʑ����̃o�t�������鎞�ɌĂяo��
    {
        chargeTrickBuffRemainingTime= chargeTrickBuffTime;
    }
}
