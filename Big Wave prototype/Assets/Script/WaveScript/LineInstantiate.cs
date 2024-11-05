using System.Collections.Generic;
using UnityEngine;

public class LineInstantiate : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int pointNumber;
    private Queue<Transform> points = new Queue<Transform>();

   
    public void LineSet(Transform transform)
    {
        
            Transform newposition = transform;
            // �V�����_��ǉ�
            points.Enqueue(newposition);
        if(points.Count > pointNumber)
        {
            points.Dequeue();
        }
            // LineRenderer�ɔ��f
            lineRenderer.positionCount = points.Count;
            int index = 0;
            foreach (Transform point in points)
            {
                lineRenderer.SetPosition(index,point.position);
                index++;
            }
        
    }
}