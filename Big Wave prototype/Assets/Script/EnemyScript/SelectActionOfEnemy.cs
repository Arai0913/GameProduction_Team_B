using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
//������������

enum ActionType//�s��
{
    shotStraightMoving,//�����Ȃ��璼����Ɍ���
    shotHomingMoving,//�����Ȃ���z�[�~���O���Ȃ��猂��
    shotHighSlashMoving,//�����Ȃ��獂���a��������
    shotWideWaveMoving,//�����Ȃ��牡�ɍL�����g������
    move,//����
    shotStraightStoping,//�~�܂�Ȃ��璼����Ɍ���
    shotHomingStoping,//�~�܂�Ȃ���z�[�~���O���Ȃ��猂��
    shotHighSlashStoping,//�~�܂�Ȃ��獂���a��������
    shotWideWaveStoping,//�~�܂�Ȃ��牡�ɍL�����g������
    stop,//�~�܂�
}

[System.Serializable]
class Form//�`��
{
    [Header("�����̌`�Ԃ̍s���p�^�[��")]
    [SerializeField] ActionPattern[] actionPatterns;//�s���Ƃ��̍s���m���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
    [Header("�����̌`�Ԃ̓˓�����HP")]
    [SerializeField] float formHp;//�w��`�ԓ˓������̗�(���̗͈̑ȉ��̎����̌`�ԓ˓�)
    private float actionProbabilitySum = 0;//�U���m��(attackProbability)�̍��v�A�U���������_���Ɍ��߂鎞�Ɏg��

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

class ActionPattern//�s���Ƃ��̍s���m���Ƃ��̍s���̎��ɍs�����n�߂�܂ł̎���
{
    [Header("���s��")]
    [SerializeField] ActionType action;//�s��
    [Header("���s���m��")]
    [SerializeField] float actionProbability;//�s���m��
    [Header("�����ɕʂ̍s�����n�߂�܂ł̎���")]
    [SerializeField] float nextBeginActTime;//���ɍs�����n�߂�܂ł̎���

    public ActionType Action
    {
        get { return action; }
    }

    public float ActionProbability
    {
        get { return actionProbability; }
    }

    public float NextBeginActTime
    {
        get { return nextBeginActTime; }
    }
}

public class SelectActionOfEnemy : MonoBehaviour
{
    [Header("���G���ŏ��ɍs�����n�߂鎞��")]
    [SerializeField] float firstBeginActTime = 5f;//�G�����ɍs�����n�߂鎞��(����)
    [Header("���G�̌`�Ԃ��Ƃ̍s��")]
    [SerializeField] Form[] forms;//�`�Ԃ��Ƃ̍s���p�^�[��
    private float beginActTime;//�G�����ɍs�����n�߂鎞��
    private float actTime = 0f;//�G�̍s�����Ǘ����鎞��
    //[SerializeField] Quaternion []attackRotation=new Quaternion [4];//���ɍL�����g�̊p�x

    Enemy enemy;
    ActOfEnemy actOfEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        actOfEnemy = gameObject.GetComponent<ActOfEnemy>();
        for (int i = 0; i < forms.Length; i++)
        {
            for (int j = 0; j < forms[i].ActionPatterns.Length; j++)
            {
                forms[i].ActionProbabilitySum += forms[i].ActionPatterns[j].ActionProbability;
            }
        }
        forms[0].FormHp = enemy.HpMax;
        beginActTime = firstBeginActTime;
    }

    // Update is called once per frame
    void Update()
    {
        ActTiming();
    }

    void ActTiming()//�G�̍U���^�C�~���O
    {
        actTime += Time.deltaTime;

        if (actTime > beginActTime)
        {
            for (int i = forms.Length - 1; 0 <= i; i--)//�w��̗͈ȉ��ł��̌`�Ԃ̍s��������(�ŏI�`�Ԃ̏������珇�Ɍ��Ă���)
            {
                if (enemy.Hp <= forms[i].FormHp)//i+1�`�Ԗڂ̏������m�F
                {
                    actTime = 0f;
                    SelectAction(i + 1);
                    break;
                }
            }
        }
    }

    void SelectAction(int a)//�U����I������Aa�͉��`�Ԗڂ�
    {
        //�U���������_���Ō���
        float attackPatternNumber = Random.Range(0, forms[a-1].ActionProbabilitySum);

        int action = 0;//�G�̍U���p�^�[���A�ǂ̍U���p�^�[�������邩���肷��Ƃ��Ɏg�p
        float actionProbabilitySum = 0f;

        //�ǂ̍U�������邩���肷�邽�߂̏���
        //
        //
        for (int i = 0; i < forms[a - 1].ActionPatterns.Length; i++)
        {
            //���̍U���p�^�[���̊m���𑫂�
            actionProbabilitySum += forms[a - 1].ActionPatterns[i].ActionProbability;

            //�����_���ŏo�����l��attackSum�����ł���΍U������
            if (attackPatternNumber < actionProbabilitySum)
            {
                break;
            }

            //���܂�Ȃ���Ύ��̍U���̔����
            action++;
        }
        //Debug.Log(enemy.Forms[a - 1].ActionProbabilitySum + ":::" + attackPatternNumber + ":::" + actionProbabilitySum);

        //�s��
        switch (forms[a - 1].ActionPatterns[action].Action)
        {
            case ActionType.shotStraightMoving: actOfEnemy.ShotStraight(); actOfEnemy.Move(); break;//�����Ȃ��璼����Ɍ���
            case ActionType.shotHomingMoving: actOfEnemy.ShotHoming(); actOfEnemy.Move(); break;//�����Ȃ���z�[�~���O���Ȃ��猂��
            case ActionType.shotHighSlashMoving: actOfEnemy.ShotHighSlash(); actOfEnemy.Move(); break;//�����Ȃ��獂���a��������
            case ActionType.shotWideWaveMoving: actOfEnemy.ShotWideWave(); actOfEnemy.Move();break;//�����Ȃ��牡�ɍL�����g������
            case ActionType.move: actOfEnemy.Move(); break;//����
            case ActionType.shotStraightStoping: actOfEnemy.ShotStraight(); break;//�~�܂�Ȃ��璼����Ɍ���
            case ActionType.shotHomingStoping: actOfEnemy.ShotHoming(); break;//�~�܂�Ȃ���z�[�~���O���Ȃ��猂��
            case ActionType.shotHighSlashStoping: actOfEnemy.ShotHighSlash(); break;//�~�܂�Ȃ��獂���a��������
            case ActionType.shotWideWaveStoping: actOfEnemy.ShotWideWave(); break;//�~�܂�Ȃ��牡�ɍL�����g������
            case ActionType.stop: actOfEnemy.Stop(); break;//�~�܂�
        }

        //beginActTime(�G�����ɍs�����n�߂鎞��)���X�V
        beginActTime = forms[a - 1].ActionPatterns[action].NextBeginActTime;

    }
    
}
