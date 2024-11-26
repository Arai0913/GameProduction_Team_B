using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeEffect : MonoBehaviour
{
    //���쐬��:�K��
    [SerializeField] HP player_Hp;
    [SerializeField] HP enemy_Hp;
    LineRenderer lineRenderer; // LineRenderer�R���|�[�l���g

    [SerializeField] GameObject startPoint;//���[�v�̎n�_
    [SerializeField] GameObject endPoint;//���[�v�̏I�_
    [SerializeField] GameObject[] vertices = new GameObject[20];//���[�v�̎��_

    void Start()
    {   
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = vertices.Length;

        foreach (GameObject v in vertices)
        {
            v.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (enemy_Hp.Hp > 0 && player_Hp.Hp > 0)
        {
            DrawRope();
        }

        else
        {
            lineRenderer.positionCount = 0;//���[�v�̕`�ʂ��Ȃ���
        }
    }

    void DrawRope()
    {
        //Vector3 enemyPosition = enemy.transform.position;//�G�̍��W���擾
        //Vector3 playerPosition = player.transform.position;//�v���C���[�̍��W���擾

        //Vector3 enemyLocalPosition= transform.InverseTransformPoint(enemyPosition);
        //Vector3 playerLocalPosition = transform.InverseTransformPoint(playerPosition);

        //enemyLocalPosition.z -= enemy.transform.localScale.z / 2f;
        //playerLocalPosition.z += player.transform.localScale.z / 2f;

        //enemyPosition= transform.TransformPoint(enemyLocalPosition);
        //playerPosition= transform.TransformPoint(playerLocalPosition);

        //startPoint.transform.position = playerPosition;//���[�v�̎n�_�̍��W���v���C���[�̍��W�Ɉړ�
        //endPoint.transform.position = enemyPosition;//���[�v�̏I�_�̍��W��G�̍��W�Ɉړ�

        int index = 0;
        foreach (GameObject v in vertices)
        {
            lineRenderer.SetPosition(index, v.transform.position);  // ���_�̍��W��ݒ�
            index++;
        }
    }
}
