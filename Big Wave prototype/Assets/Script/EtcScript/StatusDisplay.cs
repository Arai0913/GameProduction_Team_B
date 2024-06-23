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
    [SerializeField] GameObject playerOfHpGauge;//�v���C���[��HP�Q�[�W
    //�v���C���[�̃g���b�N�֘A
    [Header("���v���C���[�̃g���b�N�Q�[�W�̍�������")]
    [SerializeField] GameObject outOfPlayerOfTrickGauge;//�v���C���[�̃g���b�N�Q�[�W�̍�������
    [Header("���v���C���[�̃g���b�N�Q�[�W")]
    [SerializeField] GameObject playerOfTrickGauge;//�v���C���[�̃g���b�N�Q�[�W
    [Header("���������ꂽ�g���b�N�Q�[�W���ǂꂭ�炢������")]
    [SerializeField] float trickGaugeInterval;//�������ꂽ�g���b�N�Q�[�W���ǂꂭ�炢������
    [Header("���ʏ��Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color trickGaugeNormalColor;
    [Header("�����^����Ԃ̃g���b�N�Q�[�W�̐F")]
    [SerializeField] Color trickGaugeMaxColor;
    private GameObject[] trickGauges;//�v���C���[�̃g���b�N�Q�[�W(���������p)
    //�v���C���[�̃t�B�[�o�[�|�C���g�֘A
    [Header("���v���C���[�̃t�B�[�o�[�Q�[�W")]
    [SerializeField] GameObject playerOfFeverGauge;//�v���C���[�̃t�B�[�o�[�Q�[�W

    //�G��HP�֘A
    [Header("���G��HP�Q�[�W")]
    [SerializeField] GameObject enemyOfHpGauge;//�G��HP�Q�[�W

    Enemy enemy;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        //�g���b�N�Q�[�W�̐���(�Q�[�W����)
        GenerateTrickGauge();
        //�g���b�N�Q�[�W�̈ʒu����
        PositioningTrickGauge();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOfHPGauge();

        PlayerOfTRICKGauge();

        PlayerOfFeverGauge();

        EnemyOfHPGauge();
    }

    void PlayerOfHPGauge()//�v���C���[��HP�Q�[�W�̏���
    {
        float hpRatio = player.Hp / player.HpMax;
        playerOfHpGauge.GetComponent<Image>().fillAmount = hpRatio;
    }

    void GenerateTrickGauge()
    {
        trickGauges=new GameObject[player.TrickGaugeNum];
        for(int i=0; i<trickGauges.Length;i++)
        {
            trickGauges[i] = Instantiate(playerOfTrickGauge,outOfPlayerOfTrickGauge.transform);
        }
    }

    void PositioningTrickGauge()//�g���b�N�Q�[�W�̈ʒu����
    {
        //���������̃g���b�N�Q�[�W��(����)�傫�����擾
        Vector2 sd_OutOfTrickGauge = outOfPlayerOfTrickGauge.GetComponent<RectTransform>().sizeDelta;
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

    void PlayerOfTRICKGauge()//�v���C���[�̃g���b�N�Q�[�W�̏���
    {
        for(int i=0; i<trickGauges.Length;i++)
        {
            float trickRatio = player.Trick[i] / player.TrickMax;
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

    void PlayerOfFeverGauge()//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    {
        float feverRatio = player.FeverPoint / player.FeverPointMax;
        playerOfFeverGauge.GetComponent<Image>().fillAmount = feverRatio;
    }

    void EnemyOfHPGauge()//�G��HP�Q�[�W�̏���
    {
        if (enemy != null)
        {
            float enemy_HpRatio = enemy.Hp / enemy.HpMax;
            enemyOfHpGauge.GetComponent<Image>().fillAmount = enemy_HpRatio;
        }
    }
}
