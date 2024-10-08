using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [Header("�Q�[�����X�^�[�g���ɌĂԃC�x���g")]
    [SerializeField] UnityEvent restartEvents;

    public void Restart()//�Q�[�����X�^�[�g���̏���
    {
        restartEvents.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
