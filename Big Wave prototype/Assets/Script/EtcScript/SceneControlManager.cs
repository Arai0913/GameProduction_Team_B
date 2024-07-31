using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    //������������
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMenuScene()//���j���[��ʂɈڍs
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndGame()//�Q�[�����I������
    {
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
      #else
        Application.Quit();
      #endif
    }
}
