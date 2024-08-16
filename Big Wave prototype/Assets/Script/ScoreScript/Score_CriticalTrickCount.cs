using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_CriticalTrickCount : Score
{
    [Header("1��̃N���e�B�J�����Ƃ̃X�R�A��")]
    [SerializeField] float scorePerOneCritical;//1��̃N���e�B�J�����Ƃ̃X�R�A��
    [Header("�N���e�B�J���A���{�[�i�X�̑�����")]
    [Tooltip("1��ڂ͘A���{�[�i�X�Ȃ��ł����A�A�����ڂ̃N���e�B�J�������1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ����̒l�������Ă����܂�")]
    [SerializeField] float plusContinueBonus;//�N���e�B�J���A���{�[�i�X�̑������A1��ڂ͘A���{�[�i�X�Ȃ��ł����A�A�����ڂ̃N���e�B�J�������1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ����̒l�������Ă����܂�
    [Header("1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ̍ő�l")]
    [Tooltip("�A���{�[�i�X��1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ������Ă����܂������̒l�ȏ�͑����܂���")]
    [SerializeField] float scorePerOneCriticalMax;//1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ̍ő�l�A�A���{�[�i�X��1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ������Ă����܂������̒l�ȏ�͑����܂���
    private static float score_CriticalTrickCount = 0;//�N���e�B�J���񐔂ƃN���e�B�J���A���{�[�i�X�̃X�R�A
    private float currentScorePerOneCritical;//���݂�1��̃N���e�B�J�����Ƃ̃X�R�A��

    public static float ScoreCriticalTrickCount
    {
        get { return score_CriticalTrickCount; }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentScorePerOneCritical = scorePerOneCritical;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScoreWhenCritical(bool critical)//�N���e�B�J�����ɃX�R�A�̉��Z������A�����ɂ̓N���e�B�J���������ꍇ��true�A��������Ȃ�������(���ʂ̍U����������)false������
    {
        //�N���e�B�J����A���ł���ق�(�N���e�B�J����x�ڂ���)�X�R�A�㏸�ʂ������Ă���

        if(critical)//�N���e�B�J��������
        {
            score += currentScorePerOneCritical;//�X�R�A���Z
            currentScorePerOneCritical += plusContinueBonus;//���݂�1��̃N���e�B�J�����Ƃ̃X�R�A�ʂ��オ��
            currentScorePerOneCritical = Mathf.Clamp(currentScorePerOneCritical, 0, scorePerOneCriticalMax);//�X�R�A�㏸�ʂ̐����A�X�R�A�㏸�ʂ�scorePerOneCriticalMax���傫���Ȃ�Ȃ��悤�ɂ���
        }
        else//�N���e�B�J���ł͂Ȃ�����
        {
            currentScorePerOneCritical = scorePerOneCritical;//�X�R�A�̏㏸�ʂ����Ƃɖ߂�
        }
    }

    public override void ReflectScore()//�g���b�N�{�^���w�萬���{�[�i�X�̃X�R�A�𔽉f
    {
        score_CriticalTrickCount = score;
    }
}
