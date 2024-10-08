using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�G�̒e(�U��)�̕W�I(�v���C���[)�Ɍ������Ă̒�������
public class EnemyActionTypeShotToTarget : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("���e")]
    [SerializeField] GameObject bulletPrefab;//���������e
    [Header("������")]
    [SerializeField] float shotPower;//����
    [Header("���e�����������ʒu")]
    [SerializeField] Transform shotPosObject;//�e�����������ʒu
    [Header("���s���J�n���猂�܂ł̒x������")]
    [Header("��:�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�")]
    [SerializeField] float delayTime;//�s���J�n���猂�܂ł̒x�����ԁA�s�����Ԗ����ɂ��Ȃ��ƌ����ꂸ�ɍs�����I����Ă��܂�
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    private bool shoted;//�e����������
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("�v���C���[")]
    [SerializeField] GameObject player;//�v���C���[
    [Header("�s�����̃G�t�F�N�g")]
    [SerializeField] ActionEffect actionEffect;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        shoted = false;
        actionEffect.Generate();//�G�t�F�N�g����
        animController.AnimControl_Trigger(animName);
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
        Quaternion shotRot = shotPosObject.transform.rotation;//�p�x
        //�U����z�u����
        GameObject bullet = Instantiate(bulletPrefab, shotPos, shotRot, gamePos.transform);
        //�e��Rigidbody���擾
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        //���ꏊ����v���C���[�����̃x�N�g�����Z�o&�傫����1��
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        //�U���̌������v���C���[�̂�������ɕύX
        bullet.transform.rotation = Quaternion.LookRotation(toPlayer, Vector3.up);
        //�e����������
        bulletRb.AddForce(toPlayer * shotPower, ForceMode.Impulse);

        shoted= true;
    }
}
