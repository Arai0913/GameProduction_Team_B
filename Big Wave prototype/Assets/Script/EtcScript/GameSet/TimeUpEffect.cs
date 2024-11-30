using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�^�C���A�b�v���̉��o(�V�[���J�ڂ��܂߂�)
public class TimeUpEffect : MonoBehaviour
{
    [Header("�g���b�N�̃`���[�W")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("�v���C���[��HP")]
    [SerializeField] HP _player_HP;
    [Header("����ύX")]
    [SerializeField] PlayerInput _playerInput;
    [Header("��������")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("�G�̍s��")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("�Q�[������UI")]
    [SerializeField] GameObject _duringGame_UI;
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;
    [Header("�^�C���A�b�v���Ă��牽�b��ɃV�[���J�ڂ��邩")]
    [SerializeField] float _changeSceneTime;//���b��ɃV�[���J�ڂ��邩
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//���o�̊J�n��

    public void Trigger()//���o�J�n
    {
        _startEffect = true;
        _player_HP.Fix = true;//�v���C���[��HP���Œ�
        _duringGame_UI.SetActive(false);//�Q�[����UI�̔�\��
        _chargeTrickPoint.Switch = false;//�`���[�W���Ȃ��悤�ɂ���
        _playerInput.SwitchCurrentActionMap("Defeat");//����̕ύX
        _timeLimit.Switch = false;//�������Ԃ��~�߂�
        _algorithmOfEnemy.Switch = false;//�G�̍s�����~�߂�
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
