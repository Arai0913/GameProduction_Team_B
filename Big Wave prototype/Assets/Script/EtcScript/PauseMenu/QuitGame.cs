using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [Header("�Q�[�����f���ɌĂԃC�x���g")]
    [SerializeField] UnityEvent quitEvents;

    public void Quit()//�Q�[�����f���̏���
    {
        quitEvents.Invoke();
        SceneManager.LoadScene("MenuScene");
    }
}
