using UnityEngine;

public class PingPongVertical : MonoBehaviour
{
    // �������钷��
    [SerializeField] private float _length = 50;
    public float speed = 10;
    private void Update()
    {
        // ���������l�����Ԃ���v�Z
        var value = Mathf.PingPong(Time.time*speed, _length) - _length / 2; ;

        // y���W�����������ď㉺�^��������
        transform.Translate(Vector3.right * value * Time.deltaTime);
    }
}