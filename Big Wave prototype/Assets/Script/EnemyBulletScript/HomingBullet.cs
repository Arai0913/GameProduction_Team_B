using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��莞�Ԓe���z�[�~���O���Ȃ��瓮��
public class HomingBullet : MonoBehaviour
{
    float startHomingTime;//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩                      
    float homingTime;//���b�ԃz�[�~���O���邩
    float homingSpeed;//�W�I�Ɍ������x

    private float currentHomingTime = 0;//���݂̃z�[�~���O����
    private float finishHomingTime;//���˂���ĉ��b��Ƀz�[�~���O����߂邩
    Transform target;//�z�[�~���O���̕W�I(�v���C���[)

    public float StartHomingTime//���˂���ĉ��b�ォ��z�[�~���O���n�߂邩
    {
        set { currentHomingTime = value; }
        get { return currentHomingTime; }
    }

    public float HomingTime//���b�ԃz�[�~���O���邩
    {
        set { homingTime = value; }
        get { return homingTime; }
    }

    public float HomingSpeed//�W�I�Ɍ������x
    {
        set { homingSpeed = value; }
        get { return homingSpeed;}
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        finishHomingTime = startHomingTime + homingTime;//�z�[�~���O�I�����Ԃ�ݒ�
    }

    void Update()
    {
        currentHomingTime += Time.deltaTime;

        bool homingNow = (startHomingTime <= currentHomingTime && currentHomingTime <= finishHomingTime);

        if(homingNow)//���ԂɂȂ�܂ŕW�I�̕�������������
        {
            Homing();
        }
    }

    void Homing()//�W�I����������
    {
        Vector3 targetPos = target.transform.position - transform.position;//�����̈ʒu����W�I�̈ʒu�܂ł̃x�N�g���̎擾
        Quaternion targetRotation = Quaternion.LookRotation(targetPos);//��قǂ̃x�N�g�������]����p�x��ݒ�
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, homingSpeed*Time.deltaTime);
    }
}
