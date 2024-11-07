using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SlantHP : MonoBehaviour
{
    [Header("��HP�Q�[�W")]
    [SerializeField] GameObject hpGaugeOfEnemy;//HP�Q�[�W
    [Header("��HP��\���������I�u�W�F�N�g")]
    [SerializeField] HP objectDisplayHp;//HP��\���������I�u�W�F�N�g
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        HpGauge();
    }

    void HpGauge() // HP�Q�[�W�̏���
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        float xPosition = Mathf.Lerp(0, -368, 1 - hpRatio);

        RectTransform rectTransform = hpGaugeOfEnemy.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(xPosition, rectTransform.anchoredPosition.y);
    }


}
