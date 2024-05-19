using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    public float Add_y;
    [SerializeField] GameObject instantiateWavePos;//�g�̐����ʒu
    [SerializeField] GameObject outSideWave;//�O���̔g�̃v���n�u
    [SerializeField] GameObject inSideWave;//����(����)�̔g�̃v���n�u
    [SerializeField] float outSideWaveIntervalTime = 0.1f;//�O���̔g�̏o���Ԋu
    [SerializeField] float inSideWaveIntervalTime = 0.1f;//�����̔g�̏o���Ԋu
    private float outSideWaveTime = 0f;//�O���̔g�̏o���Ԋu���Ǘ����鎞��
    private float inSideWaveTime = 0f;//����(����)�̔g�̏o���Ԋu���Ǘ����鎞��
    private Vector3 inSideWavePos;//�����̔g�̐����ʒu�AinstantiateWavePos������������y���W�Ő�������
    // Start is called before the first frame update
    void Start()
    {
        instantiateWavePos.transform.position = new(instantiateWavePos.transform.position.x, instantiateWavePos.transform.position.y + Add_y, instantiateWavePos.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateOutSideWave();//�O���̔g�̐���   
        InstantiateInSideWave();//����(����)�̔g�̐���
    }

    //�O���̔g�̐���
    //outSideWaveIntervalTime�̎��Ԃ��Ƃɔg�𐶐�����
    void InstantiateOutSideWave()
    {
        outSideWaveTime += Time.deltaTime;
        if (outSideWaveTime > outSideWaveIntervalTime)
        {
           
            outSideWaveTime = 0f;
            Instantiate(outSideWave, instantiateWavePos.transform.position, transform.rotation);
        }
    }

    //����(����)�̔g�̐���
    //inSideWaveIntervalTime�̎��Ԃ��Ƃɔg�𐶐�����
    void InstantiateInSideWave()
    {
        inSideWavePos = instantiateWavePos.transform.position;
        inSideWavePos.y += 0.1f;//instantiateWavePos������������y���W�Ő�������
        inSideWaveTime += Time.deltaTime;
        if (inSideWaveTime > inSideWaveIntervalTime)
        {
            inSideWaveTime = 0f;
            Instantiate(inSideWave, inSideWavePos, transform.rotation);
        }
    }
}
