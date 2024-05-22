using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeGameoverScene()//�Q�[���I�[�o�[��ʂɈڍs
    {
        SceneManager.LoadScene("GameoverScene");
    }

    void ChangeClearScene()//�N���A��ʂɈڍs
    {
        SceneManager.LoadScene("ClearScene");
    }

    void ChangeMenuScene()//���j���[��ʂɈڍs
    {
        SceneManager.LoadScene("MenuScene");
    }

    void ChangeGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
