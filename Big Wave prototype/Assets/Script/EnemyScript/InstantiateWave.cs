using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //���쐬��:���R
    [SerializeField] GameObject instantiateWavePos;//�g�̐����ʒu
    [SerializeField] GameObject outSideWave;//�O���̔g�̃v���n�u
    [SerializeField] GameObject inSideWave;//����(����)�̔g�̃v���n�u
    [SerializeField] float outSideWaveIntervalTime = 0.1f;//�O���̔g�̏o���Ԋu
    [SerializeField] float inSideWaveIntervalTime = 0.1f;//�����̔g�̏o���Ԋu
    [SerializeField] GameObject gamePos;
    private float outSideWaveTime = 0f;//�O���̔g�̏o���Ԋu���Ǘ����鎞��
    private float inSideWaveTime = 0f;//����(����)�̔g�̏o���Ԋu���Ǘ����鎞��
    private Vector3 inSideWavePos;//�����̔g�̐����ʒu�AinstantiateWavePos������������y���W�Ő�������
    // Start is called before the first frame update
    void Start()
    {

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
            GameObject wave= Instantiate(outSideWave, instantiateWavePos.transform.position, transform.rotation,gamePos.transform);
            wave.transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    //����(����)�̔g�̐���
    //inSideWaveIntervalTime�̎��Ԃ��Ƃɔg�𐶐�����
    void InstantiateInSideWave()
    {
        inSideWavePos = instantiateWavePos.transform.position;//�g�̔����ʒu���擾
        inSideWavePos.y += 0.1f;//instantiateWavePos������������y���W�Ő�������
        inSideWaveTime += Time.deltaTime;
        if (inSideWaveTime > inSideWaveIntervalTime)
        {
            inSideWaveTime = 0f;
            GameObject wave = Instantiate(inSideWave, inSideWavePos, transform.rotation,gamePos.transform);
            wave.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
