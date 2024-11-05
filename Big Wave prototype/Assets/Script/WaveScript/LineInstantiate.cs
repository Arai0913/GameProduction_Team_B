using System.Collections.Generic;
using UnityEngine;

public class LineInstantiate : MonoBehaviour
{
    //[SerializeField] int pointNumber;
    [SerializeField] LineRenderer lineRenderer;
    private Queue<Transform> points = new Queue<Transform>();

    //�g�������ɌĂ�
    public void Method1(Transform point)
    {
        points.Enqueue(point);
        ReflectLineRenderer();// LineRenderer�ɔ��f
    }

    //�g���Œ��O���ɌĂ�
    public void Method2()
    {
        points.Dequeue();
        ReflectLineRenderer();// LineRenderer�ɔ��f
    }

    void ReflectLineRenderer()
    {
        int index = 0;
        lineRenderer.positionCount = points.Count;
        foreach (Transform point in points)
        {
            lineRenderer.SetPosition(index, point.position);
            index++;
        }
    }

    public void LineSet(Transform transform)
    {
        
        //    Transform newposition = transform;
        //    // �V�����_��ǉ�
        //    points.Enqueue(newposition);
        //if(points.Count > pointNumber)
        //{
        //    points.Dequeue();
        //}
        //    // LineRenderer�ɔ��f
        //    lineRenderer.positionCount = points.Count;
        //    int index = 0;
        //    foreach (Transform point in points)
        //    {
        //        lineRenderer.SetPosition(index, point.position);
        //        index++;
        //    }
        
    }
}