using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //������������
    //�g�̓����ɔg��肵�Ă���Ƃ���outSideChargeTrick�AinSideChargeTrick�̍��v���g���b�N��������
    [SerializeField] float outSideChargeTrick=1;//�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l
    [SerializeField] float inSideChargeTrick=2;//�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l
    [SerializeField] GameObject chargeSpark;//�`���[�W�p�̗��G�t�F�N�g
    [HideInInspector] public bool chargeNow=false;//���g���b�N���`���[�W���Ă��邩
    private float sinceLastChargeTime = 0.1f;//�Ō�Ƀ`���[�W����Ă���̎���
    private float chargeBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    JudgeTouchWave touchWave;
    Player player;
    Wave wave;
  //�R���g���[���[�̐ڑ����m�F
    // Start is called before the first frame update
    void Start()
    {
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//�g�ɐG���Ă��邩�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��

        JudgeChargeNow();//���`���[�W���Ă��邩����
    }

    //�g�ɐG��ăg���b�N���`���[�W
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        wave = wavePrefab.GetComponent<Wave>();//Wave�̏��(isTouched)���擾

        //��x���G��Ă��Ȃ������̔g����`���[�W����
        if (wavePrefab.CompareTag("InsideWave") && wave.isTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick);
        }

        //��x�G��Ă��Ȃ��O���̔g����`���[�W����
        else if (wavePrefab.CompareTag("OutsideWave") && wave.isTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick);
        }
    }

    //�g�ɐG��ăg���b�N���`���[�W����Ƃ��̓����̏���
    //a(����)�ɂ�inSideChargeTrick��outSideChargeTrick������(���܂�g���b�N��)
    void ProcessingChargeTrick(float a)
    {
        player.ChargeTRICK(a);//�g���b�N���`���[�W
        wave.isTouched = true;//��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)
        sinceLastChargeTime = 0f;//���`���[�W���Ă��锻��ɂ���
    }



    void JudgeChargeNow()//���`���[�W���Ă��邩����
    {
        sinceLastChargeTime += Time.deltaTime;

        if (sinceLastChargeTime < chargeBorderTime)//�Ō�Ƀ`���[�W���Ă���chargeBorderTime(�b)�����Ȃ獡�`���[�W���Ă锻��
        {
            chargeNow = true;
        }
        else
        {
            chargeNow = false;
        }
    }



    void DisplayChargeSpark()//�g�ɐG���Ă��邩�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��
    {
        if(chargeNow&&touchWave.touchWaveNow)
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
