using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class LimitMoveObject
{
    [Header("�ړ��\�͈�")]
    [SerializeField] float range = 7f;//�ړ��\�͈�
    [Header("�ړ�����������I�u�W�F�N�g")]
    [SerializeField] GameObject limitObjects;

    //�����̐���
    //�ړ��\�͈͊O�ɏo�Ȃ��悤�ɂ���
    internal void Limit()
    {
        Vector3 currentPos = limitObjects.transform.localPosition;
        currentPos.x = Mathf.Clamp(currentPos.x, -range, range);//x���ňړ��\�͈͂𐧌�����
        limitObjects.transform.localPosition = currentPos;
    }
}

public class LimitMove : MonoBehaviour
{
    [Header("�ړ��������������I�u�W�F�N�g�Ɛ����͈�")]
    [SerializeField] LimitMoveObject[] limitMoveObjects;//�ړ��������������I�u�W�F�N�g�Ɛ����͈�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i< limitMoveObjects.Length;i++)
        {
            limitMoveObjects[i].Limit();
        }
    }
}
