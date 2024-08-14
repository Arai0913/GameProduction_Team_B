using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [Header("�\��������e�L�X�g")]
    [SerializeField] TMP_Text Score_UI;//�\��������e�L�X�g
    [Header("�\���������X�R�A")]
    [SerializeField] Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_UI.text = score.Score_.ToString("0");
    }
}
