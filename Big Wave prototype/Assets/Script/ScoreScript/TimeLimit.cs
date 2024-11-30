using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��������
public class TimeLimit : MonoBehaviour
{
    [Header("���������ԁi�b�j")]
    [SerializeField] float timeLimit = 120;//��������(�b)
    private float remainingTime;//�c�莞��
    bool _switch=false;//���ꂪfalse�̎��͎��Ԃ�����Ȃ��Ȃ�

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    public float RemainingTime
    {
        get { return remainingTime; }
    }

    void Start()
    {
        remainingTime = timeLimit;
    }

    void Update()
    {
       UpdateTime();
    }

    void UpdateTime()//���Ԃ̍X�V(�X�C�b�`���I�t�̎��͎��Ԃ��~�߂�)
    {
        if (!_switch) return;

        remainingTime -= Time.deltaTime;
    }
}
