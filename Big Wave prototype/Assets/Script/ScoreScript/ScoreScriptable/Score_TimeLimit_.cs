using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���Ԑ����̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/TimeLimit")]
public class Score_TimeLimit_ : Score_Base
{
    float m_remainingTime;//�c�莞��
    float m_scorePerSecond;//1�b���Ƃ̃X�R�A

    public float RemainingTime { get { return m_remainingTime; } }
    public float ScorePerScond { get {  return m_scorePerSecond; } }

    public void Rewrite(float score,float remainingTime,float scorePerSecond)//�X�R�A�̏�������
    {
        m_score=score;
        m_remainingTime=remainingTime;
        m_scorePerSecond=scorePerSecond;
    }
}
