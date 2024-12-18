using System.Collections.Generic;
using UnityEngine;

public class LineInstantiate : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    private Queue<Transform> points = new Queue<Transform>();

    private void Update()
    {
        ReflectLineRenderer();
    }

    //線生成位置の追加

    public void Add(Transform point)
    {
        points.Enqueue(point);
    }

    //線生成位置の削除
    public void Remove()
    {
        points.Dequeue();
    }

    void ReflectLineRenderer()// LineRendererに反映
    {
        int index = 0;
        lineRenderer.positionCount = points.Count;
        foreach (Transform point in points)
        {
            lineRenderer.SetPosition(index, point.position);
            index++;
        }
    }

    //public void LineSet(Transform transform)
    //{
    //    //    Transform newposition = transform;
    //    //    // 新しい点を追加
    //    //    points.Enqueue(newposition);
    //    //if(points.Count > pointNumber)
    //    //{
    //    //    points.Dequeue();
    //    //}
    //    //    // LineRendererに反映
    //    //    lineRenderer.positionCount = points.Count;
    //    //    int index = 0;
    //    //    foreach (Transform point in points)
    //    //    {
    //    //        lineRenderer.SetPosition(index, point.position);
    //    //        index++;
    //    //    }
        
    //}
}