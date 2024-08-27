using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class GenerateEffect:MonoBehaviour
{
    [Header("�G�t�F�N�g")]
    [SerializeField] GameObject effect;//�G�t�F�N�g(�̃v���n�u)
    [Header("�G�t�F�N�g�̐����ʒu")]
    [SerializeField] Transform instantiatePos;//�G�t�F�N�g�̐����ʒu
    [Header("�q�I�u�W�F�N�g�Ƃ��Đ������邩")]
    [SerializeField] bool instantiateInOtherObject;//�q�I�u�W�F�N�g�Ƃ��Đ������邩
    [Header("�������̐e�I�u�W�F�N�g")]
    [SerializeField] GameObject parent;//�������̐e�I�u�W�F�N�g
    private float m_delayTime;//�x������
    private float currentDelayTime;//���݂̒x������
    private bool instantiated=true;//�G�t�F�N�g���o������

    public void Generate(float delayTime)//�G�t�F�N�g���Ăяo�������^�C�~���O�ŌĂяo���A������delayTime�ɂ͒x�������������Ԃ�����B
    {
        if(delayTime<0) delayTime = 0;//����0�����̒l�����͂���Ă����玩���I��0(�b)�ɂ���
        m_delayTime = delayTime;//�x�����Ԃ̐ݒ�
        currentDelayTime = 0;//���݂̒x�����Ԃ̃��Z�b�g
        instantiated = false;//�G�t�F�N�g���o�����������Z�b�g
    }

    void Update()
    {
        UpdateCurrentDelayTime();

        DelayGenerate();
    }

    void UpdateCurrentDelayTime()//���݂̒x�����Ԃ̍X�V
    {
        currentDelayTime += Time.deltaTime;
    }

    void DelayGenerate()//�x�����ԕ��x�������Đ���
    {
        if (!instantiated && currentDelayTime >= m_delayTime)//�܂��G�t�F�N�g��u���Ă��Ȃ������݂̒x�����Ԃ��ݒ肳�ꂽ�x�����ԂɒB�����B 
        {
            instantiated = true;//�G�t�F�N�g���o�����B

            if (instantiateInOtherObject)//�q�I�u�W�F�N�g�Ƃ��Đ�������Ȃ�
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
