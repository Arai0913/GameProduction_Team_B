using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCount : Score
{
    [Header("�g���b�N��񂲂Ƃ̃X�R�A��")]
    [SerializeField] float scorePerOneTrick;//�g���b�N��񂲂Ƃ̃X�R�A��
    private static float score_TrickCount = 0;//�g���b�N�񐔂̃X�R�A

    public static float _Score_TrickCount
    {
        get { return score_TrickCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore()//�X�R�A���Z(1��g���b�N�����邲�ƂɌĂ�)
    {
        score += scorePerOneTrick;
    }

    public void ReflectScore()//�g���b�N�񐔂̃X�R�A�𔽉f
    {
        score_TrickCount=score;
    }
}
