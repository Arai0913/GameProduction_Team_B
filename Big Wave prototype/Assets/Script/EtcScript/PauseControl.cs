using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseControl : MonoBehaviour
{
    [Header("�|�[�Y���j���[��UI")]
    [SerializeField]  GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        isPaused = false;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // �|�[�Y���j���[���\���ɂ���
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)||Input.GetButtonDown("Pause")) // P�L�[�������ꂽ��
        {
            TogglePause(); // �|�[�Y�̐؂�ւ�
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused; // �|�[�Y��Ԃ𔽓]������
        Time.timeScale = isPaused ?0 : 1;// �Q�[���̎��Ԍo�߂𐧌䂷��
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused); // �|�[�Y���j���[��\���E��\���ɂ���
        }
    }

    public void ResumeGame()
    {
        TogglePause(); // �|�[�Y���������ăQ�[�����ĊJ����
    }

    public void RestartGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
