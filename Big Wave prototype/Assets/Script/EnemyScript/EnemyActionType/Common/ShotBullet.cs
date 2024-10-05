using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet:MonoBehaviour
{
    [Header("���e")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("������")]
    [SerializeField] float shotPower;//����
    [Header("���e�����������ʒu�Ɗp�x")]
    [SerializeField] Transform shotPos;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    private bool shoted;//�e����������
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����

    public Transform ShotPos
    {
        get { return shotPos; }
    }

    public void InitShotTiming()//���^�C�~���O�̏�����
    {
        currentDelayTime = 0;
        shoted = false;
    }

    public bool UpdateShotTiming()//���^�C�~���O�̍X�V�A���^�C�~���O�ɂȂ�����true��Ԃ�
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime >= delayTime && !shoted) return true;//�w��̒x�����ԂɒB�������܂��e�������Ă��Ȃ��� 

        return false;
    }

    public void Shot(Vector3 shotVec)
    {
        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPosVec = shotPos.transform.position;//�ʒu
        Quaternion shotRotVec = this.shotPos.transform.rotation;//�p�x
        //�U����z�u����
        GameObject bullet = Instantiate(bulletPrefab, shotPosVec, shotRotVec, gamePos.transform);
        //�e��Rigidbody���擾
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        //�e�𔭎˕����Ɍ�������

        //�e����������
        bulletRb.AddForce(shotVec * shotPower, ForceMode.Impulse);

        shoted = true;
    }
}
