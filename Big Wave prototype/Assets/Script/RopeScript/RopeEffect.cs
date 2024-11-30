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
    bool _switch = true;

    public bool Switch
    {
        get { return _switch; } 
        set {  _switch = value; } 
    }

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
        if (_switch)
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
        int index = 0;
        foreach (GameObject v in vertices)
        {
            lineRenderer.SetPosition(index, v.transform.position);  // ���_�̍��W��ݒ�
            index++;
        }
    }
}
