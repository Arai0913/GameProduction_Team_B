using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���J�ڂ̃��\�b�h���Ă�(�V�[�������ς�������̕ύX�̃R�X�g�����炷����)
public class SceneController : MonoBehaviour
{
    [Header("�Q�[���V�[���Ɉڍs����̂ɕK�v�ȃI�u�W�F�N�g")]
    [Tooltip("�Q�[���V�[���Ɉڍs���Ȃ��ꍇ�͓���Ȃ��Ă����Ȃ�")]
    [SerializeField] GameSceneName _gameSceneName;

    public void MenuScene()//���j���[��ʂɈڍs
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ClearScene()//�N���A�V�[���Ɉڍs
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void GameOverScene()//�Q�[���I�[�o�[�V�[���Ɉڍs
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void GameScene_1()//�Q�[���V�[��1�ֈړ�
    {
        _gameSceneName.NextGameScene = "SampleScene";
        SceneManager.LoadScene("ToMainLoadScene");//��x���[�h���(ToMainLoadScene)���o�R������
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
