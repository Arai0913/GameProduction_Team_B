using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_HP : Score
{
    [Header("�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��")]
    [SerializeField] float score_HP;//�ő�HP�ɑ΂��Ă̎c��HP��1%���Ƃ̃X�R�A��
    HP player_HP;

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
    public void ReflectScore(bool gameClear)//�c��HP�{�[�i�X�̃X�R�A�𔽉f
    {
        if(gameClear)//�N���A��
        {
            float hpRatio = player_HP.Hp / player_HP.HpMax * 100;//�ő�HP�ɑ΂��Ă̎c��HP�̊��肠��(�P�ʂ�%)
            score =score_HP*hpRatio;
        }
        else//�Q�[���I�[�o�[��
        {
            score = 0;
        }

        Score_HP = score;
    }
}
