using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�̒e(�U��)�̒�������
public class EnemyActionTypeShotStraight : EnemyActionTypeBase
{
    [Header("���e")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("������")]
    [SerializeField] float shotPower;//����
    [Header("���e�����������ʒu�Ɗp�x")]
    [SerializeField] Transform shotPosObject;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    private bool shoted;//�e����������
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����
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
        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPos = shotPosObject.transform.position;//�ʒu
        Quaternion shotRot = shotPosObject.transform.rotation;//�p�x
        //�U����z�u����
        GameObject bullet = Instantiate(bulletPrefab, shotPos, shotRot, gamePos.transform);
        //�e��Rigidbody���擾
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        //�e����������
        bulletRb.AddForce(shotPosObject.transform.forward * shotPower, ForceMode.Impulse);

        shoted = true;
    }
}
