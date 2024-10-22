using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class CustomButtonEventsManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [Header("���V�[����J�ڂ���{�^��")]
    [SerializeField] GameObject sceneMoveButton;

    private SceneControlManager sceneControlManager;
    private MenuEffectController menuEffectController;
    private RectTransform currentSelectedButton;
    private RectTransform currentClickedButton;

    void Start()
    {
        sceneControlManager = sceneMoveButton.GetComponent<SceneControlManager>();
        menuEffectController = canvas.GetComponent<MenuEffectController>();
    }

    void Update()
    {
        ButtonsProcess();//�e�{�^���̏���
    }

    //�{�^���I�����̏���
    public void OnButtonSelected(RectTransform buttonRect)
    {
        if (currentSelectedButton != buttonRect)
        {
            menuEffectController.ButtonSelectedProcess(buttonRect);
            currentSelectedButton = buttonRect;
        }
    }

    //�{�^���̑I���������̏���
    public void OnButtonDeselected(RectTransform buttonRect)
    {
        if (currentSelectedButton != null)
        {
            menuEffectController.ButtonDeselectedProcess(buttonRect);
            currentSelectedButton = null;
        }
    }

    //�{�^���̃N���b�N���̏���
    public void OnButtonClicked(RectTransform buttonRect)
    {
        menuEffectController.ButtonClickedProcess(buttonRect);
        currentClickedButton = buttonRect;
    }

    //�e�{�^���̏���
    private void ButtonsProcess()
    {
        if (currentClickedButton == null)
        {
            return;
        }

        switch (currentClickedButton.gameObject.tag)
        {
            case "StartButton":
                if (menuEffectController.EffectColorChange_FadeOutWasCompleted)//�{�^���̐F�̕ω��Ɖ�ʂ̈Ó]���I�����Ă�����
                {
                    sceneControlManager.ChangeGameScene();//���[�h��ʂւ̈ڍs�������Ăяo��
                }
                break;

            case "EndButton":
                if (menuEffectController.EffectColorChanged)//�{�^���̐F�̕ω����I�����Ă�����
                {
                    sceneControlManager.EndGame();//�Q�[���̏I���������Ăт���
                }
                break;

            case "RetryButton":
                if (menuEffectController.EffectColorChanged)//�{�^���̐F�̕ω����I�����Ă�����
                {
                    sceneControlManager.ChangeGameScene();//�Q�[���̏I���������Ăт���
                }
                break;

            case "QuitButton":
                if (menuEffectController.EffectColorChanged)//�{�^���̐F�̕ω����I�����Ă�����
                {
                    sceneControlManager.ChangeMenuScene();//�Q�[���̏I���������Ăт���
                }
                break;

            case null:
                break;

        }
    }
}
