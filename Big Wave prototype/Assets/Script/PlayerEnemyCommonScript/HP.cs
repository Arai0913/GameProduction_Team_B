using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//HP
public class HP : MonoBehaviour
{
    [Header("�ő�̗�")]
    [SerializeField] float hpMax = 500;//�ő�̗�
    [Header("�Q�[���I���̔��f")]
    [SerializeField] JudgeGameSet gameSet;
    private float hp = 500;//���݂̗̑�
    

    public float Hp
    {
        get { return hp; }
        set 
        {
            if (gameSet.GameSet) return;//�Q�[�����I��������̗͂��ϓ����Ȃ��悤�ɂ���

            hp = value;
            hp = Mathf.Clamp(hp, 0f, hpMax);//�̗͂����E�˔j���Ȃ��悤��
        }
    }

    public float HpMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    void Start()
    {
        //Hp�̏�����
        hp = hpMax;   
    }
}
