using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�̃X�R�A
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Trick")]
public class Score_Trick_ : Score_Base
{
    public void Rewrite(float score)//�X�R�A�̏�������
    {
        m_score = score;
    }
}
