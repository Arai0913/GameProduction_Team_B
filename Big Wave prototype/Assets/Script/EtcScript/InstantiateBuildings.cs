using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildings : MonoBehaviour
{
    //���K���N��������
    [SerializeField] GameObject buildingsPrefab;//�r���̃v���n�u
    [SerializeField] GameObject buildingsGroundPrefab;//�r���̒n�ʕ��̃v���n�u
    [SerializeField] float buildingsPrefabPosX = -37f;//��������r����X���̍��W�i�����p�j
    [SerializeField] float buildingsPrefabRotY = 90f;//��������r����Y���̊p�x�i�����p�j
    [SerializeField] float buildingsGroundPrefabPosX = -48f;//��������r���̒n�ʕ���X���̈ʒu�i�����p�j
    [SerializeField] float instantiateIntervalTime = 2.5f;//�r���̏o���Ԋu

    private float instantiatePrefabTime = 0f;//�r���̏o���Ԋu���Ǘ����鎞��
    private int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBuildingsPrefab();//�r���̐���
    }

    void InstantiateBuildingsPrefab()
    {
        instantiatePrefabTime += Time.deltaTime;//�o�ߎ��Ԃ̌v��

        if(instantiatePrefabTime > instantiateIntervalTime)//�o�ߎ��Ԃ����̎��Ԃ𒴂�����
        {
            randomNumber = Random.Range(0, 2);
            instantiatePrefabTime = 0f;//�o�ߎ��Ԃ����Z�b�g

            Instantiate(buildingsGroundPrefab,
                new Vector3(buildingsGroundPrefabPosX, transform.position.y, transform.position.z),
                transform.rotation);//�r���̒n�ʕ��̐���

            if (randomNumber == 0)//�����_���Ɏ擾�����l��0�������ꍇ
            {
                Instantiate(buildingsPrefab,
                    new Vector3(buildingsPrefabPosX, transform.position.y, transform.position.z),
                    Quaternion.Euler(0f, buildingsPrefabRotY, 0f));
                //buildingsPrefabRotY�̒l�̕�����Y���ɉ�]�����ĕ\��
            }

            else//�����_���Ɏ擾�����l��1�������ꍇ
            {
                Instantiate(buildingsPrefab,
                   new Vector3(buildingsPrefabPosX, transform.position.y, transform.position.z),
                   Quaternion.Euler(0f, -buildingsPrefabRotY, 0f));
                //buildingsPrefabRotY�̒l�̕�����Y���ɋt��]�����ĕ\��
            }
        }
    }
}
