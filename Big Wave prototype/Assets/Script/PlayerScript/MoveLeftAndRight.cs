using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    //���쐬��:���R
    [SerializeField] float speed = 11.5f;//�ړ��X�s�[�h
    //[SerializeField] float trick_SpeedFactor=1f;//�g���b�N�����߂����̃X�s�[�h�̏㏸��A1�A�Q�A3�An���Ƃ��ꂼ��g���b�N���^�����A�g���b�N����ۂ̎��̃X�s�[�h��2�A3�A4�A(1+1*n)�{�ɂȂ�


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()//�v���C���[�̓���
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //float trickPercentage = player.Trick / player.TrickMax;//�v���C���[�̃g���b�N��(�ő�l�ɑ΂��Ă̌��݂̃g���b�N�̒l)����
        transform.Translate(move * Time.deltaTime * speed);//�g���b�N�����܂��Ă���قǈړ��X�s�[�h���͂₭�Ȃ�
    }
}
