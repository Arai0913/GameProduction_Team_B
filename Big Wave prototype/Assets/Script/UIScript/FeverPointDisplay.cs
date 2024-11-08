using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeverPointDisplay : MonoBehaviour
{
    [Header("���v���C���[�̃t�B�[�o�[�Q�[�W")]
    [SerializeField] Image feverGaugeOfPlayer;//�v���C���[�̃t�B�[�o�[�Q�[�W
    [Header("���ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeNormalColor;//�ʏ��Ԃ̃t�B�[�o�[�Q�[�W�̐F
    [Header("���t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F")]
    [SerializeField] Color feverGaugeFeverModeColor;//�t�B�[�o�[��Ԃ̃t�B�[�o�[�Q�[�W�̐F

    FeverPoint player_FeverPoint;
    FeverMode processFeverPoint;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GameObject.FindWithTag("Player").GetComponent<FeverPoint>();
        processFeverPoint = GameObject.FindWithTag("Player").GetComponent<FeverMode>();
    }

    // Update is called once per frame
    void Update()
    {
        FeverGaugeOfPlayer();//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    }

    void FeverGaugeOfPlayer()//�v���C���[�̃t�B�[�o�[�Q�[�W�̏���
    {
        float feverRatio = player_FeverPoint.FeverPoint_ / player_FeverPoint.FeverPointMax;
        feverGaugeOfPlayer.fillAmount = feverRatio;
        //�Q�[�W�̐F�̕ύX
        feverGaugeOfPlayer.color = processFeverPoint.FeverNow ? feverGaugeFeverModeColor : feverGaugeNormalColor;

        //if (processFeverPoint.FeverNow)//�t�B�[�o�[��Ԃ̎�
        //{
        //    feverGaugeOfPlayer.color = feverGaugeFeverModeColor;
        //}
        //else//�ʏ펞
        //{
        //    feverGaugeOfPlayer.color = feverGaugeNormalColor;
        //}
    }
}
