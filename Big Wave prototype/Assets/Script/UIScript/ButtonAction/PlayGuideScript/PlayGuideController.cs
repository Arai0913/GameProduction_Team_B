using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁF�K��

public class PlayGuideController : MonoBehaviour
{
    [SerializeField] MenuEffectController effectControllerObject;
    [SerializeField] PlayGuideInputHandler playGuideInputHandlerObject;
    [SerializeField] TransitionPages transitionPagesObject;
    [SerializeField] PlayGuideSlider playGuideSlider;
    [SerializeField] List<Image> playGuideImages;

    private MenuEffectController effectController;
    private PlayGuideInputHandler playGuideInputHandler;
    private TransitionPages transitionPages;
    private int currentIndex = 0;
    private bool isOpenGuide = false;

    private void Start()
    {
        effectController = effectControllerObject.GetComponent<MenuEffectController>();
        playGuideInputHandler = playGuideInputHandlerObject.GetComponent<PlayGuideInputHandler>();
        transitionPages = transitionPagesObject.GetComponent<TransitionPages>();

        transitionPages.SetImages(playGuideImages, currentIndex);
    }

    private void Update()
    {
        //��ʂ��X���C�h���Ă��Ȃ��A�\������Ă��Ȃ��Ȃ�
        if (!playGuideSlider.IsSliding && !playGuideSlider.IsDisplay)
            playGuideInputHandler.EnableAllUIActions();//�S�Ă̑����L����

        if (isOpenGuide)
        {
            playGuideInputHandler.DisableAllUIActions();//�S�Ă̑���𖳌���
            if (effectController.EffectColorChanged)
            {
                OpenGuide();

                if (!playGuideSlider.IsSliding && playGuideSlider.IsDisplay)
                {
                    playGuideInputHandler.EnableSpecificUIActions();
                }//�����L���ɂ���A�G�t�F�N�g�̏����������E�E�E�X���C�h�A�E�g������҂��Ă���                
            }
        }

        else
        {
            playGuideInputHandler.DisableSpecificUIActions();//�ꕔ�̑���𖳌���
            if (playGuideSlider.CompletedSlideOut)//�摜�̃X���C�h���������Ă�����
            {
                transitionPages.HideImage(currentIndex);
                effectController.ResetButtonEffects();
                playGuideSlider.CompletedSlideOut = false;
            }
        }
    }

    public void OpenGuide()//�K�C�h�̕\������
    {
        if (!playGuideSlider.IsDisplay)
        {
            transitionPages.ShowImage(currentIndex);
            playGuideSlider.SlideIn();
        }
    }

    public void CloseGuide()//�K�C�h�̊i�[����
    {
        if (playGuideSlider.IsDisplay)
        {
            playGuideSlider.SlideOut();
            isOpenGuide = false;
        }
    }

    public void PlayGuideButtonClicked()//playGuideButton�{�^�����������Ƃ��̏���
    {
        if (!playGuideSlider.IsSliding && !playGuideSlider.IsDisplay)
        {
            isOpenGuide = true;
        }
    }
}
