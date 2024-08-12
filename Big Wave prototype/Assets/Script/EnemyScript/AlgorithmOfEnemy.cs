using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AlgorithmOfEnemy : MonoBehaviour
{
    [Header("�ŏ��̍s���p�^�[��")]
    [SerializeField] ActionPattern firstActionPattern;//�ŏ��̍s���p�^�[��
    private float currentActionTime = 0;//���݂̍s������
    private float actionTime;//�s�����ԁA���݂̍s������(currentActionTime)������ȏ�ɂȂ�����s����ύX����
    private ActionPattern currentActionPattern;//���݂̍s���p�^�[��
    SelectActionOfEnemy selectAction;
    // Start is called before the first frame update
    void Start()
    {
        selectAction=GetComponent<SelectActionOfEnemy>();

        ChangeAction(firstActionPattern);//�ŏ��̍s����ݒ�
    }

    // Update is called once per frame
    void Update()
    {
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

    void ChangeAction(ActionPattern nextActionPattern)//�s���ύX
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
