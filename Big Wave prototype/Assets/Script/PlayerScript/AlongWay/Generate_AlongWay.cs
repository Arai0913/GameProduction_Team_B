using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//
enum GenerateType_AlongWay//�G�t�F�N�g�̐����^�C�v
{
    normal,
    critical
}

public class Generate_AlongWay : MonoBehaviour
{
    [Header("�ʏ�̃g���b�N�̃G�t�F�N�g")]
    [SerializeField] EffectType_AlongWay normalTrickEffect=new EffectType_AlongWay();
    [Header("�N���e�B�J���̃g���b�N�̃G�t�F�N�g")]
    [SerializeField] EffectType_AlongWay criticalTrickEffect = new EffectType_AlongWay();
    [Header("���̒n�_�ɐi�ނ܂ł̕b��")]
    [SerializeField] float generateInterval;//�G�t�F�N�g�𐶐�����C���^�[�o��
    [Header("�G�t�F�N�g�̒ʂ�n�_")]
    [SerializeField] Transform[] effectWays;//�G�t�F�N�g�̒ʂ�n�_�A�ŏ��̒n�_����w�莞�Ԃ��Ƃɐi��ł����čŌ�̒n�_�Œ��e�G�t�F�N�g���o��
    [SerializeField] Critical critical;
    private List<Pos_AlongWay> generatePosList = new List<Pos_AlongWay>();

    void Update()
    {
        GenerateEffectAtGeneratePos();
        DestroyGeneratePos();
    }

    void GenerateEffectAtGeneratePos()//�ʂ�n�_�ɃG�t�F�N�g�𐶐�
    {
        for (int i = 0; i < generatePosList.Count; i++)
        {
            generatePosList[i].UpdateGenerateTime();

            if (generatePosList[i].Should_Generate(generateInterval))
            {
                Transform passPos = effectWays[generatePosList[i].PosNum_GenerateEffect];//�G�t�F�N�g�𐶐�����n�_��ݒ�

                bool isLastPoint = (generatePosList[i].PosNum_GenerateEffect == effectWays.Length - 1);//�ŏI�n�_��

                EffectType_AlongWay effectType = EffectType(generatePosList[i].Type);//�G�t�F�N�g�^�C�v

                GameObject effect = isLastPoint ? effectType.LandEffect() : effectType.PassEffect();//�ŏI�n�_�Ȃ璅�e�G�t�F�N�g�������łȂ��Ȃ�`���G�t�F�N�g�ɐݒ�

                Instantiate(effect, passPos.position, passPos.rotation, passPos);//����

                generatePosList[i].TransitNextPos();//���̏ꏊ��ݒ�
            }
        }
    }


    void DestroyGeneratePos()//�ŏI�n�_�ŃG�t�F�N�g���o����PassPos�C���X�^���X������
    {
        while (true)
        {
            if (generatePosList.Count == 0) break;

            if (generatePosList[0].PosNum_GenerateEffect >= effectWays.Length)
            {
                generatePosList.RemoveAt(0);//�폜
            }
            else
            {
                break;
            }
        }
    }

    //�g���b�N���ɌĂяo��
    public void ActivateEffect()
    {
        GenerateType_AlongWay generateType=critical.CriticalNow? GenerateType_AlongWay.critical : GenerateType_AlongWay.normal;
        generatePosList.Add(new Pos_AlongWay(generateType, generateInterval));
        generatePosList.Add(new Pos_AlongWay(generateType, generateInterval));
    }

    EffectType_AlongWay EffectType(GenerateType_AlongWay generateType)//�����̃G�t�F�N�g�̐����^�C�v���炻��ɑΉ������G�t�F�N�g�^�C�v��Ԃ�
    {
        switch(generateType)
        {
            case GenerateType_AlongWay.normal: return normalTrickEffect;
            case GenerateType_AlongWay.critical: return criticalTrickEffect;
            default: return null;
        }
    }
}


class Pos_AlongWay
{
    GenerateType_AlongWay type;
    int posNum_GenerateEffect;//�G�t�F�N�g���o���n�_�̗v�f�ԍ�
    float generateTime;//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞��


    public GenerateType_AlongWay Type { get { return type; } }
    public int PosNum_GenerateEffect { get { return posNum_GenerateEffect; } }
    public float GenerateTime { get { return generateTime; } }

    //�R���X�g���N�^
    public Pos_AlongWay(GenerateType_AlongWay generateType,float defaultTime)
    {
        type = generateType;
        posNum_GenerateEffect = 0;
        generateTime = defaultTime;
    }

    public bool Should_Generate(float transitNextPosInterval)//�G�t�F�N�g�𐶐�����Ȃ�true��Ԃ�
    {
        return (generateTime >= transitNextPosInterval);
    }

    public void TransitNextPos()//���̒n�_�ɐݒ�
    {
        posNum_GenerateEffect++;//���̏ꏊ��ݒ�
        generateTime = 0;//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞�Ԃ����Z�b�g
    }

    public void UpdateGenerateTime()//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞�Ԃ��X�V
    {
        generateTime += Time.deltaTime;
    }
}
