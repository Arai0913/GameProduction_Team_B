using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [Header("�ő�̗�")]
    [SerializeField] float hpMax = 500;//�ő�̗�
    private float hp = 500;//���݂̗̑�
    

    public float Hp
    {
        get { return hp; }
        set 
        {
            hp = value;
            hp = Mathf.Clamp(hp, 0f, hpMax);//�̗͂����E�˔j���Ȃ��悤��
        }
    }

    public float HpMax
    {
        get { return hpMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hp�̏�����
        hp = hpMax;   
    }

    // Update is called once per frame
    void Update()
    {
    }
}
