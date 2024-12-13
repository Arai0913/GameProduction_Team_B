using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//(���݂�)�s���p�^�[����ݒ肵�āA���̍s���p�^�[���̏���������
public class AlgorithmOfEnemy : MonoBehaviour
{
    [Header("�ŏ��̍s���p�^�[��")]
    [SerializeField] ActionPattern firstActionPattern;//�ŏ��̍s���p�^�[��
    [Header("�s���I��")]
    [SerializeField] SelectActionOfEnemyTypeBase selectAction;//�s���I��
    private float currentActionTime = 0;//���݂̍s������
    private float actionTime;//�s�����ԁA���݂̍s������(currentActionTime)������ȏ�ɂȂ�����s����ύX����
    private ActionPattern currentActionPattern;//���݂̍s���p�^�[��
    bool _switch = false;//���ꂪfalse�ɂȂ��Ă��鎞�͍s�����Ȃ��Atrue�̎��͍s������
    bool _setFirstAction = false;//�ŏ��̍s�����Z�b�g�������A�Z�b�g����܂ł͍s���̃A���S���Y���𓮂����Ȃ�

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    void Update()
    {
        SetFirstAction();
        Algorithm();
    }

    void SetFirstAction()//�ŏ��̍s���̐ݒ�
    {
        if (_setFirstAction||!_switch) return;//�ŏ��̍s�����Z�b�g�ς݂܂��̓X�C�b�`��OFF�̎��͂��Ȃ�

        ChangeAction(firstActionPattern);//�ŏ��̍s����ݒ�
        _setFirstAction=true;
    }

    void Algorithm()//�s���A���S���Y���̏���
    {
        if (!_setFirstAction || !_switch) return;//�ŏ��̍s�������Z�b�g�Z�b�g�܂��̓X�C�b�`��OFF�̎��͓������Ȃ�

        currentActionTime += Time.deltaTime;

        bool actionNow = (currentActionTime < actionTime);//���ݍs�����Ă��邩

        if (actionNow)//�s����
        {
            //���݂̍s���̖��t���[���̏���
            for (int i = 0; i < currentActionPattern.Action.Length; i++)
            {
                currentActionPattern.Action[i].OnUpdate();
            }
        }
        else//�s���I��
        {
            ChangeAction(selectAction.SelectAction());//�s���ύX
        }
    }

    public void ChangeAction(ActionPattern nextActionPattern)//�s���ύX
    {
        //���݂̍s���̍s���I�����̏���

        if(currentActionPattern!=null)//�ŏ��̍s���̐ݒ�ȍ~�̎�
        {
            //�O�̍s���̍s���I�����̏���
            for (int i = 0; i < currentActionPattern.Action.Length; i++)
            {
                currentActionPattern.Action[i].OnExit(nextActionPattern.Action);
            }

            //���̍s���̍s���J�n���̏���
            for (int i = 0; i < nextActionPattern.Action.Length; i++)
            {
                nextActionPattern.Action[i].OnEnter(currentActionPattern.Action);
            }
        }
        else//�ŏ��̍s����ݒ肷�鎞
        {
            //���̍s���̍s���J�n���̏���
            for (int i = 0; i < nextActionPattern.Action.Length; i++)
            {
                nextActionPattern.Action[i].OnEnter(null);
            }
        }

        //���݂̍s�������̍s���ɕύX
        currentActionPattern = nextActionPattern;
        //���݂̍s�����Ԃ����Z�b�g
        currentActionTime = 0;
        //�s�����Ԃ��X�V
        actionTime = currentActionPattern.ActionTime;
    }
}
