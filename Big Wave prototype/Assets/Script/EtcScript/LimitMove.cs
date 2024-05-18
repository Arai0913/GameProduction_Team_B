using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMove : MonoBehaviour
{
    MoveManager movemanager;

    // Start is called before the first frame update
    void Start()
    {
        movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLimit();//�L�����̓����̐���
    }


    //�L�����̓����̐���
    //Movemanager��limitrange�̒l�œ�����͈͂����܂�
    void MoveLimit() 
    {
        Vector3 currentPlayerPos = transform.position;
        currentPlayerPos.x = Mathf.Clamp(currentPlayerPos.x, -movemanager.limitRange, movemanager.limitRange);
        transform.position = currentPlayerPos;
    }

}
