using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_GameClear : Score
{
    [Header("�Q�[���N���A���̃X�R�A��")]
    [SerializeField] float score_GameClear;//�Q�[���N���A���̃X�R�A��
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReflectScore(bool gameClear)//�N���A���ɃQ�[���N���A�{�[�i�X�̃X�R�A�𔽉f
    {
        if(gameClear)//�N���A��
        {
            score += score_GameClear;
        }
        else//�Q�[���I�[�o�[��
        {
            score = 0;
        }

        Score_GameClear = score;
    }
}
