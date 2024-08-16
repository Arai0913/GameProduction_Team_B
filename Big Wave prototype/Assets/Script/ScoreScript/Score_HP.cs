using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_HP : Score
{
    [Header("�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��")]
    [SerializeField] float scorePerOnePercent;//�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��
    private static float score_HP = 0;//�c��HP�̃X�R�A
    HP player_HP;

    public static float ScoreHP
    {
        get { return score_HP; }
    }

    // Start is called before the first frame update
    void Start()
    {
        player_HP = GameObject.FindWithTag("Player").GetComponent<HP>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override  void ReflectScore(bool gameClear)//�c��HP�{�[�i�X�̃X�R�A�𔽉f
    {
        if(gameClear)//�N���A��
        {
            float hpRatio = player_HP.Hp / player_HP.HpMax * 100;//�ő�HP�ɑ΂��Ă̎c��HP�̊��肠��(�P�ʂ�%)
            score =scorePerOnePercent*hpRatio;
        }
        else//�Q�[���I�[�o�[��
        {
            score = 0;
        }

        score_HP = score;
    }
}
