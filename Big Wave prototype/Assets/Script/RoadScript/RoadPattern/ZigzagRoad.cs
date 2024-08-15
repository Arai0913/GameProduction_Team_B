using UnityEngine;

public class ZigzagRoad : RoadBase
{
    // �������钷��
    
    [SerializeField] private float length = 50;
    [SerializeField]  GameObject target;
    public float speed = 10;
    public override void OnEnter(RoadBase roadBases_Entry)
    {
        
    }
    public override void OnUpdate()
    {
        // ���������l�����Ԃ���v�Z
        var value = Mathf.PingPong(Time.time * speed, length) - length / 2; ;

        target.transform.Translate(Vector3.right * value * Time.deltaTime);
        
    }
    public override void OnExit(RoadBase roadBases_Exit)
    {
      
    }
}