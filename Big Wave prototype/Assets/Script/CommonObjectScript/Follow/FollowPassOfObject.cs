using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�I�u�W�F�N�g��ǐՂ���(fps�ɍ��E����Ȃ�)
public class FollowPassOfObject : MonoBehaviour
{
    [Header("�ǐՂ���^�[�Q�b�g")]
    [SerializeField] Transform _target;
    [Header("�ǐՂ�����I�u�W�F�N�g")]
    [SerializeField] Transform _followObject;
    Queue<Transform> _targetTransformQueue=new Queue<Transform>();//�ǐՂ���^�[�Q�b�g�̈ʒu����ۑ�����L���[
    JudgePauseNow _judgePauseNow;
    bool _isFollow = false;//�ǐՂ��邩

    public bool IsFollow
    {
        get { return _isFollow; }
        set { _isFollow = value; }
    }

    void Awake()
    {
        _judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    private void FixedUpdate()
    {
        if (_judgePauseNow.PauseNow) return;

        EnQueueTargetPos();

        Follow();
    }

    void EnQueueTargetPos()//�ǐՂ���^�[�Q�b�g�̈ʒu�����L���[�ɓo�^
    {
        _targetTransformQueue.Enqueue(_target);
    }

    void Follow()//�ǐՂ�����
    {
        if(!_isFollow) return;

        //�ʒu�Ɖ�]�����o���Ă����ǐՂ�����I�u�W�F�N�g�ɓK�p
        Transform _targetTransform = _targetTransformQueue.Dequeue();

        Vector3 _targetPos= _targetTransform.position;
        Quaternion _targetRot = _targetTransform.rotation;

        _followObject.position = _targetPos;
        _followObject.rotation = _targetRot;
    }
}
