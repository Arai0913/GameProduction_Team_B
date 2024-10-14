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

    void Move()//�v���C���[�̓���
    {
        transform.Translate(move * Time.deltaTime * speed);//�g���b�N�����܂��Ă���قǈړ��X�s�[�h���͂₭�Ȃ�
    }

    public void GetMoveVector(InputAction.CallbackContext context)//�����������󂯎��
    {
        //x�����̓��͂����󂯎��
        Vector2 getVec= context.ReadValue<Vector2>();
        move = new Vector3(getVec.x,0f,0f);
    }
}
