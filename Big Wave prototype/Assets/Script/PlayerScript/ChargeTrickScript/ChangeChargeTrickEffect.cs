using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickEffect : MonoBehaviour
{
    [Header("�`���[�W���̃G�t�F�N�g")]
    [SerializeField] GameObject chargeEffect;//�`���[�W���̃G�t�F�N�g
    [Header("�ő�{�����̃`���[�W���̃G�t�F�N�g�̑傫��")]
    [SerializeField] float maxScale;//�`���[�W���̃G�t�F�N�g
    private Vector3 normalScale;
    private Vector3 currentScale;

    JudgeChargeNow judgeChargeNow;
    ChangeChargeTrick changeChargeTrick;
    // Start is called before the first frame update
    void Start()
    {
        judgeChargeNow = GetComponent<JudgeChargeNow>();
        changeChargeTrick =GetComponent<ChangeChargeTrick>();
        normalScale = chargeEffect.transform.localScale;
        currentScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeEffectScale()//�G�t�F�N�g�̑傫����ύX
    {
        //�G�t�F�N�g�̑傫����ύX
        float effectScale = normalScale.x + (maxScale - normalScale.x) *changeChargeTrick.RatioOfChargeRate();
        currentScale = new Vector3(effectScale, effectScale, effectScale);

        ApplyCurrentScale();
    }

    void ApplyCurrentScale()//���݂̑傫����K�p
    {
        if(judgeChargeNow.ChargeNow())
        {
            chargeEffect.transform.localScale = currentScale;
        }
    }
}
