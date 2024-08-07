using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Critical : MonoBehaviour
{
    [Header("�_���[�W�̑����{��")]
    [SerializeField] float criticalRate;//�N���e�B�J�����̃_���[�W�̑����{��
    [Header("�N���e�B�J�����̌��ʉ�")]
    [SerializeField] AudioClip criticalSound;//�N���e�B�J�����̌��ʉ�
    private Button[] criticalButton;//�w�肳�ꂽ�{�^���̔z��([0]�����ݎw�肳��Ă���{�^���A[1]����ԖڂɎw�肳��Ă���{�^��...)
    AudioSource audioSource;
    TRICKPoint player_TrickPoint;

    public Button[] CriticalButton
    {
        get { return criticalButton; }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player_TrickPoint = GetComponent<TRICKPoint>();
        criticalButton = new Button[player_TrickPoint.TrickGaugeNum];//�v���C���[�̃g���b�N�Q�[�W�̖{����criticalButton�̔z���p�ӂ���
        StartAllocateButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAllocateButton()//�ŏ��ɑS�Ă�criticalButton�Ƀ{�^�������蓖�Ă�
    {
        for(int i=0; i<criticalButton.Length;i++)
        {
            AllocateButton(ref criticalButton[i]);
        }
    }

    public float Method1(Button button)
    {
        if (button == criticalButton[0])//���͂����{�^�����w�肳�ꂽ�{�^����������
        {
            audioSource.PlayOneShot(criticalSound);//���ʉ��̍Đ�

            for(int i=1; i<criticalButton.Length ;i++)//[0](���ݎw�肳��Ă���)�{�^���ȊO�̑S�Ẵ{�^����1�O([0]����)�ɂ��炷
            {
                criticalButton[i - 1] = criticalButton[i];
            }

            AllocateButton(ref criticalButton[criticalButton.Length - 1]);//�{�^���̔z��̍Ō�̃{�^���Ɋ��蓖��

            return criticalRate;//�N���e�B�J�����̔{����Ԃ�
        }
        return 1;//���{��Ԃ�
    }

    void AllocateButton(ref Button button)//�{�^���̊��蓖��(�����_��)
    {
        //enum�^��Button�̗v�f�����擾
        int max = Enum.GetNames(typeof(Button)).Length;
        //�����_���Ȑ������擾
        int num = UnityEngine.Random.Range(0, max);
        //�擾���������_���Ȑ�����enum�^:Button�ɕϊ�����criticalButton�ɓ����
        button = (Button)Enum.ToObject(typeof(Button), num);
    }

}
