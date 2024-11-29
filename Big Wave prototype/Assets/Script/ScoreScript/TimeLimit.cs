using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��������
public class TimeLimit : MonoBehaviour
{
    [Header("���������ԁi�b�j")]
    [SerializeField] float timeLimit = 120;//��������(�b)
    private float remainingTime;//�c�莞��
    private bool startGame=false;
    public float RemainingTime
    {
        get { return remainingTime; }
    }

    void Start()
    {
        remainingTime = timeLimit;
    }

    void Update()
    {
        if (startGame)
        {
            remainingTime -= Time.deltaTime;
        }
    }
    public void EnableStart()
    {
        startGame = true;
    }
}
