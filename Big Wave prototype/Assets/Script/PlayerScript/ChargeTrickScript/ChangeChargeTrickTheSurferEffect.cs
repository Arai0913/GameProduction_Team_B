using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickTheSurferEffect : MonoBehaviour
{
    [Header("�`���[�W���̃G�t�F�N�g")]
    [SerializeField] GameObject chargeEffect;//�`���[�W���̃G�t�F�N�g
    [Header("�ő�{�����̃`���[�W���̃G�t�F�N�g�̑傫��(�{��)")]
    [SerializeField] float maxScaleRate;//�ő�{�����̃`���[�W���̃G�t�F�N�g�̑傫���A�����̑傫�����牽�{�̑傫����
    private Vector3 maxScale;//�ő�{�����̃G�t�F�N�g�̑傫��
    private Vector3 normalScale;//�ʏ펞(����)�̃G�t�F�N�g�̑傫��
    private Vector3 currentScale;//���݂̃G�t�F�N�g�̑傫��

    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    // Start is called before the first frame update
    void Start()
    {
        changeChargeTrickTheSurfer =GetComponent<ChangeChargeTrickTheSurfer>();
        normalScale = chargeEffect.transform.localScale;
        maxScale = normalScale * maxScaleRate;
        currentScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeEffectScale();//�G�t�F�N�g�̑傫����ύX
    }

    void ChangeEffectScale()//�G�t�F�N�g�̑傫����ύX
    {
        if (chargeEffect.activeSelf)//�`���[�W�G�t�F�N�g���A�N�e�B�u�̎��ɃG�t�F�N�g�̑傫����ύX
        {
            float current = changeChargeTrickTheSurfer.CurrentChargeRate - changeChargeTrickTheSurfer.NormalChargeRate;//���݂̔{������ʏ�̔{��(1)������������
            float max = changeChargeTrickTheSurfer.ChargeRateMax - changeChargeTrickTheSurfer.NormalChargeRate;//�ő�{������ʏ�̔{��(1)������������
            float ratio= current / max;

            //�G�t�F�N�g�̌��݂̑傫���̒l��ύX
            currentScale = normalScale + (maxScale - normalScale) * ratio;

            //���݂̑傫�����G�t�F�N�g�̑傫���ɓK�p
            chargeEffect.transform.localScale = currentScale;
        }
    }
}
