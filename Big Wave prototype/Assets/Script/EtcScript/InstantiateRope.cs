using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRope : MonoBehaviour
{
    //���K���N��������
    Enemy enemy;
    Player player;

    [SerializeField] GameObject ropePrefab;//���[�v�̃v���n�u
    private GameObject ropeInstance;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        ropeInstance = Instantiate(ropePrefab);//���[�v����
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.Hp <= 0 || player.Hp <= 0)//�G���v���C���[��hp��0�ȉ��ɂȂ�����
        {
            Destroy(ropeInstance);//���[�v����
        }
    }
}
