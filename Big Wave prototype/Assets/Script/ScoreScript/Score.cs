using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
    protected float score=0;//�X�R�A�A�V�[���J�ڂ��钼�O�Ɉȉ���static�ϐ��̂ǂꂩ��score�̒l����

    public float Score_
    {
        get { return score; }
    }

    public virtual void ReflectScore() { }//�X�R�A���f
    public virtual void ReflectScore(bool gameSet) { }//�N���A���̂݃X�R�A���f
}
