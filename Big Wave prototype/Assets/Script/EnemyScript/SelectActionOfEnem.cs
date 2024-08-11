using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Form//�`��
{
    [Header("�����̌`�Ԃ̍s���p�^�[��")]
    [SerializeField] ActionPattern[] actionPatterns;//�s���Ƃ��̍s���m���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
    [Header("�����̌`�Ԃ̓˓�����HP")]
    [SerializeField] float formHp;//�w��`�ԓ˓������̗�(���̗͈̑ȉ��̎����̌`�ԓ˓�)
    private float actionProbabilitySum = 0;//�s���m��(attackProbability)�̍��v�A�s���������_���Ɍ��߂鎞�Ɏg��

    public ActionPattern[] ActionPatterns
    {
        get { return actionPatterns; }
    }

    public float ActionProbabilitySum
    {
        set { actionProbabilitySum = value; }
        get { return actionProbabilitySum; }
    }

    public float FormHp
    {
        set { formHp = value; }
        get { return formHp; }
    }
}

[System.Serializable]

public class ActionPattern//�s���Ƃ��̍s���m���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
{
    [Header("���s��")]
    [SerializeField] EnemyActionTypeBase[] action;//�s��
    [Header("���s���m��")]
    [SerializeField] float actionProbability;//�s���m��
    [Header("���s������")]
    [SerializeField] float actionTime;//�s������

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionProbability
    {
        get { return actionProbability; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}

public class SelectActionOfEnem : MonoBehaviour
{
    [Header("���G�̌`�Ԃ��Ƃ̍s��")]
    [SerializeField] Form[] forms;//�`�Ԃ��Ƃ̍s���p�^�[��
    HP enemy_Hp;
    // Start is called before the first frame update
    void Start()
    {
        enemy_Hp = gameObject.GetComponent<HP>();
        //�s���m���̍��v���Z�o
        for (int i = 0; i < forms.Length; i++)
        {
            for (int j = 0; j < forms[i].ActionPatterns.Length; j++)
            {
                forms[i].ActionProbabilitySum += forms[i].ActionPatterns[j].ActionProbability;
            }
        }
        //���`�ԓ˓�����HP���ő�HP�ɐݒ�(�ŏ�������`�ԂȂ̂�)
        forms[0].FormHp = enemy_Hp.HpMax;
    }

    public ActionPattern SelectAction()//�s���ύX
    {
        int formNum = CurrentForm();//���ݑ扽�`�Ԃ��Aforms�̗v�f�ԍ��l�Ȃ̂łɓ����v�f�Ⴆ�Α��`�ԂȂ�1������

        //�s���������_���Ō���
        float actionPatternNumber = Random.Range(0, forms[formNum].ActionProbabilitySum);

        //�ǂ̍s���p�^�[�������邩�̌���Ɏg�p
        int action = 0;
        float actionProbabilitySum = 0f;

        //�ǂ̍s�������邩���肷�邽�߂̏���
        for (int i = 0; i < forms[formNum].ActionPatterns.Length; i++)
        {
            //���̍U���p�^�[���̊m���𑫂�
            actionProbabilitySum += forms[formNum].ActionPatterns[i].ActionProbability;

            //�����_���ŏo�����l��actionProbabilitySum�����ł���΍U������
            if (actionPatternNumber < actionProbabilitySum)
            {
                break;
            }

            //���܂�Ȃ���Ύ��̍U���̔����
            action++;
        }

        return forms[formNum].ActionPatterns[action];
    }

    int CurrentForm()//���݂��扽�`�Ԃ�(forms�̗v�f�ԍ��Ƃ��ē������悤�ɕԂ��̂ŗႦ�΍������`�ԂȂ�1��Ԃ�)��Ԃ�
    {
        for (int i = forms.Length - 1; 0 <= i; i--)//�w��̗͈ȉ��ł��̌`�Ԃ̍s��������(�ŏI�`�Ԃ̏������珇�Ɍ��Ă���)
        {
            if (enemy_Hp.Hp <= forms[i].FormHp)//i+1�`�Ԗڂ̏������m�F
            {
                return i;
            }
        }


        return 0;
    }
}
