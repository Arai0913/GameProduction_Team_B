using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�Q�[���I�[�o�[���o(�V�[���J�ڂ��܂߂�)
public class GameOverEffect : MonoBehaviour
{
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;

    public void Trigger()//���o�J�n
    {
        _controller.GameOverScene();//�Q�[���I�[�o�[�V�[���Ɉڍs����
    }
}
