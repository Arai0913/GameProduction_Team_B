using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���쐬��:���R
//�g���b�N�̃`���[�W�֘A
public class ChargeTrick : MonoBehaviour
{
    //�g�̓����ɔg��肵�Ă���Ƃ���outSideChargeTrick�AinSideChargeTrick�̍��v���g���b�N��������
    [Header("�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l")]
    [SerializeField] float outSideChargeTrick=1;//�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l
    [Header("�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l")]
    [SerializeField] float inSideChargeTrick=2;//�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l
    JudgeChargeNow judgeChargeNow;
    Player player;
    ProcessFeverMode processFeverPoint;
    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    ChangeChargeTrickTheCharger changeChargeTrickTheCharger;
  
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        processFeverPoint = gameObject.GetComponent<ProcessFeverMode>();
        changeChargeTrickTheSurfer=gameObject.GetComponent<ChangeChargeTrickTheSurfer>();
        judgeChargeNow=gameObject.GetComponent<JudgeChargeNow>();
        changeChargeTrickTheCharger=gameObject.GetComponent<ChangeChargeTrickTheCharger>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    //�g�ɐG��ăg���b�N���`���[�W
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        Wave wave = wavePrefab.GetComponent<Wave>();//Wave�̏��(isTouched)���擾

        //��x���G��Ă��Ȃ������̔g����`���[�W����
        if (wavePrefab.CompareTag("InsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick,wave);
        }

        //��x�G��Ă��Ȃ��O���̔g����`���[�W����
        else if (wavePrefab.CompareTag("OutsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick, wave);
        }
    }

    float ChargeTrickAmount(float b)//�`���[�W�����g���b�N��(b�ɂ�inSideChargeTrick��outSideChargeTrick������)
    {
        float ret=b;
        ret *= processFeverPoint.CurrentChargeTrick_GrowthRate;//�t�B�[�o�[��Ԃ̃`���[�W�{��
        ret *= changeChargeTrickTheCharger.ChargeRate();//���^���̃g���b�N�Q�[�W�̐��ɂ��`���[�W�{��
        ret*= changeChargeTrickTheSurfer.CurrentChargeRate;//�g�ɏ���Ă��鎞�Ԃɂ��`���[�W�{��
        return ret;
    }

    //�g�ɐG��ăg���b�N���`���[�W����Ƃ��̓����̏���
    //a(����)�ɂ�inSideChargeTrick��outSideChargeTrick������(���܂�g���b�N��)
    void ProcessingChargeTrick(float a,Wave wave)
    {
        player.ChargeTrickPoint(ChargeTrickAmount(a));//�g���b�N���`���[�W
        wave.IsTouched = true;//��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)
        judgeChargeNow.ResetSinceLastChargedTime();//�Ō�Ƀ`���[�W����Ă���̎��Ԃ����Z�b�g
    }
}





