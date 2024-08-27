using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    [Header("�t�B�[�o�[��Ԃ̃G�t�F�N�g")]
    [SerializeField] GameObject feverEffect;//�t�B�[�o�[��Ԃ̃G�t�F�N�g
    [Header("�t�B�[�o�[��Ԃ̌��ʎ���")]
    [SerializeField] float feverTime=20f;//�t�B�[�o�[��Ԃ̌��ʎ���
    private float remainingFeverTime = 0f;//�t�B�[�o�[��Ԃ̎c����ʎ���

    [Header("�U���̓A�b�v�̃o�t")]
    [SerializeField] PowerUpBuff powerUpBuff;//�U���̓A�b�v�̃o�t
    [Header("�`���[�W�g���b�N�ʃA�b�v�̃o�t")]
    [SerializeField] ChargeTrickBuff chargeTrickBuff;//�U���̓A�b�v�̃o�t

    //[Header("�t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����")]
    //[SerializeField] float powerUp_GrowthRate = 1f;//�t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����
    //private float currentPowerUp_GrowthRate = 1f;//���݂̃t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����
    //[Header("�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����")]
    //[SerializeField] float chargeTrick_GrowthRate = 1f;//�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����
    //private float currentChargeTrick_GrowthRate = 1f;//���݂̃t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����
    private bool feverNow=false;//���t�B�[�o�[��Ԃ�

    FeverPoint player_FeverPoint;

    public float CurrentPowerUp_GrowthRate
    {
        get { return powerUpBuff.CurrentPowerUp_GrowthRate; }
    }

    public float CurrentChargeTrick_GrowthRate
    {
        get { return chargeTrickBuff.CurrentChargeTrick_GrowthRate; }
    }

    public bool FeverNow
    {
        get { return feverNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        feverEffect.SetActive(false);
        remainingFeverTime = 0f;
        feverNow = false;
        player_FeverPoint = gameObject.GetComponent<FeverPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFeverMode();//�t�B�[�o�[��ԂɈڍs

        UpdateFeverTime();//�t�B�[�o�[��Ԃ̎c�莞�Ԃ��Ǘ�

        FeverModeEffect();//�t�B�[�o�[��Ԃ̌��ʂ̏���
    }

    //�܂��t�B�[�o�[��ԂɂȂ��Ă��Ȃ����t�B�[�o�[�|�C���g�����^���ɂȂ�����t�B�[�o�[��ԂɈڍs
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint_ >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
        }
    }

    //�t�B�[�o�[��Ԃ̎c�莞�Ԃ��X�V
    void UpdateFeverTime()
    {
        remainingFeverTime -= Time.deltaTime;

        if(remainingFeverTime<=0f)//�t�B�[�o�[��Ԃ̎c�莞�Ԃ�0�ɂȂ�����t�B�[�o�[��Ԃ�����
        {
            remainingFeverTime=0f;
            feverNow = false;
        }
    }

    //�t�B�[�o�[��Ԃ̌��ʂ̏���
    void FeverModeEffect()
    {
        //�t�B�[�o�[��Ԓ���...
        //�U���͂ƃ`���[�W�g���b�N�ʂ��A�b�v����
        //�G�t�F�N�g���t��
        //�t�B�[�o�[�|�C���g�����Ԃ��ƂɌ����Ă���(�t�B�[�o�[��Ԃ̎c�莞�Ԃ�\���Ă���)
        if (feverNow)
        {
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint_ = player_FeverPoint.FeverPointMax * ratio;
        }

        powerUpBuff.ChangePowerUpGrowthRate(feverNow);//�t�B�[�o�[���U���͂��オ��
        chargeTrickBuff.ChangeChargeTrickGrowthRate(feverNow);//�t�B�[�o�[���`���[�W�g���b�N�ʂ��オ��
        feverEffect.SetActive(feverNow);//�t�B�[�o�[���G�t�F�N�g��\��
    }



    /////�����N���X/////

    [System.Serializable]
    class PowerUpBuff
    {
        [Header("�t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����")]
        [SerializeField] float powerUp_GrowthRate = 1f;//�t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����
        private float currentPowerUp_GrowthRate = 1f;//���݂̃t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����

        public float CurrentPowerUp_GrowthRate
        {
            get { return currentPowerUp_GrowthRate; }
        }

        public void ChangePowerUpGrowthRate(bool feverNow)//�U���̓A�b�v�̑�������ω�������
        {
            if(feverNow)//�t�B�[�o�[��
            {
                currentPowerUp_GrowthRate = powerUp_GrowthRate;
            }
            else
            {
                currentPowerUp_GrowthRate = 1f;
            }
        }
    }

    [System.Serializable]
    class ChargeTrickBuff
    {
        [Header("�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����")]
        [SerializeField] float chargeTrick_GrowthRate = 1f;//�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����
        private float currentChargeTrick_GrowthRate = 1f;//���݂̃t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����

        public float CurrentChargeTrick_GrowthRate
        {
            get { return currentChargeTrick_GrowthRate; }
        }

        public void ChangeChargeTrickGrowthRate(bool feverNow)//�`���[�W�g���b�N�ʃA�b�v�̑�������ω�������
        {
            if (feverNow)//�t�B�[�o�[��
            {
                currentChargeTrick_GrowthRate = chargeTrick_GrowthRate;
            }
            else
            {
                currentChargeTrick_GrowthRate = 1f;
            }
        }
    }
}
