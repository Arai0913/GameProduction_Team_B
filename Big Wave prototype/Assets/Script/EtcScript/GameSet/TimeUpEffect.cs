using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�^�C���A�b�v���̉��o(�V�[���J�ڂ��܂߂�)
public class TimeUpEffect : MonoBehaviour
{
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;

    public void Trigger()//���o�J�n
    {
        _controller.GameOverScene();//�Q�[���I�[�o�[�V�[���Ɉڍs����
    }
}
