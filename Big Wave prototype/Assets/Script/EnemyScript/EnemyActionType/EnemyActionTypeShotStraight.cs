using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�̒e(�U��)�̒�������
public class EnemyActionTypeShotStraight : EnemyActionTypeBase
{
    [Header("���e")]
    [SerializeField] protected GameObject bulletPrefab;//���������e
    [Header("������")]
    [SerializeField] protected float shotPower;//����
    [Header("���e�����������ʒu")]
    [SerializeField] protected Transform shotPosObject;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    private bool shoted;
    [Header("��GamePos")]
    [SerializeField] protected GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;
    

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        shoted = false;
        actionEffect.Generate();//�G�t�F�N�g����
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime >= delayTime&&!shoted)//�w��̒x�����ԂɒB�������܂��e�������Ă��Ȃ���
        {
            Shot();
        }
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }


    void Shot() //�e������
    {
        //�U�������������ʒu���擾
        Vector3 shotPos = shotPosObject.transform.position;
        //�U����z�u����
        GameObject Bullet = Instantiate(bulletPrefab, shotPos, transform.rotation, gamePos.transform);
        //�e��Rigidbody���擾
        Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
        //�e����������
        bulletRb.AddForce(-transform.forward * shotPower, ForceMode.Impulse);

        shoted = true;
    }
}
