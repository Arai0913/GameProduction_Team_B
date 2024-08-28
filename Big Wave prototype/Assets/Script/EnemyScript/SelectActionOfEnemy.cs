using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s���p�^�[����I��ŕԂ�

[System.Serializable]
class Form//�`��
{
    [Header("�����̌`�Ԃ̍s���p�^�[��")]
    [SerializeField] ActionPattern[] actionPatterns;//�s���Ƃ��̍s���m���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
    private float actionProbabilitySum = 0;//�s���m��(attackProbability)�̍��v�A�s���������_���Ɍ��߂鎞�Ɏg��

    public ActionPattern[] ActionPatterns
    {
        get { return actionPatterns; }
    }

    public float ActionProbabilitySum
    {
        get { return actionProbabilitySum; }
    }

    public void CalculateActionProbabilitySum()//�s���m���̍��v�����߂�
    {
        for (int i = 0; i < actionPatterns.Length; i++)
        {
            actionProbabilitySum += actionPatterns[i].ActionProbability;//���̌`�Ԃ̑S�Ă̍s���̍s���m���𑫂�
        }
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

public class SelectActionOfEnemy : MonoBehaviour
{
    [Header("���G�̌`�Ԃ��Ƃ̍s��")]
    [SerializeField] Form[] forms;//�`�Ԃ��Ƃ̍s���p�^�[��
    [Header("�����݂̌`�Ԃ�Ԃ��R���|�[�l���g")]
    [SerializeField] FormOfEnemyTypeBase formOfEnemy;//���݂̌`�Ԃ�Ԃ��R���|�[�l���g

    // Start is called before the first frame update
    void Start()
    {
        //�S�Ă̌`�Ԃ̍s���m���̍��v���Z�o
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].CalculateActionProbabilitySum();
        }
    }

    public ActionPattern SelectAction()//�s���ύX
    {
        int formNum = formOfEnemy.CurrentForm();//���ݑ扽�`�Ԃ��Aforms�̗v�f�ԍ��l�Ȃ̂łɓ����v�f�Ⴆ�Α��`�ԂȂ�1������

        //�s���������_���Ō���
        float actionPatternNumber = Random.Range(0, forms[formNum].ActionProbabilitySum);

        //�ǂ̍s���p�^�[�������邩�̌���Ɏg�p
        int actionNum = 0;
        float actionNumProbabilitySum = 0f;

        //�ǂ̍s�������邩���肷�邽�߂̏���
        for (int i = 0; i < forms[formNum].ActionPatterns.Length; i++)
        {
            //���̍U���p�^�[���̊m���𑫂�
            actionNumProbabilitySum += forms[formNum].ActionPatterns[i].ActionProbability;

            //�����_���ŏo�����l��actionProbabilitySum�����ł���΍U������
            if (actionPatternNumber < actionNumProbabilitySum)
            {
                break;
            }

            //���܂�Ȃ���Ύ��̍U���̔����
            actionNum++;
        }

        return forms[formNum].ActionPatterns[actionNum];
    }
}
