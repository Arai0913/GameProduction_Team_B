using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildings : MonoBehaviour
{
    //���쐬��:�K��
    //����ɐ��R���ꕔ����
    [SerializeField] GameObject buildingsPrefab;//�r���̃v���n�u
    [SerializeField] GameObject lastBuilding;//���O�ɐ������ꂽ�r���̃v���n�u
    [SerializeField] float generationDistance = 70f;//�r���̏o���Ԋu

    private Vector3 lastPosition;
    private float buildingWidth;
    private float buildingDepth;

    // Start is called before the first frame update
    void Start()
    {
        if (buildingsPrefab != null)
        {
            BoxCollider collider = buildingsPrefab.GetComponent<BoxCollider>();

            if (collider != null)
            {
                buildingWidth = collider.size.x;
                buildingDepth = collider.size.z;
            }

            lastPosition = lastBuilding.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBuildingsPrefab();//�r���̐���
    }

    void InstantiateBuildingsPrefab()
    {
        Vector3 newPosition = transform.position;

        if (Vector3.Distance(newPosition, lastPosition) > generationDistance)//���񐶐�����r���ƑO�񐶐�����Ă���r���̊Ԋu�����ȏ㗣�ꂽ��
        {
            bool isOverlapX = Mathf.Abs(newPosition.x - lastPosition.x) > buildingWidth;//x���W�̊Ԋu���r����x���T�C�Y�����傫�����ǂ���
            bool isOverlapZ = Mathf.Abs(newPosition.z - lastPosition.z) > buildingDepth;//z���̊Ԋu���r����z���T�C�Y�����傫�����ǂ���

            if (isOverlapX || isOverlapZ)//�r�����m�̏d�Ȃ肪�Ȃ��Ȃ�
            {
                GameObject newBuilding = Instantiate(buildingsPrefab, newPosition, transform.rotation);

                lastPosition = newPosition;//�Ō�ɐ������������̈ʒu���X�V
            }
        }
    }
}
