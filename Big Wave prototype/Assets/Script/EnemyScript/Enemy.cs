using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //������������
    public float hp = 1000f;//�G��HP
    public float hpMax = 1000f;//�G�̍ő�HP
    SceneControlManager sceneControlManager;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
        sceneControlManager= GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Dead();//�G���S���N���A�V�[���Ɉڍs
    }

    public void Damage(float a)//�G�Ƀ_���[�W��^����(a�̒l���_���[�W��^����)
    {
        hp -= a;
    }

    void Dead()//�G���S���N���A�V�[���Ɉڍs
    {
        if (hp <= 0)
        {
            sceneControlManager.ChangeClearScene();
        }
    }
    

    

    
}
