using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�Q�[���N���A���o(�V�[���J�ڂ��܂߂�)
public class GameClearEffect : MonoBehaviour
{
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _controller;

    public void Trigger()//���o�J�n
    {
        _controller.ClearScene();//�N���A�V�[���Ɉڍs����
    }
}
