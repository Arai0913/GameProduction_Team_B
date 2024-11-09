using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAtInterval : MonoBehaviour
{
    //���쐬��:�K��
    [SerializeField] GameObject instantiatePrefab;//��������v���n�u
    [SerializeField] float instantiateIntervalTime = 1.5f;//�����o���Ԋu
    private float instantiateCurrentTime = 0f;//�o���Ԋu���Ǘ����鎞��

    // Start is called before the first frame update
    void Start()
    {
        instantiateCurrentTime = instantiateIntervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        InstantiatePrefab();//����
    }

    void InstantiatePrefab()
    {
        instantiateCurrentTime += Time.deltaTime;//�o�ߎ��Ԃ̌v��

        if (instantiateCurrentTime > instantiateIntervalTime)//�o�ߎ��Ԃ����̎��Ԃ𒴂�����
        {
            instantiateCurrentTime = 0f;//�o�ߎ��Ԃ����Z�b�g
            Instantiate(instantiatePrefab, transform.position, transform.rotation); //����
        }
    }
}
