using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�G��|�����Ƃ��̉��o(�V�[���J�ڂ��܂߂�)
public class DefeatEnemyEffect : MonoBehaviour
{
    [Header("����ύX")]
    [SerializeField] PlayerInput _playerInput;
    [Header("�G�̎��S���[�V����")]
    [SerializeField] EnemyDeadMotion _enemyDeadMotion;
    [Header("�����̔g�̐���")]
    [SerializeField] InstantiateWave inWave;
    [Header("�O���̔g�̐���")]
    [SerializeField] InstantiateWave outWave;
    [Header("���[�v")]
    [SerializeField] RopeEffect _ropeEffect;
    [Header("��������")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("�G�̍s��")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("�Q�[������UI")]
    [SerializeField] GameObject _duringGame_UI;
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;
    [Header("�G��|���Ă��牽�b��ɃV�[���J�ڂ��邩")]
    [SerializeField] float _changeSceneTime;//���b��ɃV�[���J�ڂ��邩
    float _currentChangeSceneTime=0;
    bool _startEffect=false;//���o�̊J�n��

    public void Trigger()//���o�J�n
    {
        _startEffect = true;
        _duringGame_UI.SetActive(false);//�Q�[����UI�̔�\��
        _playerInput.SwitchCurrentActionMap("Win");//����̕ύX
        //�N���A���̃J�����̈ړ����J�n(�����\��)
        _enemyDeadMotion.Trigger();//�G�̌��j���[�V�����̍Đ�
        _timeLimit.Switch = false;//�������Ԃ��~�߂�
        _algorithmOfEnemy.Switch = false;//�G�̍s�����~�߂�
        _ropeEffect.Switch = false;//�������
        //�g�̐������~�߂�
        inWave.Switch = false;
        outWave.Switch = false;
    }

    void Update()
    {
        UpdateChangeScene();
    }

    void UpdateChangeScene()//�V�[���ڍs�̏���
    {
        if (!_startEffect) return;
        _currentChangeSceneTime += Time.deltaTime;

        if(_currentChangeSceneTime>=_changeSceneTime)
        {
            _controller.ClearScene();//�N���A�V�[���Ɉڍs����
        }
    }
}
