using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    [SerializeField] GameObject wave;//�g�̃v���n�u
    [SerializeField] float waveIntervalTime = 0.1f;//�g�̏o���Ԋu
    private float waveTime = 0f;//�g�̏o���Ԋu���Ǘ����鎞��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate_Wave();//�g�̐���   
    }

    //�g�̐���
    //waveInterval�̎��Ԃ��Ƃɔg�𐶐�����
    void Instantiate_Wave()
    {
        waveTime += Time.deltaTime;
        if (waveTime > waveIntervalTime)
        {
            Vector3 wavecurrentpos = transform.position;
            wavecurrentpos.y = 0.04f;
            waveTime = 0f;
            Instantiate(wave, wavecurrentpos, transform.rotation);
        }
    }
}
