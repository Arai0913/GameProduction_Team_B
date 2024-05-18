using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 1000f;//�G��HP
    public float hpMax = 1000f;//�G�̍ő�HP
    
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();//�G���S
    }

    public void Damage(float a)//�G�Ƀ_���[�W��^����(a�̒l���_���[�W��^����)
    {
        hp -= a;
    }

    void DeadEnemy()//�G���S���A�G������
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    

    
}
