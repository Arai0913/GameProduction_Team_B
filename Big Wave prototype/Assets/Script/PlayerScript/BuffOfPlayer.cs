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

    private float buffRemainingTime = 0f;//�o�t�̎c����ʎ���(�b)�A���ꂪ0�b�ȉ��ɂȂ�����o�t�̌��ʂ��؂��悤�ɂ���
    private bool activateNow = false;//�o�t���ʔ�������

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
    }

    public bool ActivateNow
    {
        get { return activateNow; }
    }

    public virtual void Buff_Start()//Start�ŌĂԏ���
    {
        buffRemainingTime = 0f;
        activateNow = false;
    }
    
    //�o�t�̎c����ʎ��Ԃ̊Ǘ�
    public void EffectTime()
    {
        buffRemainingTime-=Time.deltaTime;

        if(buffRemainingTime<=0f)//�o�t���ʐ؂�
        {
            activateNow = false;
        }
    }

    //�o�t�𔭓�������(�o�t����������)���ɂ�����Ă�
    public void Activate()
    {
        activateNow=true;//�o�t���ʔ������ɂ���
        buffRemainingTime = buffTime;
    }

    //�o�t������
    public void Deactivate()
    {
        activateNow=false;
        buffRemainingTime = 0f;
    }
}

[System.Serializable]
public class UpBuff : Buff//�����n�̃o�t
{
    [Header("������(�{��)")]
    [SerializeField] float growthRate = 1;//������(�{��)
    private float currentGrowthRate = 1f;//���݂̑�����

    public override void Buff_Start()
    {
        base.Buff_Start();
        currentGrowthRate = 1f;
    }

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
        powerUp.Buff_Start();
        chargeTrick.Buff_Start();
    }

    // Update is called once per frame
    void Update()
    {
        //�U���̓A�b�v�o�t
        powerUp.EffectTime();
        UpBuffEffect(powerUp);

        //�`���[�W�g���b�N�ʑ����o�t
        chargeTrick.EffectTime();
        UpBuffEffect(chargeTrick);
    }

    void UpBuffEffect(UpBuff upBuff)//�A�b�v�n�̃o�t�̔������̌���
    {
        if(upBuff.ActivateNow)//������
        {
            upBuff.CurrentGrowthRate=upBuff.GrowthRate;
            upBuff.BuffEffect.SetActive(true);
        }
        else//�������Ă��Ȃ���
        {
            upBuff.CurrentGrowthRate = 1f;
            upBuff.BuffEffect.SetActive(false);
        }
    }

}
