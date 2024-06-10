using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfEnemy : MonoBehaviour
{
    //������������
    [Header("���G�̓����ŏ��X�s�[�h")]
    [SerializeField] float speedMin = 15f;//�G�̓����ŏ��X�s�[�h
    [Header("���G�̓����ő�X�s�[�h")]
    [SerializeField] float speedMax = 20f;//�G�̓����ő�X�s�[�h
    [Header("������Ă�������Ɣ��Α������Ɉړ�����m��(%)")]
    [SerializeField] float directionProbability = 60f;
    private bool moveNow=false;//�������Ă��邩
    private bool isLeft = false;
    private float speed;//�G�̓����X�s�[�h
    private Vector3 move;
    //MoveManager movemanager;

    public bool MoveNow
    {
        set { moveNow = value; }
        get { return moveNow; }
    }
    // Start is called before the first frame update
    void Start()
    {
        //MoveManager����limitrange���擾���AForwardMove��limitrange�ɑ��
        //movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnTheLeft();//�������ɂ��邩�m�F
        Move();// �G�̓���
    }

    public void ChangeMove()//�������Ƃ����Ƃ��ɕK�������������_���ɕύX����
    {
        //����������ύX
        float change;
        change= Random.Range(0, 100);
        if(isLeft)//�����ɂ��鎞
        {
            //�����ɂ��鎞�E�����Ɉړ����₷������
            if(change<=directionProbability)
            {
                move = Vector3.right;
            }
            else
            {
                move = Vector3.left;
            }
        }
        else//�E���ɂ��鎞
        {
            //�E���ɂ��鎞�������Ɉړ����₷������
            if (change <= directionProbability)
            {
                move = Vector3.left;
            }
            else
            {
                move = Vector3.right;
            }
        }

        //�X�s�[�h��ύX
        speed = Random.Range(speedMin, speedMax);
    }

    void CheckOnTheLeft()//�������ɂ��邩�m�F
    {
        Vector3 currentPos;//���݈ʒu

        currentPos=gameObject.transform.position;

        if(currentPos.x<=0)//�����ɂ���
        {
            isLeft = true;
        }
        else//�E���ɂ���
        {
            isLeft= false;
        }
    }

    //�G�̓���
    void Move()
    {
       if(moveNow)
        {
           transform.Translate(move * speed * Time.deltaTime);
        }
    }
}
