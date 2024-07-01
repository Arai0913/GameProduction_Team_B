using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    //������������
    //�v���C���[��HP�֘A
    [Header("���v���C���[��HP�Q�[�W")]
    [SerializeField] GameObject hpGaugeOfPlayer;//�v���C���[��HP�Q�[�W

    //�v���C���[�̃g���b�N�|�C���g�֘A
    [Header("���v���C���[�̃g���b�N�Q�[�W�̍�������")]
    [SerializeField] GameObject outOfTrickGaugeOfPlayer;//�v���C���[�̃g���b�N�Q�[�W�̍�������
    [Header("���v���C���[�̃g���b�N�Q�[�W")]
    [SerializeField] GameObject trickGaugeOfPlayer;//�v���C���[�̃g���b�N�Q�[�W
    [Header("���������ꂽ�g���b�N�Q�[�W���ǂꂭ�炢������")]
    [SerializeField] float trickGaugeInterval;//�������ꂽ�g���b�N�Q�[�W���ǂꂭ�炢������
    [Header("���ʏ��Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color trickGaugeNormalColor;//�ʏ��Ԃ̃g���b�N�Q�[�W�̐F
    [Header("�����^����Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color trickGaugeMaxColor;//���^����Ԃ̃g���b�N�Q�[�W�̐F
    private GameObject[] trickGauges;//�v���C���[�̃g���b�N�Q�[�W(���������p)

    //�v���C���[�̃t�B�[�o�[�|�C���g�֘A
    [Header("���v���C���[�̃t�B�[�o�[�Q�[�W")]
    [SerializeField] GameObject feverGaugeOfPlayer;//�v���C���[�̃t�B�[�o�[�Q�[�W
    [Header("���ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeNormalColor;//�ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F
    [Header("���t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeFeverModeColor;//�t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F

    //�v���C���[�̃o�t�X�g�b�N�֘A
    [Header("���o�t�̃X�g�b�N����\���Q�[�W�̍�������")]
    [SerializeField] GameObject outOfBuffStockGaugeOfPlayer;//�o�t�̃X�g�b�N����\���Q�[�W�̍�������
    [Header("���o�t�̃X�g�b�N����\���Q�[�W")]
    [SerializeField] GameObject buffStockGaugeOfPlayer;//�o�t�̃X�g�b�N����\���Q�[�W
    [Header("���������ꂽ�o�t�X�g�b�N�Q�[�W���ǂꂭ�炢������")]
    [SerializeField] float buffStockGaugeInterval;//�������ꂽ�o�t�X�g�b�N�Q�[�W���ǂꂭ�炢������
    [Header("�����^����Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color buffStockedGaugeColor;//�X�g�b�N��Ԃ̃o�t�X�g�b�N�Q�[�W�̐F
    private GameObject[] buffStockGauges;//�v���C���[�̃o�t�X�g�b�N�Q�[�W(���������p)


    //�G��HP�֘A
    [Header("���G��HP�Q�[�W")]
    [SerializeField] GameObject hpGaugeOfEnemy;//�G��HP�Q�[�W

    Enemy enemy;
    Player player;
    ProcessFeverMode processFeverPoint;
    BuffOfPlayer buffOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        processFeverPoint= GameObject.FindWithTag("Player").GetComponent<ProcessFeverMode>();
        buffOfPlayer = GameObject.FindWithTag("Player").GetComponent<BuffOfPlayer>();
        //�g���b�N�Q�[�W�̐���(�Q�[�W����)
        GenerateTrickGauge();
        //�g���b�N�Q�[�W�̈ʒu����
        PositioningTrickGauge();

        //�o�t�X�g�b�N�Q�[�W�̐���(�Q�[�W����)
        GenerateBuffStockGauge();
        //�o�t�X�g�b�N�Q�[�W�̈ʒu����    
        PositioningBuffStockGauge();
    }

    // Update is called once per frame
    void Update()
    {
        HPGaugeOfPlayer();//�v���C���[��HP�Q�[�W�̏���

        TRICKGaugeOfPlayer();//�v���C���[�̃g���b�N�Q�[�W�̏���

        FeverGaugeOfPlayer();//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���

        HPGaugeOfEnemy();//�G��HP�Q�[�W�̏���

        BuffStockGaugeOfPlayer();//�v���C���[�̃o�t�X�g�b�N�Q�[�W�̏���
    }

    //�v���C���[��HP�֌W�̃��\�b�h

    void HPGaugeOfPlayer()//�v���C���[��HP�Q�[�W�̏���
    {
        float hpRatio = player.Hp / player.HpMax;
        hpGaugeOfPlayer.GetComponent<Image>().fillAmount = hpRatio;
    }


    //�v���C���[�̃g���b�N�|�C���g�֌W�̃��\�b�h

    void GenerateTrickGauge()//�g���b�N�Q�[�W�̐���(�Q�[�W����)
    {
        trickGauges=new GameObject[player.TrickGaugeNum];
        for(int i=0; i<trickGauges.Length;i++)
        {
            trickGauges[i] = Instantiate(trickGaugeOfPlayer,outOfTrickGaugeOfPlayer.transform);
        }
    }

    void PositioningTrickGauge()//�g���b�N�Q�[�W�̈ʒu����
    {
        //���������̃g���b�N�Q�[�W��(����)�傫�����擾
        Vector2 sd_OutOfTrickGauge = outOfTrickGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
        //��������Ă���g���b�N�Q�[�W�̑傫�������߂�(�S�ē����傫��)
        Vector2 sd_TrickGauge = trickGauges[0].GetComponent<RectTransform>().sizeDelta;
        sd_TrickGauge.x = ( sd_OutOfTrickGauge.x-(trickGauges.Length-1)*trickGaugeInterval )/ trickGauges.Length;
        sd_TrickGauge.y = sd_OutOfTrickGauge.y;

        //��������Ă���g���b�N�Q�[�W�̑傫���ƈʒu��ύX
        for(int i=0;i<trickGauges.Length ;i++)
        {
            //�傫����ύX
            trickGauges[i].GetComponent<RectTransform>().sizeDelta = sd_TrickGauge;
            //�ʒu��ύX
            Vector3 pos_TrickGauge;
            pos_TrickGauge = trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

            //��ڂ̃Q�[�W�͍��[�̂ǂ��ɒu���������߂�
            if (i==0)
            {
                pos_TrickGauge.x = -sd_OutOfTrickGauge.x / 2 + sd_TrickGauge.x / 2;
            }
            //����ȍ~�̃Q�[�W�͑O�ɒu�����Q�[�W�ƈ��Ԋu�Œu��
            else
            {
                Vector3 pos_BeforeTrickGauge= trickGauges[i-1].GetComponent<RectTransform>().anchoredPosition3D;
                pos_TrickGauge.x = pos_BeforeTrickGauge.x + sd_TrickGauge.x + trickGaugeInterval;
            }

            pos_TrickGauge.y =0;
            trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_TrickGauge;
        }
    }

    void TRICKGaugeOfPlayer()//�v���C���[�̃g���b�N�Q�[�W�̏���
    {
        for(int i=0; i<trickGauges.Length;i++)
        {
            float trickRatio = player.TrickPoint[i] / player.TrickPointMax;
            trickGauges[i].GetComponent<Image>().fillAmount = trickRatio;

            
            //�Q�[�W�̐F�̕ύX
            if (trickRatio == 1)//���^�����̐F
            {
                trickGauges[i].GetComponent<Image>().color = trickGaugeMaxColor;
            }
            else//����ȊO�̎��̐F
            {
                trickGauges[i].GetComponent<Image>().color = trickGaugeNormalColor;
            }
        }
    }


    //�v���C���[�̃t�B�[�o�[�|�C���g�֌W�̃��\�b�h

    void FeverGaugeOfPlayer()//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    {
        float feverRatio = player.FeverPoint / player.FeverPointMax;
        feverGaugeOfPlayer.GetComponent<Image>().fillAmount = feverRatio;
        //�Q�[�W�̐F�̕ύX
        if(processFeverPoint.FeverNow)//�t�B�[�o�[��Ԃ̎�
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeFeverModeColor;
        }
        else//�ʏ펞
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeNormalColor;
        }
    }

    //�v���C���[�̃o�t�X�g�b�N�֌W�̃��\�b�h
    void GenerateBuffStockGauge()
    {
        buffStockGauges = new GameObject[buffOfPlayer.TrickBoost.BuffStockMax];

        for (int i = 0; i < buffStockGauges.Length; i++)
        {
            buffStockGauges[i] = Instantiate(buffStockGaugeOfPlayer,
                outOfBuffStockGaugeOfPlayer.transform);
        }
    }

    void PositioningBuffStockGauge()//�o�t�X�g�b�N�Q�[�W�̈ʒu����
    {
        //���������̃o�t�X�g�b�N�Q�[�W��(����)�傫�����擾
        Vector2 sd_OutOfBuffStockGauge = outOfBuffStockGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
        //��������Ă���o�t�X�g�b�N�Q�[�W�̑傫�������߂�(�S�ē����傫��)
        Vector2 sd_BuffStockGauge = buffStockGauges[0].GetComponent<RectTransform>().sizeDelta;
        sd_BuffStockGauge.x = (sd_OutOfBuffStockGauge.x - (buffStockGauges.Length - 1) * buffStockGaugeInterval) / buffStockGauges.Length;
        sd_BuffStockGauge.y = sd_OutOfBuffStockGauge.y;

        //��������Ă���o�t�X�g�b�N�Q�[�W�̑傫���ƈʒu��ύX
        for (int i = 0; i < buffStockGauges.Length; i++)
        {
            //�傫����ύX
            buffStockGauges[i].GetComponent<RectTransform>().sizeDelta = sd_BuffStockGauge;
            //�ʒu��ύX
            Vector3 pos_BuffStockGauge;
            pos_BuffStockGauge = buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

            //��ڂ̃Q�[�W�͍��[�̂ǂ��ɒu���������߂�
            if (i == 0)
            {
                pos_BuffStockGauge.x = -sd_OutOfBuffStockGauge.x / 2 + sd_BuffStockGauge.x / 2;
            }
            //����ȍ~�̃Q�[�W�͑O�ɒu�����Q�[�W�ƈ��Ԋu�Œu��
            else
            {
                Vector3 pos_BeforeBuffStockGauge = buffStockGauges[i - 1].GetComponent<RectTransform>().anchoredPosition3D;
                pos_BuffStockGauge.x = pos_BeforeBuffStockGauge.x + sd_BuffStockGauge.x + buffStockGaugeInterval;
            }

            pos_BuffStockGauge.y = 0;
            buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_BuffStockGauge;
        }
    }

    void BuffStockGaugeOfPlayer()//�v���C���[�̃o�t�X�g�b�N�Q�[�W�̏���
    {
        int buffStockCount = buffOfPlayer.TrickBoost.BuffStockCount;

        for (int i = 0; i < buffStockGauges.Length; i++)
        {
            if (i < buffStockCount)
            {
                buffStockGauges[i].GetComponent<Image>().color = buffStockedGaugeColor;
            }

            else
            {
                buffStockGauges[i].GetComponent<Image>().color = Color.clear;
            }
        }
    }




    //�G��HP�֌W�̃��\�b�h

    void HPGaugeOfEnemy()//�G��HP�Q�[�W�̏���
    {
        if (enemy != null)
        {
            float enemy_HpRatio = enemy.Hp / enemy.HpMax;
            hpGaugeOfEnemy.GetComponent<Image>().fillAmount = enemy_HpRatio;
        }
    }
}
