using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�|�[�Y(���)�̑���
public class ControllerOfPause : MonoBehaviour
{
    [Header("�|�[�Y���")]
    [SerializeField] PauseControl pauseControl;//�|�[�Y���

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // P�L�[�������ꂽ��
        {
            pauseControl.TogglePause(); // �|�[�Y�̐؂�ւ�
        }
    }
}
