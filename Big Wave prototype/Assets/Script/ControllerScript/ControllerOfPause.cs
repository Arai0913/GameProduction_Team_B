using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�|�[�Y(���)�̑���
public class ControllerOfPause : MonoBehaviour
{
    JudgePauseNow judgePauseNow;

    private void Start()
    {
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // P�L�[�������ꂽ��
        //{
        //    judgePauseNow.SwitchPause();// �|�[�Y�̐؂�ւ�
        //}
    }

    public void SwitchPause(InputAction.CallbackContext context)//�|�[�Y��Ԃɂ���
    {
        if (!context.performed) return;

        judgePauseNow.SwitchPause();// �|�[�Y�̐؂�ւ�
    }
}
