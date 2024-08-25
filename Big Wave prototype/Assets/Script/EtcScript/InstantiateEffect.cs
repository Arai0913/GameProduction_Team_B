using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InstantiateEffect:MonoBehaviour
{
    [Header("�G�t�F�N�g�̃I�u�W�F�N�g")]
    [SerializeField] GameObject effect;//�G�t�F�N�g�̃I�u�W�F�N�g
    [Header("�G�t�F�N�g�̐����ʒu")]
    [SerializeField] Transform instantiatePos;//�G�t�F�N�g�̐����ʒu
    [Header("�q�I�u�W�F�N�g�Ƃ��Đ������邩")]
    [SerializeField] bool instantiateInOtherObject;//�q�I�u�W�F�N�g�Ƃ��Đ������邩
    [Header("�������̐e�I�u�W�F�N�g")]
    [SerializeField] GameObject parent;//�������̐e�I�u�W�F�N�g
    private float delayTime;//�x������
    private float currentDelayTime;//���݂̒x������
    private bool instantiated=true;//�G�t�F�N�g���o������

    public void Instantiate(float delay)//�G�t�F�N�g���Ăяo�������^�C�~���O�ŌĂяo���A������delay�ɂ͒x�������������Ԃ�����B
    {
        delayTime = delay;//�x�����Ԃ̐ݒ�
        currentDelayTime = 0;//���݂̒x�����Ԃ̃��Z�b�g
        instantiated = false;//�G�t�F�N�g���o�����������Z�b�g
    }

    void Update()
    {
        currentDelayTime += Time.deltaTime;

        if (!instantiated&&currentDelayTime>=delayTime)//�܂��G�t�F�N�g��u���Ă��Ȃ������݂̒x�����Ԃ��ݒ肳�ꂽ�x�����ԂɒB�����B 
        {
            instantiated = true;//�G�t�F�N�g���o�����B

            if(instantiateInOtherObject)//�q�I�u�W�F�N�g�Ƃ��Đ�������Ȃ�
            {
                Instantiate(effect, instantiatePos.transform.position, transform.rotation, parent.transform);//�q�I�u�W�F�N�g�Ƃ��ăG�t�F�N�g��u��
            }
            else//�����łȂ��Ȃ�
            {
                Instantiate(effect, instantiatePos.transform.position, transform.rotation);//���ɃG�t�F�N�g��u��
            }

        }
    }

    

}
