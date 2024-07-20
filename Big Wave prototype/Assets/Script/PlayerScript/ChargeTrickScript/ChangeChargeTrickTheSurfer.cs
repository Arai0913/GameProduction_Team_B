using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���쐬��:���R
//�g�ɏ��قǃg���b�N�̃`���[�W�ʂ��ω�����
public class ChangeChargeTrickTheSurfer : MonoBehaviour
{
    [Header("�ő�܂ł��܂�₷���Ȃ������̔{��(�ő�{��)")]
    [SerializeField] float chargeRateMax=1;//�ő�{��
    [Header("�ő�{���ɂȂ�܂łɂ����鎞��")]
    [SerializeField] float byRateMaxTime=10;//�ő�{���ɂȂ�܂łɂ����鎞��
    [Header("�{�������鑬�x(�{���������鎞�̑��x��1�Ƃ���)")]
    [SerializeField] float minusChargeRateSpeed;//�g�ɐG��ĂȂ����W�����v���Ă��Ȃ����ɔ{�������鑬�x
    private float curremtChangeChargeRateTime=0;//�{�����ω����Ă��鎞��
    private const float normalChargeRate = 1;//���{
    private float currentChargeRate = normalChargeRate;//���݂̔{��

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;
    ChangeChargeTrickTheSurferEffect changeChargeTrickEffect;

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
        changeChargeTrickEffect = GetComponent<ChangeChargeTrickTheSurferEffect>();
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
        //�g�ɐG��Ă��邩�W�����v���Ă��鎞�AbyRateMaxTime�����Ă��񂾂�{����1�{����chargeRateMax�{�܂ŕω�����
        if (ChangeChargeRateNow())
        {
            curremtChangeChargeRateTime += Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);
        }
        //�����łȂ����A�{�������Ԃ��ƂɌ����Ă���
        else
        {
            curremtChangeChargeRateTime -= minusChargeRateSpeed*Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);
        }

        currentChargeRate = normalChargeRate + (chargeRateMax - normalChargeRate) * RatioOfChargeRate();
        currentChargeRate = Mathf.Clamp(currentChargeRate, 1, chargeRateMax);

        changeChargeTrickEffect.ChangeEffectScale();
    }

    public float RatioOfChargeRate()
    {
        return curremtChangeChargeRateTime / byRateMaxTime;
    }
}
