using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCombo : Score
{
    private static float score_TrickCombo = 0;//�g���b�N�̃R���{�̃X�R�A

    public static float _Score_TrickCombo
    {
        get { return score_TrickCombo; }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReflectScore()//�g���b�N�R���{�{�[�i�X�̃X�R�A�𔽉f
    {
        score_TrickCombo = score;
    }
}
