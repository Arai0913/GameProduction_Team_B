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
    [Header("�t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����")]
    [SerializeField] float powerUp_GrowthRate = 1f;//�t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����
    private float currentPowerUp_GrowthRate = 1f;//���݂̃t�B�[�o�[��Ԃ̍U���̓A�b�v�̑�����
    [Header("�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����")]
    [SerializeField] float chargeTrick_GrowthRate = 1f;//�t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����
    private float currentChargeTrick_GrowthRate = 1f;//���݂̃t�B�[�o�[��Ԃ̃`���[�W�g���b�N�ʃA�b�v�̑�����
    private bool feverNow=false;//���t�B�[�o�[��Ԃ�

    FEVERPoint player_FeverPoint;

    public float CurrentPowerUp_GrowthRate
    {
        get { return currentPowerUp_GrowthRate; }
    }

    public float CurrentChargeTrick_GrowthRate
    {
        get { return currentChargeTrick_GrowthRate; }
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
        currentPowerUp_GrowthRate = 1f;
        currentChargeTrick_GrowthRate = 1f;
        feverNow = false;
        player_FeverPoint = gameObject.GetComponent<FEVERPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFeverMode();//�t�B�[�o�[��ԂɈڍs

        ManageFeverTime();//�t�B�[�o�[��Ԃ̎c�莞�Ԃ��Ǘ�

        FeverModeEffect();//�t�B�[�o�[��Ԃ̌��ʂ̏���
    }

    //�܂��t�B�[�o�[��ԂɂȂ��Ă��Ȃ����t�B�[�o�[�|�C���g�����^���ɂȂ�����t�B�[�o�[��ԂɈڍs
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
        }
    }

    //�t�B�[�o�[��Ԃ̎c�莞�Ԃ��Ǘ�
    void ManageFeverTime()
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
            currentPowerUp_GrowthRate = powerUp_GrowthRate;
            currentChargeTrick_GrowthRate=chargeTrick_GrowthRate;
            feverEffect.SetActive(true);
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint = player_FeverPoint.FeverPointMax * ratio;
        }
        //�t�B�[�o�[��Ԃ���Ȃ����́@
        //�U���͂ƃ`���[�W�g���b�N�ʂ��ʏ�
        //�G�t�F�N�g����\��
        else
        {
            currentPowerUp_GrowthRate = 1f;
            currentChargeTrick_GrowthRate = 1f;
            feverEffect.SetActive(false);
        }    
    }
}
