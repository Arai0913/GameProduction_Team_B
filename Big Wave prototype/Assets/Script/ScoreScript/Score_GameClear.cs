using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_GameClear : Score
{
    [Header("�Q�[���N���A���̃X�R�A��")]
    [SerializeField] float score_GameClearBonus;//�Q�[���N���A���̃X�R�A��
    private static float score_GameClear = 0;//�Q�[���N���A�{�[�i�X�̃X�R�A

    public static float _Score_GameClear
    {
        get { return score_GameClear; }
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

    public void ReflectScore(bool gameClear)//�N���A���ɃQ�[���N���A�{�[�i�X�̃X�R�A�𔽉f
    {
        if(gameClear)//�N���A��
        {
            score += score_GameClearBonus;
        }
        else//�Q�[���I�[�o�[��
        {
            score = 0;
        }

        score_GameClear = score;
    }
}
