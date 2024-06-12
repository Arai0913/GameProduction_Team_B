using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeEffect : MonoBehaviour
{
    //���K���N��������
    Enemy enemy;
    Player player;
    LineRenderer lineRenderer; // LineRenderer�R���|�[�l���g

    [SerializeField] GameObject startPoint;//���[�v�̎n�_
    [SerializeField] GameObject endPoint;//���[�v�̏I�_
    public GameObject[] vertices = new GameObject[20];//���[�v�̎��_

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = vertices.Length;

        foreach (GameObject v in vertices)
        {
            v.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (enemy.Hp > 0 && player.Hp > 0)
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
        Vector3 enemyPosition = enemy.transform.position;//�G�̍��W���擾
        Vector3 playerPosition = player.transform.position;//�v���C���[�̍��W���擾
        enemyPosition.z -= enemy.transform.localScale.z / 2f;
        playerPosition.z += player.transform.localScale.z / 2f;

        startPoint.transform.position = playerPosition;//���[�v�̎��_�̍��W�Ƀv���C���[�̍��W�Ɉړ�
        endPoint.transform.position = enemyPosition;//���[�v�̏I�_�̍��W��G�̍��W�Ɉړ�

        int index = 0;
        foreach (GameObject v in vertices)
        {
            lineRenderer.SetPosition(index, v.transform.position);  // ���_�̍��W��ݒ�
            index++;
        }
    }
}
