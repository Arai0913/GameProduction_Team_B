using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff//�o�t
{
    [Header("���ʎ���(�b)")]
    [SerializeField] float buffTime = 5f;//�o�t�̌��ʎ���(�b)
    [Header("�o�t�̃G�t�F�N�g")]
    [SerializeField] GameObject buffEffect;//�o�t�̃G�t�F�N�g

    private float buffRemainingTime = 0f;//�o�t���ʂ̎c�莞��(�b)

    public float BuffTime
    {
        get { return buffTime; }
    }

    public GameObject BuffEffect
    {
        get { return buffEffect; }
    }

    public float BuffRemainingTime
    {
        get { return buffRemainingTime; }
        set { buffRemainingTime = value; }
    }
}

[System.Serializable]
public class UpBuff : Buff//�����n�̃o�t
{
    [Header("������(�{��)")]
    [SerializeField] float growthRate = 1;//������(�{��)
    private float currentGrowthRate = 1f;//���݂̑�����

    public float GrowthRate
    {
        get { return growthRate; }
    }

    public float CurrentGrowthRate
    {
        get { return currentGrowthRate; }
        set { currentGrowthRate = value; }
    }

}

public class BuffOfPlayer : MonoBehaviour
{
    [Header("�U���̓A�b�v�̃o�t")]
    [SerializeField] UpBuff powerUp;//�U���̓A�b�v�̃o�t
    [Header("�`���[�W�g���b�N�����̃o�t")]
    [SerializeField] UpBuff chargeTrick;//�`���[�W�g���b�N�����̃o�t

    public UpBuff PowerUp
    {
        get { return powerUp; }
    }

    public UpBuff ChargeTrick
    {
        get { return chargeTrick; }
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUp.BuffEffect.SetActive(false);
        powerUp.CurrentGrowthRate = 1f;
        powerUp.BuffRemainingTime = 0f;

        chargeTrick.BuffEffect.SetActive(false);
        chargeTrick.CurrentGrowthRate = 1f;
        chargeTrick.BuffRemainingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpBuffEffectTime(powerUp);//�U���̓A�b�v�o�t�̎��Ԃƌ��ʂ��Ǘ�

        UpBuffEffectTime(chargeTrick);//�`���[�W�g���b�N�ʑ����o�t�̎��Ԃƌ��ʂ��Ǘ�
    }

    void UpBuffEffectTime(UpBuff upBuff)//�����n�o�t�̎��Ԃƌ��ʂ��Ǘ�
    {
        upBuff.BuffRemainingTime -= Time.deltaTime;

        if(upBuff.BuffRemainingTime>0)
        {
            upBuff.CurrentGrowthRate = upBuff.GrowthRate;
            upBuff.BuffEffect.SetActive(true);
        }
        else
        {
            upBuff.CurrentGrowthRate = 1;
            upBuff.BuffEffect.SetActive(false);
        }
    }

    public void PowerUpBuff()//�U���̓A�b�v�̃o�t�������鎞�ɌĂяo��
    {
        powerUp.BuffRemainingTime = powerUp.BuffTime;
    }

    public void ChargeTrickBuff()//�`���[�W�g���b�N�ʑ����̃o�t�������鎞�ɌĂяo��
    {
        chargeTrick.BuffRemainingTime= chargeTrick.BuffTime;
    }
}
