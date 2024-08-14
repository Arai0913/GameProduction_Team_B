using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //���쐬��:���R
    [Header("�g�̐����ʒu")]
    [SerializeField] GameObject instantiateWavePos;//�g�̐����ʒu
    [Header("�g�̃v���n�u")]
    [SerializeField] GameObject wavePrefab;//�g�̃v���n�u
    [Header("�g�̏o���Ԋu")]
    [SerializeField] float waveIntervalTime = 0.1f;//�g�̏o���Ԋu
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    private float waveTime = 0f;//�g�̏o���Ԋu���Ǘ����鎞��
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//�g�̐���
    }

    //�g�̐����AwaveIntervalTime�̎��Ԃ��Ƃɔg�𐶐�����
    void InstantiateWavePrefab()
    {
        waveTime += Time.deltaTime;//�g�̏o���Ԋu���Ǘ����鎞�Ԃ��X�V

        if (waveTime>waveIntervalTime)
        {
            waveTime = 0f;//�g�̏o���Ԋu���Ǘ����鎞�Ԃ����Z�b�g
            GameObject wave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//�g�𐶐�
            wave.transform.rotation = Quaternion.Euler(0, 180, 0);//�g��������(�v���C���[����)�ɂ���
        }
    }
}
