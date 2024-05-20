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
    Player player;
    JumpControl jumpControl;
    Wave wave;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//�g�ɐG���Ă��邩�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("InsideWave")|| t.gameObject.CompareTag("OutsideWave"))//�g�ɐG��Ă���Ȃ�Wave�̏��(isTouched)���擾
        {
            wave = t.GetComponent<Wave>();
        }

        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("InsideWave")&&wave.isTouched==false)//�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W�A��x���G��Ă��Ȃ������̔g����`���[�W����
        {
            //�g���b�N���`���[�W�A��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)�A�`���[�W�p�̗��G�t�F�N�g��\��
            player.ChargeTRICK(inSideChargeTrick);
            wave.isTouched = true;
            chargeNow = true;
            
        }

        else if((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("OutsideWave") && wave.isTouched == false)//�X�y�[�X�L�[��{�^���������Ă���ԃ`���[�W�A��x�G��Ă��Ȃ��O���̔g����`���[�W����
        {
            //�g���b�N���`���[�W�A��x�G�ꂽ�g����̓`���[�W�ł��Ȃ��悤�ɂ���(�G��������ɂ���)�A�`���[�W�p�̗��G�t�F�N�g��\��
            player.ChargeTRICK(outSideChargeTrick);
            wave.isTouched = true;
            chargeNow = true;
        }

        else
        {
            chargeNow = false;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.CompareTag("InsideWave")|| other.gameObject.CompareTag("InsideWave"))//�g���痣�ꂽ��`���[�W�p�̗��G�t�F�N�g���\��
    //    {
    //        chargeSpark.SetActive(false);
    //    }
    //}

    void DisplayChargeSpark()//�g�ɐG���Ă��邩�g���b�N���`���[�W���Ă��鎞�̂݃`���[�W�p�̗��G�t�F�N�g��\��
    {
        if(chargeNow==true&&(jumpControl.touchInsideWaveNow ==true|| jumpControl.touchOutsideWaveNow == true))
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
