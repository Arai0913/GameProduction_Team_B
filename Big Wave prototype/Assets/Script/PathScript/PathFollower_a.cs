using System.Collections.Generic;
using UnityEngine;

public class PathFollower_a : MonoBehaviour
{
    public Transform leadingObject;  // ��s�I�u�W�F�N�g�i���j
    public float waitTime = 3.0f;    // �w�肵���b����ɒǏ]���鎞�ԍ�

    private Queue<Vector3> pathPoints_P = new Queue<Vector3>();  // �ʒu��ۑ�����L���[
    private Queue<Quaternion> pathPoints_R = new Queue<Quaternion>();  // ��]��ۑ�����L���[
    private int requiredQueueSize;  // �Ǐ]���J�n���邽�߂ɕK�v�ȃL���[�T�C�Y

    void Awake()
    {
        Application.targetFrameRate = 60;
        // �K�v�ȃL���[�T�C�Y���t���[�����[�g�Ɋ�Â��Čv�Z
        requiredQueueSize = Mathf.RoundToInt(waitTime / Time.deltaTime); 
        Debug.Log(Mathf.RoundToInt(waitTime / Time.deltaTime));
        pathPoints_P.Enqueue(leadingObject.position);
        pathPoints_R.Enqueue(leadingObject.rotation);

    }

    void Update()
    {
        // ��s�I�u�W�F�N�g�̈ʒu�Ɖ�]���L���[�ɕۑ�
        pathPoints_P.Enqueue(leadingObject.position);
        pathPoints_R.Enqueue(leadingObject.rotation);

        // �K�v�ȃL���[�T�C�Y���f�[�^�����܂�܂őҋ@
        if (pathPoints_P.Count > requiredQueueSize)
        {
            
            // �L���[�̍ł��Â��ʒu�Ɖ�]���擾���ăt�H�����[��Ǐ]������
            Vector3 target_P = pathPoints_P.Dequeue();
            Quaternion target_R = pathPoints_R.Dequeue();

            transform.position = target_P;
          
            transform.rotation = target_R;
        }
        
    }
}
