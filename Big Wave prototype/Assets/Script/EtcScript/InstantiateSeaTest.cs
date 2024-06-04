using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSeaTest : MonoBehaviour
{
    //���K���N��������
    [SerializeField] GameObject seaTestPrefab;//�C�̃v���n�u
    [SerializeField] float instantiateIntervalTime = 6.2f;//�C�̏o���Ԋu

    private float instantiatePrefabTime = 0f;//�C�̏o���Ԋu���Ǘ����鎞��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateSeaTestPrefab();//�C�̐���
    }

    void InstantiateSeaTestPrefab()
    {
        instantiatePrefabTime += Time.deltaTime;//�o�ߎ��Ԃ̌v��

        if (instantiatePrefabTime > instantiateIntervalTime)//�o�ߎ��Ԃ����̎��Ԃ𒴂�����
        {
            instantiatePrefabTime = 0f;//�o�ߎ��Ԃ����Z�b�g
            Instantiate(seaTestPrefab, transform.position, transform.rotation); //�C�̐���
        }
    }
}
