using UnityEngine;

//�쐬��:���R
//���ړ�
public class MoveLeftAndRight : MonoBehaviour
{
    [SerializeField] float speed = 11.5f;//�ړ��X�s�[�h

    void Update()
    {
        Move();
    }

    void Move()//�v���C���[�̓���
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(move * Time.deltaTime * speed);//�g���b�N�����܂��Ă���قǈړ��X�s�[�h���͂₭�Ȃ�
    }
}
