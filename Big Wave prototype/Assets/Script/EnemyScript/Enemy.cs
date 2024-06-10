using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//☆塩が書いた

class Enemy : MonoBehaviour
{
    [Header("▼敵のHP")]
    [HideInInspector] public float hp = 1000f;//敵のHP
    [Header("▼敵の最大HP")]
    public float hpMax = 1000f;//敵の最大HP
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
        Dead();//敵死亡時クリアシーンに移行
    }

    public void Damage(float a)//敵にダメージを与える(aの値分ダメージを与える)
    {
        hp -= a;
    }

    void Dead()//敵死亡時クリアシーンに移行
    {
        if (hp <= 0)
        {
            sceneControlManager.ChangeClearScene();
        }
    }
    

    

    
}
