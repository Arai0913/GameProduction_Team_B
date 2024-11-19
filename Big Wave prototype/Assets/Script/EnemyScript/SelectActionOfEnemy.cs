using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�s���p�^�[����I��ŕԂ�

[System.Serializable]
public class ActionPattern//�s���Ƃ��̍s���m���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
{
    [Header("���s��")]
    [SerializeField] EnemyActionTypeBase[] action;//�s��
    [Header("���s������")]
    [SerializeField] float actionTime;//�s������

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}

public class SelectActionOfEnemy : MonoBehaviour
{
    [Header("���G�̌`�Ԃ��Ƃ̍s��")]
    [SerializeField] ProbabilityGet<ActionPattern>[] forms;//�`�Ԃ��Ƃ̍s���p�^�[��
    [Header("�����݂̌`�Ԃ�Ԃ��R���|�[�l���g")]
    [SerializeField] FormOfEnemyTypeBase formOfEnemy;//���݂̌`�Ԃ�Ԃ��R���|�[�l���g

    void Start()
    {
        //�S�Ă̌`�Ԃ̍s���m���̍��v���Z�o
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].Start();
        }
    }

    public ActionPattern SelectAction()//�s���ύX
    {
        int formNum = formOfEnemy.CurrentForm();//���ݑ扽�`�Ԃ��Aforms�̗v�f�ԍ��l�Ȃ̂łɓ����v�f�Ⴆ�Α��`�ԂȂ�1������

        return forms[formNum].Get();
    }
}
