using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//HP�̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Hp")]
public class Score_HP_ : Score_Base
{
    float m_remainingHp;//�c��HP
    float m_scorePerHp;//HP1������̃X�R�A��

    public float RemainingHP { get { return m_remainingHp; }  }
    public float ScorePerHp { get {  return m_scorePerHp; } }

    public void Rewrite(float score,float remainingHp,float scorePerHp)//�X�R�A�̏�������
    {
        m_score=score;
        m_remainingHp=remainingHp;
        m_scorePerHp=scorePerHp;
    }
}
