using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyActionTypeShotHoming : EnemyActionTypeBase
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
    [SerializeField] protected GameObject gamePos;//GamePos
    [Header("�v���C���[")]
    [SerializeField] GameObject player;//�v���C���[

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        shoted = false;
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime >= delayTime && !shoted)//�w��̒x�����ԂɒB�������܂��e�������Ă��Ȃ���
        {
            Shot();
        }
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }


    void Shot()
    {
        //�U�������������ʒu���擾
        Vector3 shotPos = shotPosObject.transform.position;
        //�U����z�u����
        GameObject Bullet = Instantiate(bulletPrefab, shotPos, transform.rotation, gamePos.transform);
        //�e��Rigidbody���擾
        Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
        //���ꏊ����v���C���[�����̃x�N�g�����Z�o&�傫����1��
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        //�U���̌������v���C���[�̂�������ɕύX
        Bullet.transform.rotation = Quaternion.LookRotation(toPlayer, Vector3.up);
        //�e����������
        bulletRb.AddForce(toPlayer * shotPower, ForceMode.Impulse);

        shoted= true;
    }
}
