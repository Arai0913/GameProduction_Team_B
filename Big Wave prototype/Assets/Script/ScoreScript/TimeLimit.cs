using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R

public class TimeLimit : MonoBehaviour
{
    [Header("���������ԁi�b�j")]
    [SerializeField] float timeLimit = 120;//��������(�b)
    private static float remainingTime;//�c�莞��

    public static float RemainingTime
    {
        get { return remainingTime; }
    }

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
    }
}