using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�v���C���[�����񂾂Ƃ��̉��o(�V�[���J�ڂ��܂߂�)
public class DeadEffect : MonoBehaviour
{
    [Header("�g���b�N�̃`���[�W")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("�v���C���[��HP")]
    [SerializeField] HP _player_HP;
    [Header("�v���C���[�̎��S���[�V����")]
    [SerializeField] PlayerDeadMotion _playerDeadMotion;
    [Header("�`���[�W�̃G�t�F�N�g")]
    [SerializeField] ChargeTrickEffect _chargeTrickEffect;
    [Header("����ύX")]
    [SerializeField] PlayerInput _playerInput;
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
    [Header("����ł��牽�b��ɃV�[���J�ڂ��邩")]
    [SerializeField] float _changeSceneTime;//���b��ɃV�[���J�ڂ��邩
    [SerializeField] JudgeGameSet _judgeGameSet;
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//���o�̊J�n��

    public void Trigger()//���o�J�n
    {
        _startEffect = true;
        _player_HP.Fix = true;//�v���C���[��HP���Œ�
        _duringGame_UI.SetActive(false);//�Q�[����UI�̔�\��
        _playerInput.SwitchCurrentActionMap("Defeat");//����̕ύX
        _chargeTrickPoint.Switch = false;//�`���[�W���Ȃ��悤�ɂ���
        //���S���̃J�����̈ړ����J�n(�����\��)
        _playerDeadMotion.Trigger();//�v���C���[�̎��S���[�V�����̍Đ�
        _timeLimit.Switch = false;//�������Ԃ��~�߂�
        _algorithmOfEnemy.Switch = false;//�G�̍s�����~�߂�
        _ropeEffect.Switch = false;//�������
        _chargeTrickEffect.Switch = false;//�`���[�W�̃G�t�F�N�g�͏o���Ȃ��悤�ɂ���
    }

    void Start()
    {
        _judgeGameSet.DeadAction += Trigger;
    }
    void Update()
    {
        UpdateChangeScene();
    }

    void UpdateChangeScene()//�V�[���ڍs�̏���
    {
        if (!_startEffect) return;
        _currentChangeSceneTime += Time.deltaTime;

        if (_currentChangeSceneTime >= _changeSceneTime)
        {
            _controller.GameOverScene();//�N���A�V�[���Ɉڍs����
        }
    }
}
