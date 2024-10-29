using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�Ō�ɉ������{�^�����N���e�B�J���ɂȂ邩�𔻒�
public class Critical : MonoBehaviour
{
    [Header("�N���e�B�J���������ɌĂяo���C�x���g")]
    [SerializeField] UnityEvent criticalEvents;//�N���e�B�J���������ɌĂяo���C�x���g
    [Header("�N���e�B�J���s�����ɌĂяo���C�x���g")]
    [SerializeField] UnityEvent notCriticalEvents;//�N���e�B�J���s�����ɌĂяo���C�x���g
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;
    [SerializeField] Score_CriticalTrickCount criticalTrickCount;//�N���e�B�J���̃X�R�A
�@�@[SerializeField] AudioSource audioSource;
    [SerializeField] TrickPoint player_TrickPoint;

    bool criticalNow = false;//�Ō�ɉ������{�^�����N���e�B�J����������
    private TrickButton[] criticalButton;//�w�肳�ꂽ�{�^���̔z��([0]�����ݎw�肳��Ă���{�^���A[1]����ԖڂɎw�肳��Ă���{�^��...)

    public bool CriticalNow { get { return criticalNow; } }
    
    public TrickButton[] CriticalButton{ get { return criticalButton; } }

    void Start()
    {
        criticalButton = new TrickButton[player_TrickPoint.TrickGaugeNum];//�v���C���[�̃g���b�N�Q�[�W�̖{����criticalButton�̔z���p�ӂ���
        StartAllocateButton();
    }

    void StartAllocateButton()//�ŏ��ɑS�Ă�criticalButton�Ƀ{�^�������蓖�Ă�
    {
        for(int i=0; i<criticalButton.Length;i++)
        {
            AllocateButton(ref criticalButton[i]);
        }
    }

    public void SetCriticalNow()//�N���e�B�J����������������ݒ�(�����ꂽ�{�^������N���e�B�J���̔���)
    {
        //���͂����{�^�����w�肳��Ă����{�^����������(�N���e�B�J���̎�)
        if(pushedButton_CurrentTrickPattern.PushedButton == criticalButton[0])
        {
            criticalNow = true;

            criticalEvents.Invoke();

            for (int i = 1; i < criticalButton.Length; i++)//[0](���ݎw�肳��Ă���)�{�^���ȊO�̑S�Ẵ{�^����1�O([0]����)�ɂ��炷
            {
                criticalButton[i - 1] = criticalButton[i];
            }

            AllocateButton(ref criticalButton[criticalButton.Length - 1]);//�{�^���̔z��̍Ō�̃{�^���Ɋ��蓖��
        }

        //���͂����{�^�����w�肳��Ă����{�^���ł͂Ȃ�������
        else
        {
            criticalNow=false;

            notCriticalEvents.Invoke();
        }

    }

    void AllocateButton(ref TrickButton button)//�{�^���̊��蓖��(�����_��)
    {
        //enum�^��Button�̗v�f�����擾
        int max = Enum.GetNames(typeof(TrickButton)).Length;
        //�����_���Ȑ������擾
        int num = UnityEngine.Random.Range(0, max);
        //�擾���������_���Ȑ�����enum�^:Button�ɕϊ�����criticalButton�ɓ����
        button = (TrickButton)Enum.ToObject(typeof(TrickButton), num);
    }

}
