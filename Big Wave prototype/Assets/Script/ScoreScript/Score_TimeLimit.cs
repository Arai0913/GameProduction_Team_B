using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TimeLimit : Score
{
    [Header("�c�莞��(1�b)���Ƃ̃X�R�A��")]
    [SerializeField] float score_TimeLimit;//�c�莞��(1�b)���Ƃ̃X�R�A��
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReflectScore(bool gameClear)//�������ԃ{�[�i�X�̃X�R�A�𔽉f
    {
        if (gameClear)//�N���A��
        {
            score = score_TimeLimit * TimeLimit.RemainingTime;
        }
        else//�Q�[���I�[�o�[��
        {
            score = 0;
        }

        Score_TimeLimit = score;
    }
}
