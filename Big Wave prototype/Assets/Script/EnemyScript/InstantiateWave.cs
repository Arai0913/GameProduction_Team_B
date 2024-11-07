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
    [Header("�����ȍ~�̔g�̏o���Ԋu")]
    [SerializeField] float waveInterval;//�����ȍ~�̔g�̏o���Ԋu
    [Header("�����̔g�̏o���Ԋu")]
    [Tooltip("�Q�[���J�n����1�ڂ̔g���o��������܂ł̎��ԁB1�ڂ̔g�𐶐������炻��ȍ~�͏�̏����ȍ~�̔g�̏o���Ԋu�ɍ��킹�Ĕg�𐶐�����")]
    [SerializeField] float firstWaveInterval;//�����̔g�̏o���Ԋu
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("LineInstantiate")]
  [SerializeField] LineInstantiate m_lineInstantiate;
   
    private float m_waveTime;//�g�̏o���Ԋu���Ǘ����鎞��(�������l)
    JudgeGameStart judgeGameStart;
    //LineInstantiate line;

    // Start is called before the first frame update
    void Start()
    {
        //line = GameObject.FindWithTag("LineManager").GetComponent<LineInstantiate>();
        judgeGameStart=GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
       
        //�����̔g�̏o���Ԋu�ɍ��킹�邽�߂ɔg�̏o���Ԋu���Ǘ����鎞�Ԃ����̕����炷
        m_waveTime = 0 - (firstWaveInterval - waveInterval);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//�g�̐���
    }

    //�g�̐����AwaveIntervalTime�̎��Ԃ��Ƃɔg�𐶐�����
    void InstantiateWavePrefab()
    {
        if (!judgeGameStart.IsStarted) return;//�܂��Q�[���J�n����ĂȂ�������g�𐶐����Ȃ�

        m_waveTime += Time.deltaTime;//�g�̏o���Ԋu���Ǘ����鎞�Ԃ��X�V
        
        if (m_waveTime > waveInterval)
        {
            m_waveTime = 0f;//�g�̏o���Ԋu���Ǘ����鎞�Ԃ����Z�b�g
            GameObject wave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//�g�𐶐�
            wave.transform.localRotation = Quaternion.Euler(0, 180, 0);//�g��������(�v���C���[����)�ɂ���
            m_lineInstantiate.Method1(wave.transform);
            LineWave lineWave= wave.GetComponent<LineWave>();
            lineWave.Method1(m_lineInstantiate);
            //line.LineSet(wave.transform);
        }
    }
}
