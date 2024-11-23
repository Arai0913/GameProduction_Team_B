using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [Header("�Q�[�����f���ɌĂԃC�x���g")]
    [SerializeField] UnityEvent quitEvents;
    [Header("�V�[���ڍs�R���|�[�l���g")]
    [SerializeField] SceneController _sceneController;

    public void Quit()//�Q�[�����f���̏���
    {
        quitEvents.Invoke();
        _sceneController.MenuScene();//���j���[�V�[���Ɉڍs
    }
}
