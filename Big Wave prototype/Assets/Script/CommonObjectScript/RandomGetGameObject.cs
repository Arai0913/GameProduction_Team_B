using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�o�^�����Q�[���I�u�W�F�N�g�̒����烉���_���ɃQ�[���I�u�W�F�N�g��Ԃ�
[System.Serializable]
public class RandomGetGameObject
{
    [SerializeField] GameObject[] objects;

    //�Ă΂��ƃ����_���ɃQ�[���I�u�W�F�N�g��Ԃ�
    public GameObject GetObjectRandom()
    {
        if (objects == null)
        {
            Debug.Log("�����ݒ肳��Ă��܂���");
            return null;
        }

        return objects[Random.Range(0,objects.Length)];
    }
}
