using System.Collections.Generic;
using UnityEngine;

public class PathFollower: MonoBehaviour
{
    public Transform leadingObject; // ��s�I�u�W�F�N�g�i���j
    

    // �I�u�W�F�N�g�̈ʒu�iX���j��Y���̉�]��ۑ�����L���[
    private Queue<Vector2> pathPoints = new Queue<Vector2>();
    private Queue<float> pathPoints_Z= new Queue<float>();
    void Update()
    {
        // ��s�I�u�W�F�N�g��X���̈ʒu��Y���̉�]���L���[�ɕۑ�
        pathPoints.Enqueue(new Vector2(leadingObject.position.x, leadingObject.eulerAngles.y));
        pathPoints_Z.Enqueue(leadingObject.position.z);

        float targetZ=pathPoints_Z.Peek();
        if (pathPoints.Count > 0 && transform.position.z>=targetZ)
        {
            // �L���[�̍ł��Â��ʒu�Ɖ�]���擾
            Vector2 target = pathPoints.Dequeue();
            float targetX = target.x;
            float targetRotationY = target.y;

            // �㑱�I�u�W�F�N�g�̐V�����ʒu�Ɖ�]��ݒ�
            Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(0, targetRotationY, 0);
            Debug.Log("aaaa");
        }
    }
}
