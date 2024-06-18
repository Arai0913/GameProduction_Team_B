using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//������������

class Enemy : MonoBehaviour
{
    [Header("���G��HP")]
    private float hp = 4000f;//�G��HP
    [Header("���G�̍ő�HP")]
    [SerializeField] float hpMax = 4000f;//�G�̍ő�HP
    SceneControlManager sceneControlManager;
    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
        sceneControlManager= GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();
    }

    public float Hp
    {
        get { return  hp; }
        set { hp = value; }
    }

    public float HpMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    // Update is called once per frame
    void Update()
    {
        Dead();//�G���S���N���A�V�[���Ɉڍs
    }

    void Dead()//�G���S���N���A�V�[���Ɉڍs
    {
        if (hp <= 0)
        {
            controller.StopVibe_Trick();//���}���u
            sceneControlManager.ChangeClearScene();
        }
    }
    

    

    
}
