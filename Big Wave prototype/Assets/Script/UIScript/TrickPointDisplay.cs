using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrickPointDisplay : MonoBehaviour
{
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

    TrickPoint player_TrickPoint;

    // Start is called before the first frame update
    void Start()
    {
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();
        //�g���b�N�Q�[�W�̐���(�Q�[�W����)
        GenerateTrickGauge();
        //�g���b�N�Q�[�W�̈ʒu����
        PositioningTrickGauge();
    }

    // Update is called once per frame
    void Update()
    {
        TRICKGaugeOfPlayer();//�v���C���[�̃g���b�N�Q�[�W�̏���
    }

    void GenerateTrickGauge()//�g���b�N�Q�[�W�̐���(�Q�[�W����)
    {
        trickGauges = new GameObject[player_TrickPoint.TrickGaugeNum];
        for (int i = 0; i < trickGauges.Length; i++)
        {
            trickGauges[i] = Instantiate(trickGaugeOfPlayer, outOfTrickGaugeOfPlayer.transform);
        }
    }

    void PositioningTrickGauge()//�g���b�N�Q�[�W�̈ʒu����
    {
        //���������̃g���b�N�Q�[�W��(����)�傫�����擾
        Vector2 sd_OutOfTrickGauge = outOfTrickGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
        //��������Ă���g���b�N�Q�[�W�̑傫�������߂�(�S�ē����傫��)
        Vector2 sd_TrickGauge = trickGauges[0].GetComponent<RectTransform>().sizeDelta;
        sd_TrickGauge.x = (sd_OutOfTrickGauge.x - (trickGauges.Length - 1) * trickGaugeInterval) / trickGauges.Length;
        sd_TrickGauge.y = sd_OutOfTrickGauge.y;

        //��������Ă���g���b�N�Q�[�W�̑傫���ƈʒu��ύX
        for (int i = 0; i < trickGauges.Length; i++)
        {
            //�傫����ύX
            trickGauges[i].GetComponent<RectTransform>().sizeDelta = sd_TrickGauge;
            //�ʒu��ύX
            Vector3 pos_TrickGauge;
            pos_TrickGauge = trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

            //��ڂ̃Q�[�W�͍��[�̂ǂ��ɒu���������߂�
            if (i == 0)
            {
                pos_TrickGauge.x = -sd_OutOfTrickGauge.x / 2 + sd_TrickGauge.x / 2;
            }
            //����ȍ~�̃Q�[�W�͑O�ɒu�����Q�[�W�ƈ��Ԋu�Œu��
            else
            {
                Vector3 pos_BeforeTrickGauge = trickGauges[i - 1].GetComponent<RectTransform>().anchoredPosition3D;
                pos_TrickGauge.x = pos_BeforeTrickGauge.x + sd_TrickGauge.x + trickGaugeInterval;
            }

            pos_TrickGauge.y = 0;
            trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_TrickGauge;
        }
    }

    void TRICKGaugeOfPlayer()//�v���C���[�̃g���b�N�Q�[�W�̏���
    {
        for (int i = 0; i < trickGauges.Length; i++)
        {
            float trickRatio = player_TrickPoint.TrickPoint_[i] / player_TrickPoint.TrickPointMax;
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
}
