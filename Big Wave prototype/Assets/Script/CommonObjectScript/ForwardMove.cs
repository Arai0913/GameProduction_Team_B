using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMove : MonoBehaviour
{
    //������������
    MoveManager movemanager;
    // Start is called before the first frame update
    void Start()
    {
        movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//�O���ړ�
    }

    //�O���ړ�
    //MoveManager��forwardspeed�̑����őO�ɐi��
    void Move()
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * movemanager.ForwardSpeed);
    }
}
