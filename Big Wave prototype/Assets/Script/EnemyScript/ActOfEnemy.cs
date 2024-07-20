using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActOfEnemy : MonoBehaviour
{
    //������������
    [Header("���e�����������ʒu")]
    [SerializeField] GameObject shotPosObject;//�e�����������ʒu
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;

    [Header("�����������Ɏg���e")]
    [SerializeField] GameObject normalBulletPrefab;//�����󌂂��Ɏg���e
    [Header("���z�[�~���O�����Ɏg���e")]
    [SerializeField] GameObject homingBulletPrefab;//�z�[�~���O�����Ɏg���e
    [Header("���c�ɒ����a��")]
    [SerializeField] GameObject highSlashPrefab;//�����a��
    [Header("�����ɍL�����g")]
    [SerializeField] GameObject wideWavePrefab;//���ɍL�����g

    [Header("���e�𒼐��Ɍ���")]
    [SerializeField] float shotStraightPower = 9f;//�e�𒼐��Ɍ���
    [Header("���z�[�~���O���Ȃ���e������")]
    [SerializeField] float shotHomingPower = 9f;//�z�[�~���O���Ȃ���e������
    [Header("���a��������")]
    [SerializeField] float shotHighSlashPower = 9f;//�a��������
    [Header("�����ɍL�����g������")]
    [SerializeField] float shotWideWavePower = 9f;//���ɍL�����g������

    Rigidbody bulletRb;
    MoveOfEnemy moveOfEnemy;
    GameObject player;
    Vector3 shotPos;//�e�����������ʒu������

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        moveOfEnemy=gameObject.AddComponent<MoveOfEnemy>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void Move()//����
    {
        moveOfEnemy.MoveNow = true;
        moveOfEnemy.ChangeMove();//������������
    }

    public void Stop()//�~�܂�
    {
        moveOfEnemy.MoveNow = false;
    }

    public void ShotStraight()//������Ɍ���
    {
        //�e����������
        Shot(normalBulletPrefab, shotStraightPower, true);
        //���b�Z�[�W
        Debug.Log("Straight");
    }

    public void ShotHoming()//�z�[�~���O���Ȃ��猂��
    {
        //�z�[�~���O�e����������
        Shot(homingBulletPrefab, shotHomingPower, true);
        //���b�Z�[�W
        Debug.Log("Homing");
    }

    public void ShotHighSlash()//�����a��������
    {
        //�a������������
        Shot(highSlashPrefab, shotHighSlashPower, false);
        //���b�Z�[�W
        Debug.Log("HighSlash");
    }

    public void ShotWideWave()//���ɍL�����g������
    {
        //���ɍL���g����������
        Shot(wideWavePrefab, shotWideWavePower,false);
        //���b�Z�[�W
        Debug.Log("WideWave");
    }

    void Shot(GameObject bulletPrefab,float shotPower,bool homing)//�U�������������Ahoming�̓z�[�~���O���Č���(true�Ȃ�z�[�~���O���Č���)
    {
        //�U�������������ʒu���擾
        shotPos = shotPosObject.transform.position;
        //�U������������
        GameObject Bullet = Instantiate(bulletPrefab, shotPos, transform.rotation,gamePos.transform);

        bulletRb = Bullet.GetComponent<Rigidbody>();
        if(homing)//�z�[�~���O���Č���
        {
            //���ꏊ����v���C���[�����̃x�N�g�����Z�o&�傫����1��
            Vector3 toPlayer = (player.transform.position - shotPos).normalized;

            //�U���̌������v���C���[�̂�������ɕύX
            Bullet.transform.rotation = Quaternion.LookRotation(toPlayer,Vector3.up);

            bulletRb.AddForce(toPlayer * shotHomingPower, ForceMode.Impulse);
        }
        else//�����Ɍ���
        {
            bulletRb.AddForce(-transform.forward * shotPower, ForceMode.Impulse);
        }
    }
}
