using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TimeLimit : Score
{
    [Header("�c�莞��(1�b)���Ƃ̃X�R�A��")]
    [SerializeField] float scorePerSecond;//�c�莞��(1�b)���Ƃ̃X�R�A��
    private static float score_TimeLimit = 0;//�c�莞�Ԃ̃X�R�A

    public static float ScoreTimeLimit
    {
        get { return score_TimeLimit; }
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
    public override void ReflectScore(bool gameClear)//�������ԃ{�[�i�X�̃X�R�A�𔽉f
    {
        if (gameClear)//�N���A��
        {
            score = scorePerSecond * TimeLimit.RemainingTime;
        }
        else//�Q�[���I�[�o�[��
        {
            score = 0;
        }

        score_TimeLimit = score;
    }
}
