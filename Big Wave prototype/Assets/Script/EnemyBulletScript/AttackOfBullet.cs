using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOfBullet : MonoBehaviour
{
    //������������
    [SerializeField] float damage;//�_���[�W��
    [SerializeField] bool ifHitDestroy=true;//�v���C���[�ɓ����������ɒe��������
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("Player"))
        {
            HP player_Hp;
            player_Hp = t.GetComponent<HP>();
            ManagementOfScore managementOfScore;
            managementOfScore = GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();

            player_Hp.Hp -= damage;//�v���C���[�Ƀ_���[�W��^����
            managementOfScore.AddDamageCount();//��e�񐔂𑝂₷
            

            if(ifHitDestroy)//true�������������e��������
            {
                Destroy(gameObject);
            }
        }
    }
}
