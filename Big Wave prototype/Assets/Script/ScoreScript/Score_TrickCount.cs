using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCount : MonoBehaviour
{
    [Header("�g���b�N��񂲂Ƃ̃X�R�A��")]
    [SerializeField] float scorePerOneTrick;//�g���b�N��񂲂Ƃ̃X�R�A��
    private static float score;//�g���b�N�񐔂̃X�R�A
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore()//�X�R�A���Z(1��g���b�N�����邲�ƂɌĂ�)
    {
        score += scorePerOneTrick;
    }
}
