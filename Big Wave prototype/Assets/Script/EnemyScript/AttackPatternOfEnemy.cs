using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AttackPattern//�U�������p�^�[��
{
    shotStraight,//������Ɍ���
    shotHoming,//�z�[�~���O���Ȃ��猂��
    shotHighSlash,//�����a��������
    shotWideWave//���ɍL�����g������
}

[System.Serializable]
class FormAttackPattern//�`��
{
    public AttackPattern[] attackPatterns;//�U���p�^�[��
    public float[] attackProbability;//�U���m��
    [HideInInspector] public float attackProbabilitySum=0;//�U���m��(attackProbability)�̍��v�A�U���������_���Ɍ��߂鎞�Ɏg��
}

public class AttackPatternOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject shotPosObject;//�e�����������ʒu
    [SerializeField] GameObject normalBulletPrefab;//������ƃz�[�~���O�����Ɏg���e
    [SerializeField] GameObject highSlashPrefab;//�����a��
    [SerializeField] GameObject WideWavePrefab;//���ɍL�����g
    [SerializeField] float shotStraightPower = 9f;//�e�𒼐��Ɍ���
    [SerializeField] float shotHomingPower = 9f;//�z�[�~���O���Ȃ���e������
    [SerializeField] float shotHighSlashPower = 9f;//�a��������
    [SerializeField] float shotWideWavePower = 9f;//���ɍL�����g������
    [SerializeField] Quaternion []attackRotation=new Quaternion [4];//���ɍL�����g�̊p�x
    [SerializeField] FormAttackPattern[] form;//�`�Ԃ��Ƃ̍U���p�^�[���ƍU���m���̔z��
    Rigidbody bulletRb;
    GameObject player;
    Vector3 shotPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        for(int i=0; i<form.Length;i++)//���ꂼ��̌`�Ԃ�attackProbabilitySum�ɒl������(������)
        {
            for(int j=0;j<form[i].attackProbability.Length ;j++)
            {
                form[i].attackProbabilitySum += form[i].attackProbability[j];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(int a)//�U�������Aa�͉��`�Ԗڂ�
    {
        //�U���������_���Ō���(�m���Ŏ����\��)
        float attackPatternNumber = Random.Range(0, form[a-1].attackProbabilitySum);
        int attack = 0;//�G�̍U���p�^�[���A�ǂ̍U���p�^�[�������邩���肷��Ƃ��Ɏg�p
        float attackSum = 0;

        //�ǂ̍U�������邩���肷�邽�߂̏���
        //
        //
        for (int i=0; i<form[a-1].attackPatterns.Length;i++)
        {
            //���̍U���p�^�[���̊m���𑫂�
            attackSum += form[a - 1].attackProbability[i];

            //�����_���ŏo�����l��attackSum�����ł���΍U������
            if(attackPatternNumber<attackSum)
            {
                break;
            }

            //���܂�Ȃ���Ύ��̍U���̔����
            attack++;
        }

        //�U�������������ʒu���擾
        shotPos = shotPosObject.transform.position;

        //�U��
        switch (form[a - 1].attackPatterns[attack])
        {
            case AttackPattern.shotStraight: ShotStraight(); break;//������Ɍ���
            case AttackPattern.shotHoming: ShotHoming(); break;//�z�[�~���O���Ȃ��猂��
            case AttackPattern.shotHighSlash: ShotHighSlash(); break;//�����a��������
            case AttackPattern.shotWideWave: ShotWideWave(); break;//���ɍL�����g������
        }
       
    }
    void ShotStraight()//������Ɍ���
    {
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, attackRotation[0]);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotStraightPower, ForceMode.Impulse);
        Debug.Log("Straight");
    }

    void ShotHoming()//�z�[�~���O���Ȃ��猂��
    {
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, attackRotation[1]);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(toPlayer * shotHomingPower, ForceMode.Impulse);
        Debug.Log("Homing");
    }

    void ShotHighSlash()//�����a��������
    {
        GameObject highSlashBullet = Instantiate(highSlashPrefab, shotPos, attackRotation[2]);
        bulletRb = highSlashBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotHighSlashPower, ForceMode.Impulse);
        Debug.Log("HighSlash");
    }

    void ShotWideWave()//���ɍL�����g������
    {
        GameObject wideWaveBullet = Instantiate(WideWavePrefab, shotPos, attackRotation[3]);
        bulletRb = wideWaveBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotWideWavePower, ForceMode.Impulse);
        Debug.Log("WideWave");
    }
}
