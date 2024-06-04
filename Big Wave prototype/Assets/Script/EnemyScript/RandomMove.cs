using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    //������������
    [SerializeField] float speedMin = 15f;//�G�̓����ŏ��X�s�[�h
    [SerializeField] float speedMax = 20f;//�G�̓����ő�X�s�[�h
    [SerializeField] float minChangeMoveTime = 0.1f;//�G�̓������ς��ŏ�����
    [SerializeField] float maxChangeMoveTime = 0.4f;//�G�̓������ς��ő㎞��
    private float speed;//�G�̓����X�s�[�h
    private float moveChangeTime = 0f;//�G�̓������ς�鎞��
    private float moveTime = 0f;//�G�̍s�����Ǘ����鎞��
    private int moveleft = 1;// 1�����A0�������~�܂�A-1���E
    MoveManager movemanager;
    // Start is called before the first frame update
    void Start()
    {
        //MoveManager����limitrange���擾���AForwardMove��limitrange�ɑ��
        movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();// �G�̓���
    }

    //�G�̓���
    //!!!!!�v����
    //
    void Move()
    {
        moveTime += Time.deltaTime;

        Vector3 currentpos = transform.position;

        if (moveTime > moveChangeTime || currentpos.x == movemanager.limitRange || currentpos.x == -movemanager.limitRange)
        {
            moveTime = 0;
            moveChangeTime = Random.Range(minChangeMoveTime, maxChangeMoveTime);
            moveleft = Random.Range(-1, 2);
            speed = Random.Range(speedMin, speedMax);
            //if(moveleft==0)
            //{
            //    moveleft = -1;
            //}
        }

        Vector3 move = Vector3.left;
        transform.Translate(move * speed * Time.deltaTime * moveleft);
    }
}
