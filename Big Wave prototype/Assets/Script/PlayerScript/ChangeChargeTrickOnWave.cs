using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickOnWave : MonoBehaviour
{
    [Header("�ő�܂ł��܂�₷���Ȃ������̔{��(�ő�{��)")]
    [SerializeField] float chargeRateMax=1;//�ő�{��
    [Header("�ő�{���ɂȂ�܂łɂ����鎞��")]
    [SerializeField] float byRateMaxTime=10;//�ő�{���ɂȂ�܂łɂ����鎞��
    [Header("�`���[�W���̃G�t�F�N�g")]
    [SerializeField] GameObject chargeEffect;//�`���[�W���̃G�t�F�N�g
    [Header("�ő�{�����̃`���[�W���̃G�t�F�N�g�̑傫��")]
    [SerializeField] float maxScale;//�`���[�W���̃G�t�F�N�g
    private float currentChargeRate=1f;//���݂̔{��
    private bool changeChargeRateNow=false;//�{�������ω����Ă��邩
    private float curremtChangeChargeRateTime=0;//�{�����ω����Ă��鎞��
    private Vector3 normalScale;
    private Vector3 currentScale;

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


    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();
        normalScale=chargeEffect.transform.localScale;
        currentScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        Method1();
        Method2();
    }

    void Method1()//�g�ɐG��Ă��邩�W�����v���Ă��鎞�ɔ{�����ω�����悤�ɂ���
    {
        if(jumpControl.JumpNow||judgeTouchWave.TouchWaveNow)
        {
            changeChargeRateNow = true; 
        }
        else
        {
            changeChargeRateNow = false;
        }
    }

    void Method2()
    {
        //�g�ɐG��Ă��邩�W�����v���Ă��鎞�AbyRateMaxTime�����Ĕ{����1�{����chargeRateMax�{�܂ŕω�����
        if (changeChargeRateNow)
        {
            curremtChangeChargeRateTime += Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);

            currentChargeRate = 1 + (chargeRateMax - 1) / byRateMaxTime * curremtChangeChargeRateTime;
            currentChargeRate = Mathf.Clamp(currentChargeRate,1,chargeRateMax);
            
            //�G�t�F�N�g�̑傫����ύX
            float effectScale=normalScale.x+(maxScale-normalScale.x)/byRateMaxTime* curremtChangeChargeRateTime;
            currentScale = new Vector3(effectScale,effectScale,effectScale);

            chargeEffect.transform.localScale = currentScale;
        }
        //�����łȂ����A�{�������{�ɖ߂�
        else
        {
            curremtChangeChargeRateTime = 0;
            currentChargeRate = 1f;
            //�G�t�F�N�g�̑傫�������Ƃ̑傫����
            currentScale = normalScale;
        }
    }
}
