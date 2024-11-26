using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬��:�K��
//�{�^���̃C�x���g
public class CustomButtonEvent : MonoBehaviour
{
    [Header("���t�F�[�h�A�E�g���邩�ǂ���")]
    [SerializeField] bool isFadeOut;
    [Header("�ǂ̃V�[���Ɉڍs���邩")]
    [SerializeField] SelectScene _selectScene=new SelectScene();//�V�[���ڍs�̃C���X�^���X
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isButtonClicked = false;

    private void Update()
    {
        if (!isButtonClicked) return;

        ButtonAction();
    }

    public void ButtonClicked()
    {
        isButtonClicked = true;
    }

    private void ButtonAction()
    {

        if (!menuEffectController.EffectColorChanged) return;//�{�^���̐F���ς��؂��Ă���

        if(isFadeOut&&!fadeOut.FadeStart) fadeOut.FadeOutTrigger();//�t�F�[�h�A�E�g����ꍇ�̓t�F�[�h�A�E�g������
        if (isFadeOut && !fadeOut.FadeCompleted) return;//�܂��A�t�F�[�h�A�E�g���I���̂�҂��Ă���V�[���ڍs������(�t�F�[�h�A�E�g���Ȃ��ꍇ�͂��̂܂܃V�[���ڍs)

        _selectScene.ChangeScene();
    }
}
