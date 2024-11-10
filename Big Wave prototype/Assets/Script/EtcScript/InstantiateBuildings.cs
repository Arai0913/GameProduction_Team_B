using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildings : MonoBehaviour
{
    //���쐬��:�K��
    //����ɐ��R���ꕔ����
    [Header("�������������I�u�W�F�N�g�����Ă�������")]
    [SerializeField] RandomGetGameObject randomGetGameObject = new RandomGetGameObject();//�o�^�����I�u�W�F�N�g�������_���Ɏ擾����
    //[SerializeField] GameObject buildingsPrefab;//�������錚���̃v���n�u
    [SerializeField] GameObject lastBuilding;//���O�ɐ������ꂽ�����̃v���n�u

    private Vector3 lastPosition;
    private float building_sizeX;//������x�������̑傫��
    private float building_sizeZ;//������z�������̑傫��

    // Start is called before the first frame update
    void Start()
    {
        if (randomGetGameObject != null)
        {
            BoxCollider collider = randomGetGameObject[0].GetComponent<BoxCollider>();

            if (collider != null)
            {
                building_sizeX = collider.size.x;
                building_sizeZ = collider.size.z;
            }
        }

        if (lastBuilding != null)
        {
            lastPosition = lastBuilding.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBuildingsPrefab();//�����̐���
    }

    void InstantiateBuildingsPrefab()//�����̐���
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = (currentPosition - lastPosition).normalized; //�O��̈ʒu���猻�݂̈ʒu�ւ̐i�s�����x�N�g��
        
        float minGenerationDistance = Mathf.Max(building_sizeX, building_sizeZ);//�����̃T�C�Y�ɉ����������Ԋu�̐ݒ�

        if (Vector3.Distance(currentPosition, lastPosition) > minGenerationDistance)//�w�肳�ꂽ�����ȏ㗣�ꂽ�Ƃ��ɂ̂ݐ���
        {            
            Vector3 newPosition = lastPosition + direction * minGenerationDistance;//�i�s�����ɉ������V�����ʒu�̌v�Z
            
            GameObject newBuilding = Instantiate(randomGetGameObject.GetObjectRandom(), newPosition, transform.rotation);//�V���������𐶐�

            lastPosition = newPosition;//�Ō�ɐ������������̈ʒu���X�V
        }
    }
}
