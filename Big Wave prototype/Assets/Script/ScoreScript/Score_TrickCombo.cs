using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCombo : Score
{
    [Header("�R���{��񂲂Ƃ̃X�R�A")]
    [SerializeField] float scorePerOneCombo;//�R���{��񂲂Ƃ̃X�R�A
    private static float score_TrickCombo = 0;//�g���b�N�̃R���{�̃X�R�A

    public static float ScoreTrickCombo
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

    public void AddScore(int comboCount)//�R���{�񐔕��X�R�A�����Z
    {
        score += scorePerOneCombo * comboCount;
    }

    public override void ReflectScore()//(�Q�[���I������)�g���b�N�R���{�{�[�i�X�̃X�R�A�𔽉f
    {
        score_TrickCombo = score;
    }
}
