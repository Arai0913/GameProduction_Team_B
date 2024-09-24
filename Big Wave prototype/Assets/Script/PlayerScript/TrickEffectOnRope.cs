using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�t�F�N�g����߂�ꂽ�ӏ������ɐi��
//����R�[�h�̐����͂��܂�
public class TrickEffectOnRope : MonoBehaviour
{
    [Header("�G�t�F�N�g�̒ʂ�n�_")]
    [SerializeField] Transform[] effectPassPos;//�G�t�F�N�g�̒ʂ�n�_�A�ŏ��̒n�_����w�莞�Ԃ��Ƃɐi��ł����čŌ�̒n�_�Œ��e�G�t�F�N�g���o��
    [Header("�`�����̃G�t�F�N�g")]
    [SerializeField] GameObject passEffect;//�`�����̃G�t�F�N�g
    [Header("���e���̃G�t�F�N�g")]
    [SerializeField] GameObject landEffect;//���e���̃G�t�F�N�g
    [Header("���̒n�_�ɐi�ނ܂ł̕b��")]
    [SerializeField] float transitNextPosTime;//���̒n�_�ɐi�ނ܂ł̕b��
    private List<PassPos> passPosList=new List<PassPos>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatePassEffect();
    }

    void CreatePassEffect()
    {
        for(int i=0; i<passPosList.Count;i++)
        {
            passPosList[i].passTime += Time.deltaTime;

            if(passPosList[i].passTime>=transitNextPosTime)
            {
                Transform pass= effectPassPos[passPosList[i].passNum];

                if (passPosList[i].passNum== effectPassPos.Length-1)//�ŏI�n�_�Ȃ�
                {
                    Instantiate(landEffect, pass.position, pass.rotation, pass);//����
                }
                else
                {
                    Instantiate(passEffect, pass.position, pass.rotation, pass);//����
                }
                
                passPosList[i].passNum++;//���̏ꏊ��ݒ�
                passPosList[i].passTime = 0;
            }
        }

        //���̏ꏊ���ʂ�n�_�̐��Ȃ炱���ŏ���
        while(true)
        {
            if (passPosList.Count == 0) break;

            if (passPosList[0].passNum>=effectPassPos.Length)
            {
                passPosList.RemoveAt(0);//�폜
            }
            else
            {
                break;
            }
        }
    }

    //���[�v��`���G�t�F�N�g���o�����ɌĂяo��
    public void ActivateEffect()
    {
        PassPos passPos=new PassPos(transitNextPosTime);
        passPosList.Add(passPos);
    }
}

class PassPos
{
    public int passNum;//passNumber(���G�t�F�N�g���o���ꏊ�̗v�f�ԍ��A������0)
    public float passTime;//passTime(��������Ă���̎��ԁA������0)

    //�R���X�g���N�^
    public PassPos(float time)
    {
        passNum = 0;
        passTime = time;
    }
}
