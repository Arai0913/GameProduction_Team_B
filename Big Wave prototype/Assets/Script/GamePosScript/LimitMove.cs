using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMove : MonoBehaviour
{
    [Header("�ړ��\�͈�")]
    [SerializeField] float range = 7f;//�ړ��\�͈�
    [Header("�ړ�����������I�u�W�F�N�g")]
    [SerializeField] GameObject[] limitObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<limitObjects.Length;i++)
        {
            Limit(limitObjects[i]);
        }
    }

    //�L�����̓����̐���
    //�ړ��\�͈͊O�ɏo�Ȃ��悤�ɂ���
    void Limit(GameObject obj)
    {
        Vector3 currentPlayerPos = obj.transform.localPosition;
        currentPlayerPos.x = Mathf.Clamp(currentPlayerPos.x, -range, range);//x���ňړ��\�͈͂𐧌�����
        obj.transform.localPosition = currentPlayerPos;
    }
}
