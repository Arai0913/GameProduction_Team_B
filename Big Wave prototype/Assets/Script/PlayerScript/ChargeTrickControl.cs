using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //�g�̓����ɔg��肵�Ă���Ƃ���outSideChargeTrick�AinSideChargeTrick�̍��v���g���b�N��������
    [SerializeField] float outSideChargeTrick=1;//�g�̊O���ɔg��肵�����ɗ��܂�g���b�N�̒l
    [SerializeField] float inSideChargeTrick=2;//�g�̓���(����)�ɔg��肵�����ɗ��܂�g���b�N�̒l
    [SerializeField] GameObject chargeSpark;//�`���[�W�p�̗��G�t�F�N�g
    private bool chargeNow=false;//���g���b�N���`���[�W���Ă��邩
    private float sinceLastChargeTime = 0.1f;//�Ō�Ƀ`���[�W����Ă���̎���
    private float chargeBorderTime = 0.1f;//�`���[�W���Ă��Ȃ��E���Ă���̋��E�̎���
    JudgeTouchWave touchWave;
    Player player;
    Wave wave;
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

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("InsideWave")|| t.gameObject.CompareTag("OutsideWave"))//�g�ɐG��Ă���Ȃ�Wave�̏��(isTouched)���擾
        {
            wave = t.GetComponent<Wave>();
        }

        //�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W�A��x���G��Ă��Ȃ������̔g����`���[�W����
        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("InsideWave")&&wave.isTouched==false)
        {
            //�g���b�N���`���[�W�A��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)�A�`���[�W�p�̗��G�t�F�N�g��\��
            player.ChargeTRICK(inSideChargeTrick);
            wave.isTouched = true;
            sinceLastChargeTime = 0f;

        }

        //�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W�A��x�G��Ă��Ȃ��O���̔g����`���[�W����
        else if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("OutsideWave") && wave.isTouched == false)
        {
            //�g���b�N���`���[�W�A��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)�A�`���[�W�p�̗��G�t�F�N�g��\��
            player.ChargeTRICK(outSideChargeTrick);
            wave.isTouched = true;
            sinceLastChargeTime = 0f;
        }
    }

    void JudgeChargeNow()//���`���[�W���Ă��邩����
    {
        sinceLastChargeTime += Time.deltaTime;

        if (sinceLastChargeTime < chargeBorderTime)
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
