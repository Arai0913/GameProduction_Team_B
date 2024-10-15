using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//���ړ�
public class MoveLeftAndRight : MonoBehaviour
{
    [SerializeField] float speed = 11.5f;//�ړ��X�s�[�h
    Vector3 move;

    void Update()
    {
        Move();
    }

    void Move()//�v���C���[�̈ړ�
    {
        transform.Translate(move * Time.deltaTime * speed);//�v���C���[�̈ړ�
    }

    public void GetMoveVector(Vector2 getVec)//�����������󂯎��
    {
        //x�����̓��͂����󂯎��
        move = new Vector3(getVec.x,0f,0f);
    }
}
