using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternOfEnemy : MonoBehaviour
{
    enum AttackPattern//�U�������p�^�[��
    {
        shotStraight,//������Ɍ���
        shotHoming,//�z�[�~���O���Ȃ��猂��
        shotHighSlash,//�����a��������
        shotWideWave//���ɍL�����g������
    }

    [SerializeField] GameObject shotPosObject;//�e�����������ʒu
    [SerializeField] GameObject normalBulletPrefab;//������ƃz�[�~���O�����Ɏg���e
    [SerializeField] GameObject highSlashPrefab;//�����a��
    [SerializeField] GameObject WideWavePrefab;//���ɍL�����g
    [SerializeField] float shotStraightPower = 9f;//�e�𒼐��Ɍ���
    [SerializeField] float shotHomingPower = 9f;//�z�[�~���O���Ȃ���e������
    [SerializeField] float shotHighSlashPower = 9f;//�a��������
    [SerializeField] float shotWideWavePower = 9f;//���ɍL�����g������
    [SerializeField] AttackPattern[] attackPatterns;//�G�̍s���p�^�[��
    private int attackPatternNumber;//����œG�̍s���p�^�[�������߂�
    Rigidbody bulletRb;
    GameObject player;
    Vector3 shotPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()//�U��������
    {
        attackPatternNumber = Random.Range(0,attackPatterns.Length);

        shotPos = shotPosObject.transform.position;

        if (attackPatterns[attackPatternNumber] == AttackPattern.shotStraight)//������Ɍ���
        {
            ShotStraight();
        }

        else if (attackPatterns[attackPatternNumber] == AttackPattern.shotHoming)//�z�[�~���O���Ȃ��猂��
        {
            ShotHoming();
        }

        else if (attackPatterns[attackPatternNumber] == AttackPattern.shotHighSlash)//�����a��������
        {
            ShotHighSlash();
        }

        else if (attackPatterns[attackPatternNumber] == AttackPattern.shotWideWave)//���ɍL�����g������
        {
            ShotWideWave();
        }
    }
    void ShotStraight()//������Ɍ���
    {
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, transform.rotation);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotStraightPower, ForceMode.Impulse);
        Debug.Log("Straight");
    }

    void ShotHoming()//�z�[�~���O���Ȃ��猂��
    {
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, transform.rotation);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(toPlayer * shotHomingPower, ForceMode.Impulse);
        Debug.Log("Homing");
    }

    void ShotHighSlash()//�����a��������
    {
        GameObject highSlashBullet = Instantiate(highSlashPrefab, shotPos, transform.rotation);
        bulletRb = highSlashBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotHighSlashPower, ForceMode.Impulse);
        Debug.Log("HighSlash");
    }

    void ShotWideWave()//���ɍL�����g������
    {
        GameObject wideWaveBullet = Instantiate(WideWavePrefab, shotPos, transform.rotation);
        bulletRb = wideWaveBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotWideWavePower, ForceMode.Impulse);
        Debug.Log("WideWave");
    }
}
