using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCountDisplay : MonoBehaviour
{
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text comboCount_UI;//�\��������e�L�X�g
    CountTrickCombo countTrickCombo;
    // Start is called before the first frame update
    void Start()
    {
        countTrickCombo=GameObject.FindWithTag("Player").GetComponent<CountTrickCombo>();
    }

    // Update is called once per frame
    void Update()
    {
        comboCount_UI.text=countTrickCombo.ComboCount.ToString("0");
    }
}
