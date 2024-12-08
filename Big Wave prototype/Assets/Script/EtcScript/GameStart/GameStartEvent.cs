using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���J�n���ɌĂԏ����������ňꊇ�œo�^����
public class GameStartEvent : MonoBehaviour
{
    [Header("�X�^�[�g���ɃA�N�e�B�u�ɂ���I�u�W�F�N�g")]
    [SerializeField] GameObject[] _activeObjects;
    [Header("�Q�[���̊J�n�𔻒f����R���|�[�l���g")]
    [SerializeField] JudgeGameStart _judgeGameStart;
    [Header("�����̔g�̐���")]
    [SerializeField] InstantiateWave _inWave;
    [Header("�O���̔g�̐���")]
    [SerializeField] InstantiateWave _outWave;
    [Header("�G�̍s��")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("��������")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("BGM")]
    [SerializeField] AudioSource _bgm;
    void Start()
    {
        _judgeGameStart.StartGameAction += Event;
    }

    public void Event()
    {
        //�o�^���ꂽ�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        for(int i=0;i<_activeObjects.Length ;i++)
        {
            _activeObjects[i].SetActive(true);
        }
        //�g�𐶐����n�߂�
        _inWave.Switch = true;
        _outWave.Switch = true;
        //�G���s�����n�߂�
        _algorithmOfEnemy.Switch = true;
        //���Ԑ���������n�߂�
        _timeLimit.Switch = true;
        //BGM�𗬂��n�߂�
        _bgm.Play();
    }
}
