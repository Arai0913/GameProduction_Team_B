using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//��߂�ꂽ�ӏ������ɃG�t�F�N�g�𐶐����Ă���
public class GenerateEffectAlongWay : MonoBehaviour
{
    [Header("�G�t�F�N�g�̒ʂ�n�_")]
    [SerializeField] Transform[] effectWays;//�G�t�F�N�g�̒ʂ�n�_�A�ŏ��̒n�_����w�莞�Ԃ��Ƃɐi��ł����čŌ�̒n�_�Œ��e�G�t�F�N�g���o��
    [Header("�`�����̃G�t�F�N�g")]
    [SerializeField] GameObject passEffect;//�`�����̃G�t�F�N�g
    [Header("���e���̃G�t�F�N�g")]
    [SerializeField] GameObject landEffect;//���e���̃G�t�F�N�g
    [Header("���̒n�_�ɐi�ނ܂ł̕b��")]
    [SerializeField] float generateInterval;//�G�t�F�N�g�𐶐�����C���^�[�o��
    [Header("���e���ɌĂяo�������C�x���g")]
    [SerializeField] UnityEvent landEvents;//���e���ɌĂяo�������C�x���g
    [Header("���e��(��N���e�B�J��)�ɌĂяo�������C�x���g")]
    [SerializeField] UnityEvent landEvents_F;
    [SerializeField] Critical critical;
  
    private List<GenerateEffectPos_AlongWay> generatePosList=new List<GenerateEffectPos_AlongWay>();
    private Queue<bool> C_Trick=new Queue<bool>();

    //public Queue<bool> c_Trick
    //{
    //    get { return C_Trick; }
    //    set { C_Trick = value; }
    //}
    void Update()
    {
        GenerateEffectAtGeneratePos();
        DestroyGeneratePos();
    }

    void GenerateEffectAtGeneratePos()//�ʂ�n�_�ɃG�t�F�N�g�𐶐�
    {
        for(int i=0; i<generatePosList.Count;i++)
        {
            generatePosList[i].UpdateGenerateTime();

            if(generatePosList[i].Should_Generate(generateInterval))
            {
                Transform passPos= effectWays[generatePosList[i].PosNum_GenerateEffect];//�G�t�F�N�g�𐶐�����n�_��ݒ�

                bool isLastPoint = (generatePosList[i].PosNum_GenerateEffect == effectWays.Length - 1);//�ŏI�n�_��

                GameObject effect = isLastPoint ? landEffect : passEffect;//�ŏI�n�_�Ȃ璅�e�G�t�F�N�g�������łȂ��Ȃ�`���G�t�F�N�g�ɐݒ�

                Instantiate(effect, passPos.position, passPos.rotation, passPos);//����

               
                if (isLastPoint && C_Trick.Peek())//�N���e�B�J���̂�����e��
                {
                    landEvents.Invoke();//���e�Ȃ璅�e���ɓo�^���Ă����C�x���g���Ăяo��
                    C_Trick.Dequeue();
                }
                else if (isLastPoint)//���ʂ̂���e��
                {
                    landEvents_F.Invoke();
                    C_Trick.Dequeue();
                }
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
        C_Trick.Enqueue(critical.CriticalNow);
        GenerateEffectPos_AlongWay generatePos=new GenerateEffectPos_AlongWay(generateInterval);//�g���b�N�������炷���ɓd�����o��悤�ɂ���
        generatePosList.Add(generatePos);
    }
}


//�G�t�F�N�g�𐶐�����n�_�ƃ^�C�~���O���Ǘ����Ă���
class GenerateEffectPos_AlongWay
{
    int posNum_GenerateEffect;//�G�t�F�N�g���o���n�_�̗v�f�ԍ�
    float generateTime;//�G�t�F�N�g�𐶐�����^�C�~���O���Ǘ����鎞��

    public int PosNum_GenerateEffect { get {  return posNum_GenerateEffect; } }
    public float GenerateTime { get { return generateTime; } }

    //�R���X�g���N�^
    public GenerateEffectPos_AlongWay(float time)
    {
        posNum_GenerateEffect = 0;
        generateTime = time;
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
