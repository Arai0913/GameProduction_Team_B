using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_CriticalTrickCount : Score
{
    private static float score_CriticalTrickCount = 0;//�N���e�B�J���񐔂ƃN���e�B�J���A���{�[�i�X�̃X�R�A

    public static float _Score_CriticalTrickCount
    {
        get { return score_CriticalTrickCount; }
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

    public void ReflectScore()//�g���b�N�{�^���w�萬���{�[�i�X�̃X�R�A�𔽉f
    {
        score_CriticalTrickCount = score;
    }
}
