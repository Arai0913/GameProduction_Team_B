using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�R�A�̍��v���v�Z
public class CalcTotalScore : MonoBehaviour
{
    [Header("���Z����X�R�A")]
    [SerializeField] Score_Base[] _addScores;//���Z����X�R�A
    [Header("���v�X�R�A")]
    [SerializeField] Score_Total_ _score_Total_;//���v�X�R�A

    void Awake()
    {
        //���v���v�Z
        float score=0;

        for(int i=0; i<_addScores.Length;i++)
        {
            score += _addScores[i].Score;
        }

        //���v�X�R�A�ɔ��f
        _score_Total_.ReWrite(score);
        
    }
}
