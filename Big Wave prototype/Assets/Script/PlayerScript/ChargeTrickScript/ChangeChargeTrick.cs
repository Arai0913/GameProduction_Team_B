using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrick : MonoBehaviour
{
    [Header("�ő�܂ł��܂�₷���Ȃ������̔{��(�ő�{��)")]
    [SerializeField] float chargeRateMax=1;//�ő�{��
    [Header("�ő�{���ɂȂ�܂łɂ����鎞��")]
    [SerializeField] float byRateMaxTime=10;//�ő�{���ɂȂ�܂łɂ����鎞��
    private float currentChargeRate=1f;//���݂̔{��
    private float curremtChangeChargeRateTime=0;//�{�����ω����Ă��鎞��

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;
    ChangeChargeTrickEffect changeChargeTrickEffect;

    public float CurrentChargeRate
    {
        get { return currentChargeRate; }
    }

    public float ChargeRateMax
    {
        get { return chargeRateMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();
        changeChargeTrickEffect = GetComponent<ChangeChargeTrickEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChargeRate();
    }

    bool ChangeChargeRateNow()//�g�ɐG��Ă��邩�W�����v���Ă��鎞�ɔ{�����ω�����悤�ɂ���
    {
        if(jumpControl.JumpNow||judgeTouchWave.TouchWaveNow)
        {
            return true; 
        }
       
        return false;
    }

    void ChangeChargeRate()
    {
        //�g�ɐG��Ă��邩�W�����v���Ă��鎞�AbyRateMaxTime�����Ĕ{����1�{����chargeRateMax�{�܂ŕω�����
        if (ChangeChargeRateNow())
        {
            curremtChangeChargeRateTime += Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);

            currentChargeRate = 1 + (chargeRateMax - 1) *RatioOfChargeRate();
            currentChargeRate = Mathf.Clamp(currentChargeRate,1,chargeRateMax);

            changeChargeTrickEffect.ChangeEffectScale();
        }
        //�����łȂ����A�{�������{�ɖ߂�
        else
        {
            curremtChangeChargeRateTime = 0;
            currentChargeRate = 1f;
            changeChargeTrickEffect.ResetEffectScale();
        }
    }

    public float RatioOfChargeRate()
    {
        return curremtChangeChargeRateTime / byRateMaxTime;
    }
}
