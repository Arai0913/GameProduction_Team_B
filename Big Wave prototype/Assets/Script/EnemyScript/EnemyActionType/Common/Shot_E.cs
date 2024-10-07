using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shot_E : MonoBehaviour
{
    [SerializeField] Bullet_E[] bullets;
    private float currentDelayTime;//���݂̒x�����ԁA���ꂪdelayTime�ɒB�������e���������
    [Header("��GamePos")]
    [SerializeField] GameObject gamePos;//GamePos�A�e������̎q�I�u�W�F�N�g�Ƃ��Ĕz�u����

    public void InitShotTiming()//���^�C�~���O�̏�����
    {
        for(int i=0; i<bullets.Length;i++)
        {
            bullets[i].Shoted = false;
        }

        currentDelayTime = 0;
    }

    public void ShotTiming()
    {
        currentDelayTime += Time.deltaTime;

        for(int i=0; i<bullets.Length;i++)
        {
            if (currentDelayTime >= bullets[i].DelayTime && !bullets[i].Shoted)
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(Bullet_E bullet)
    {
        bullet.Shoted = true;
        //�U�������������ʒu�Ɗp�x���擾
        Vector3 shotPosVec = bullet.ShotPos.transform.position;//�ʒu
        Quaternion shotRotVec = bullet.ShotPos.transform.rotation;//�p�x
    }


    class Shot_Homing_E
    {

    }

    class Shot_Normal_E
    {

    }
}
