using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�v���C���[�����񂾂Ƃ��̉��o(�V�[���J�ڂ��܂߂�)
public class DeadEffect : MonoBehaviour
{
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;

    public void Trigger()//���o�J�n
    {
        _controller.GameOverScene();//�Q�[���I�[�o�[�V�[���Ɉڍs����
    }
}
