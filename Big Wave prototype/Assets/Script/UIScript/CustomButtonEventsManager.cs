using UnityEngine;

//�쐬�ҁF�K��

public class CustomButtonEventsManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [Header("���Q�[�����J�n����{�^��")]
    [SerializeField] GameObject startGameButton;
    [Header("���Q�[�����I������{�^��")]
    [SerializeField] GameObject endGameButton;

    private SceneControlManager sceneControlManager;
    private MenuEffectController menuEffectController;
    private RectTransform currentSelectedButton;
    private RectTransform currentClickedButton;

    void Start()
    {
        sceneControlManager = startGameButton.GetComponent<SceneControlManager>();
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
        if (currentClickedButton == startGameButton.GetComponent<RectTransform>())//�Q�[�����J�n����{�^���������ꂽ��
        {
            if (menuEffectController.EffectColorChanged && menuEffectController.FadeCompleted)//�{�^���̐F�̕ω��Ɖ�ʂ̈Ó]���I�����Ă�����
            {
                sceneControlManager.ChangeGameScene();//���[�h��ʂւ̈ڍs�������Ăяo��
            }
        }     

        else if (currentClickedButton == endGameButton.GetComponent<RectTransform>())//�Q�[�����I������{�^���������ꂽ��
        {
            if (menuEffectController.EffectColorChanged)//�{�^���̐F�̕ω����I�����Ă�����
            {
                sceneControlManager.EndGame();//�Q�[���̏I���������Ăт���
            }
        }
    }
}
