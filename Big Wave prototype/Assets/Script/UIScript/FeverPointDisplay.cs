using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeverPointDisplay : MonoBehaviour
{
    [Header("���v���C���[�̃t�B�[�o�[�Q�[�W")]
    [SerializeField] GameObject feverGaugeOfPlayer;//�v���C���[�̃t�B�[�o�[�Q�[�W
    [Header("���ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeNormalColor;//�ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F
    [Header("���t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeFeverModeColor;//�t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F

    FEVERPoint player_FeverPoint;
    ProcessFeverMode processFeverPoint;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GameObject.FindWithTag("Player").GetComponent<FEVERPoint>();
        processFeverPoint = GameObject.FindWithTag("Player").GetComponent<ProcessFeverMode>();
    }

    // Update is called once per frame
    void Update()
    {
        FeverGaugeOfPlayer();//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    }

    void FeverGaugeOfPlayer()//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    {
        float feverRatio = player_FeverPoint.FeverPoint / player_FeverPoint.FeverPointMax;
        feverGaugeOfPlayer.GetComponent<Image>().fillAmount = feverRatio;
        //�Q�[�W�̐F�̕ύX
        if (processFeverPoint.FeverNow)//�t�B�[�o�[��Ԃ̎�
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeFeverModeColor;
        }
        else//�ʏ펞
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeNormalColor;
        }
    }
}
