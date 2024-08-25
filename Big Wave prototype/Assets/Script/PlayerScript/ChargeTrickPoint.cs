using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

//�쐬��:���R
//�g���b�N�̃`���[�W
public class ChargeTrickPoint : MonoBehaviour
{
    /////�t�B�[���h/////
    [Header("���݃g���b�N���`���[�W���Ă��邩�̔���")]
    [SerializeField] JudgeChargeNow judgeChargeNow;//���݃g���b�N���`���[�W���Ă��邩�̔���
    [Header("���݂̃g���b�N�ʂɂ��`���[�W�{����ω�������@�\")]
    [SerializeField] ChangeChargeRateTheCharger changeChargeRateTheCharger;//���݂̃g���b�N�ʂɂ��`���[�W�{����ω�������
    [Header("�g�ɏ��قǃ`���[�W�{����ω�������@�\")]
    [SerializeField] ChangeChargeRateTheSurfer changeChargeRateTheSurfer;//�g�ɏ��قǃ`���[�W�{����ω�������
    [Header("�`���[�W���̂݃G�t�F�N�g��\������@�\")]
    [SerializeField] DisplayChargeTrickEffect displayChargeTrickEffect;//�`���[�W���̂݃G�t�F�N�g��\������
    [Header("�g�ɏ��قǃ`���[�W���̃G�t�F�N�g�̑傫�����ω�����@�\")]
    [SerializeField] ChangeChargeTrickEffectTheSurfer changeChargeTrickEffectTheSurfer;//�g�ɏ��قǃ`���[�W���̃G�t�F�N�g�̑傫�����ω�����

    FeverMode feverMode;
    TrickPoint player_TrickPoint;
    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;
    private bool chargeStandby = false;//���ꂪtrue�ɂȂ��Ă��鎞���g�ɐG��Ă��鎞�̂݃g���b�N���`���[�W�ł���

    /////private(�ʃN���X�͎g�p�s��)�̃��\�b�h/////
    void Start()
    {
        //�ʃN���X�̏��擾
        feverMode = GetComponent<FeverMode>();
        player_TrickPoint=GetComponent<TrickPoint>();
        jumpControl=GetComponent<JumpControl>();
        judgeTouchWave=GetComponent<JudgeTouchWave>();

        //�����N���X�̊e�@�\�̍ŏ��̃t���[���̏���
        judgeChargeNow.StartSinceLastChargedTime();
        changeChargeRateTheSurfer.StartChangeRatePerSecond();
        displayChargeTrickEffect.StartChargeEffect();
        changeChargeTrickEffectTheSurfer.StartScale();
        changeChargeTrickEffectTheSurfer.StartChargeRate(changeChargeRateTheSurfer.NormalChargeRate,changeChargeRateTheSurfer.ChargeRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        //�����N���X�̊e�@�\�̖��t���[������
        judgeChargeNow.UpdateSinceLastChargedTime();
        changeChargeRateTheSurfer.ChangeChargeRate();
        changeChargeRateTheSurfer.CheckJumpNow_TouchWaveNow(jumpControl.JumpNow(),judgeTouchWave.TouchWaveNow);
        displayChargeTrickEffect.Display(judgeChargeNow.ChargeNow());
        changeChargeTrickEffectTheSurfer.ChangeEffectScale(changeChargeRateTheSurfer.ChargeRate());
    }

    float ChargeTrickAmount(float chargeAmount)//�`���[�W�����g���b�N��
    {
        float ret = chargeAmount;//�ʏ펞�̃`���[�W�����g���b�N��
        ret *= feverMode.CurrentChargeTrick_GrowthRate;//�t�B�[�o�[��Ԃ̃`���[�W�{��
        ret *= changeChargeRateTheCharger.ChargeRate(player_TrickPoint.MaxCount,player_TrickPoint.TrickGaugeNum);//���^���̃g���b�N�Q�[�W�̐��ɂ��`���[�W�{��
        ret *= changeChargeRateTheSurfer.ChargeRate();//�g�ɏ���Ă��鎞�Ԃɂ��`���[�W�{��
        return ret;
    }





    /////public(�ʃN���X���g�p�\)�̃��\�b�h/////

    public bool ChargeStandby
    {
        get { return chargeStandby; }
        set { chargeStandby = value; }
    }

   
    public void Charge(float chargeAmount)//�g���b�N�̃`���[�W
    {
        if (chargeStandby)
        {
            player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//�g���b�N���`���[�W
            judgeChargeNow.ResetSinceLastChargedTime();//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
        }
    }

    public bool ChargeNow()//���`���[�W���Ă��邩�̔���
    {
        return judgeChargeNow.ChargeNow();
    }







    /////�����N���X/////

    //���݃g���b�N���`���[�W���Ă��邩�̔���
    [System.Serializable]
    private class JudgeChargeNow
    {
        [Header("�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���")]
        [SerializeField] float chargedBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
        private float sinceLastChargedTime = 0.1f;//�Ō�Ƀ`���[�W����Ă���̎���

        public void StartSinceLastChargedTime()//�Ō�Ƀ`���[�W����Ă���̎��Ԃ̏�����(start)
        {
            sinceLastChargedTime = chargedBorderTime;
        }

        public void UpdateSinceLastChargedTime()//�Ō�Ƀ`���[�W����Ă���̎��Ԃ̍X�V(start)
        {
            sinceLastChargedTime += Time.deltaTime;
        }

        public bool ChargeNow()//���`���[�W���Ă��邩
        {
            if (sinceLastChargedTime < chargedBorderTime)//�Ō�Ƀ`���[�W���Ă���chargeBorderTime(�b)�����Ȃ獡�`���[�W���Ă锻��
            {
                return true;
            }

            return false;
        }

        public void ResetSinceLastChargedTime()//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
        {
            sinceLastChargedTime = 0;
        }
    }



    //���݂̃g���b�N�ʂɂ��`���[�W�{����ω�������
    [System.Serializable]
    private class ChangeChargeRateTheCharger
    {
        [Header("�`���[�W�{��(�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������)")]
        [SerializeField] float[] chargeRate;//�`���[�W�{��

        //���^���̃Q�[�W�̐��ɑΉ������`���[�W�{����Ԃ�
        //������maxCount�ɂ̓v���C���[�̖��^���̃g���b�N�Q�[�W�̌��A������trickGaugeNum�ɂ̓v���C���[�̃g���b�N�Q�[�W�̌�������
        public float ChargeRate(int maxCount,int trickGaugeNum)
        {
            maxCount = Mathf.Clamp(maxCount, 0, trickGaugeNum - 1);
            return chargeRate[maxCount];
        }
    }



    //�g�ɏ��قǃ`���[�W�{����ω�������
    [System.Serializable]
    private class ChangeChargeRateTheSurfer
    {
        [Header("�ő�܂ł��܂�₷���Ȃ������̔{��(�ő�{��)")]
        [SerializeField] float chargeRateMax = 3;//�ő�{��
        [Header("�ő�{���ɂȂ�܂łɂ����鎞��")]
        [SerializeField] float byMaxRateTime = 10;//�ő�{���ɂȂ�܂łɂ����鎞��
        [Header("�{�������鑬�x(�{���������鎞�̑��x��1�Ƃ���)")]
        [SerializeField] float minusChargeRateSpeed;//�g�ɐG��ĂȂ����W�����v���Ă��Ȃ����ɔ{�������鑬�x
        private const float normalChargeRate = 2;//���{
        private float currentChargeRate = normalChargeRate;//���݂̔{��
        private float changeRatePerSecond;//1�b���Ƃɑ�����{����
        private bool jumpNow;//���݃W�����v���Ă��邩
        private bool touchWaveNow;//���ݔg�ɐG��Ă��邩

        public float ChargeRateMax//�ő�`���[�W�{��
        {
            get { return chargeRateMax; }
        }

        public float NormalChargeRate//���{(�������)�̃`���[�W�{��
        {
            get { return normalChargeRate; }
        }

        public float ChargeRate()//���݂̃`���[�W�{����Ԃ�
        {
            return currentChargeRate;
        }

        public void StartChangeRatePerSecond()//1�b���Ƃɑ�����{���ʂ̏�����(start)
        {
            changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;//1�b���Ƃɑ�����{���ʂ�ݒ�
        }

        //������jN�ɂ͌��݃W�����v���Ă��邩�AtWN�ɂ͌��ݔg�ɐG��Ă��邩������(update)
        public void CheckJumpNow_TouchWaveNow(bool jN, bool tWN)
        {
            jumpNow = jN;
            touchWaveNow = tWN;
        }

        //�`���[�W�{����ω�������(update)
        public void ChangeChargeRate()
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

        bool ChangeChargeRateNow()//���݃`���[�W�{�����ω����Ă��邩
        {
            //���݃W�����v���Ă���������͔g�ɐG��Ă���Ƃ��A�`���[�W�{�����ω�����
            bool chargeRateNow = (jumpNow || touchWaveNow);
            return chargeRateNow;
        }
       
    }



    //�`���[�W���̂݃G�t�F�N�g��\������
    [System.Serializable]
    private class DisplayChargeTrickEffect
    {
        [Header("�`���[�W���̃G�t�F�N�g")]
        [SerializeField] GameObject chargeEffect;//�`���[�W���̃G�t�F�N�g

        //�`���[�W���̃G�t�F�N�g�̏�����(start)
        public void StartChargeEffect()
        {
            chargeEffect.SetActive(false);//�Q�[���J�n���`���[�W���̃G�t�F�N�g���\��
        }

        //�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W���̃G�t�F�N�g��\��(update)
        public void Display(bool chargeNow)
        {
            chargeEffect.SetActive(chargeNow);
        }
    }



    //�g�ɏ��قǃ`���[�W���̃G�t�F�N�g�̑傫�����ω�����
    [System.Serializable]
    private class ChangeChargeTrickEffectTheSurfer
    {
        [Header("�`���[�W���̃G�t�F�N�g")]
        [SerializeField] GameObject chargeEffect;//�`���[�W���̃G�t�F�N�g
        [Header("�ő�{�����̃`���[�W���̃G�t�F�N�g�̑傫��(�{��)")]
        [SerializeField] float maxScaleRate;//�ő�{�����̃`���[�W���̃G�t�F�N�g�̑傫���A�����̑傫�����牽�{�̑傫����
        private Vector3 maxScale;//�ő�{�����̃G�t�F�N�g�̑傫��
        private Vector3 normalScale;//�ʏ펞(����)�̃G�t�F�N�g�̑傫��
        private Vector3 currentScale;//���݂̃G�t�F�N�g�̑傫��
        private float normalChargeRate;//���{(�������)�̔g�ɏ�邱�Ƃɂ���ĕω�����`���[�W�{��
        private float chargeRateMax;//�ő�̔g�ɏ�邱�Ƃɂ���ĕω�����`���[�W�{��

        //�ʏ펞�A���݁A�ő厞�̑傫���̒l�̏�����(start)
        public void StartScale()
        {
            normalScale = chargeEffect.transform.localScale;
            maxScale = normalScale * maxScaleRate;
            currentScale = normalScale;
        }

        //���{(�������)�A�ő厞�̔g�ɏ�邱�Ƃɂ���ĕω�����`���[�W�{���̏�����(start)
        public void StartChargeRate(float normal,float max)//������normal�ɂ͓��{(�������)�Amax�ɂ͍ő厞�̔g�ɏ�邱�Ƃɂ���ĕω�����`���[�W�{��������
        {
            normalChargeRate = normal;
            chargeRateMax = max;
        }


        //�G�t�F�N�g�̑傫�������݂̔g�ɏ�邱�Ƃɂ���ĕω�����`���[�W�{���ɂ��킹�ĕύX(update)
        public void ChangeEffectScale(float currentChargeRate)//������currentChargeRate�ɂ͌��݂̔g�ɏ�邱�Ƃɂ���ĕω�����`���[�W�{��������
        {
            if (chargeEffect.activeSelf)//�`���[�W�G�t�F�N�g���A�N�e�B�u�̎��ɃG�t�F�N�g�̑傫����ύX
            {
                float current = currentChargeRate - normalChargeRate;//���݂̔{������ʏ�̔{��(1)������������
                float max = chargeRateMax - normalChargeRate;//�ő�{������ʏ�̔{��(1)������������
                float ratio = current / max;

                //�G�t�F�N�g�̌��݂̑傫���̒l��ύX
                currentScale = normalScale + (maxScale - normalScale) * ratio;

                //���݂̑傫�����G�t�F�N�g�̑傫���ɓK�p
                chargeEffect.transform.localScale = currentScale;
            }
        }
    }
}
