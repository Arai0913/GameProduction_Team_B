using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//���쐬��:���R
//�g�ɏ��قǃg���b�N�̃`���[�W�ʂ��ω�����
public class ChangeChargeTrickTheSurfer : MonoBehaviour
{
    [Header("�ő�܂ł��܂�₷���Ȃ������̔{��(�ő�{��)")]
    [SerializeField] float chargeRateMax=1;//�ő�{��
    [Header("�ő�{���ɂȂ�܂łɂ����鎞��")]
    [SerializeField] float byMaxRateTime=10;//�ő�{���ɂȂ�܂łɂ����鎞��
    [Header("�{�������鑬�x(�{���������鎞�̑��x��1�Ƃ���)")]
    [SerializeField] float minusChargeRateSpeed;//�g�ɐG��ĂȂ����W�����v���Ă��Ȃ����ɔ{�������鑬�x
    private const float normalChargeRate = 1;//���{
    private float currentChargeRate = normalChargeRate;//���݂̔{��
    private float changeRatePerSecond;//1�b���Ƃɑ�����{����

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;

    public float CurrentChargeRate
    {
        get { return currentChargeRate; }
    }

    public float ChargeRateMax
    {
        get { return chargeRateMax; }
    }

    public float NormalChargeRate
    {
        get { return normalChargeRate; }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();

        changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;
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
            currentChargeRate += changeRatePerSecond * Time.deltaTime;//1�t���[�����Ƃɑ�����{����
        }
        //�����łȂ����A�{�������Ԃ��ƂɌ����Ă���
        else
        {
            currentChargeRate -= minusChargeRateSpeed * changeRatePerSecond * Time.deltaTime;//1�t���[�����ƂɌ���{����
        }

        currentChargeRate = Mathf.Clamp(currentChargeRate, 1, chargeRateMax);
    }
}
