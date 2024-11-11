using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁF�K��

public class PlayGuideButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject menuEffect;
    [Header("�����䂵����InputSystem")]
    [SerializeField] GameObject inputModule;

    [Header("���\�����������摜�̃O���[�v")]
    [SerializeField] RectTransform playGuideGroup;
    [Header("���\�����������摜")]
    [SerializeField] List<Image> playGuideImages;
    [Header("���ŏ��ɕ\�����������摜")]
    [SerializeField] Image displayImage;
    [Header("���摜���X���C�h�����鑬��")]
    [SerializeField] float slideSpeed = 5f;

    private MenuEffectController menuEffectController;
    private PlayGuideInputModule playGuideInputModule;

    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;

    private int currentIndex = 0;
    private float currentSpeed;

    private bool isSliding = false;
    private bool isSlidingIn = false;
    private bool isSlidingOut = false;
    private bool isImageDisplayed = false;
    private bool isPlayGuideButtonClicked = false;

    private void Start()
    {
        menuEffectController = menuEffect.GetComponent<MenuEffectController>();
        playGuideInputModule = inputModule.GetComponent<PlayGuideInputModule>();

        playGuideGroup.gameObject.SetActive(true);

        onScreenPosition = playGuideGroup.anchoredPosition;//�摜�\�����̍��W��ݒ�
        offScreenPosition = new Vector2(0, Screen.height);//�摜���[���̈ʒu���W��ݒ�

        playGuideGroup.anchoredPosition = offScreenPosition;//�����ʒu����ʊO�ɐݒ�

        foreach (var image in playGuideImages)//�S�Ẳ摜���\���ɂ���
        {
            image.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isPlayGuideButtonClicked) return;

        if (menuEffectController.ClickedEffectGenerated)//���莞�̃G�t�F�N�g����������I������
        {
            playGuideInputModule.DisableAllUIActions();//�S�Ă̓��͂𖳌���

            if (menuEffectController.EffectColorChanged)
            {
                if (isSlidingIn || isSlidingOut)
                {
                    isSliding = true;
                    playGuideInputModule.DisableAllUIActions();
                    SlidingPlayGuide();
                }

                if (isImageDisplayed)
                {
                    playGuideInputModule.EnableSpecificUIActions();
                }
            }
        }
    }

    private void ShowImage(int index)//�摜�̕\��
    {
        playGuideImages[index].gameObject.SetActive(true);
        isSlidingIn = true;
        currentSpeed = slideSpeed;
    }

    public void ShowNextImage()//���̉摜��\��
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex + 1) % playGuideImages.Count;
            ShowImage(currentIndex);//�摜�̕\��
        }
    }

    public void ShowPreviousImage()//�O�̉摜��\��
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex - 1 + playGuideImages.Count) % playGuideImages.Count;
            ShowImage(currentIndex);//�摜�̕\��
        }
    }

    public void CloseImage()//�摜�����܂�
    {
        if (!isSliding)
        {
            isSlidingOut = true;
            currentSpeed = slideSpeed;
        }
    }

    public void PlayGuideButtonClicked()//playGuideButton�������ꂽ�Ƃ��̏���
    {
        if (!isSliding)
        {
            ShowImage(currentIndex);//�摜�̕\��
            isPlayGuideButtonClicked = true;
        }
    }

    private void SlidingPlayGuide()//�摜�̃X���C�h�ړ�����
    {
        if (isSlidingIn)//��ʓ��ɃX���C�h������ꍇ
        {
            playGuideInputModule.DisableAllUIActions();//�S�Ă̓��͂𖳌���
            playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition, onScreenPosition, currentSpeed * Time.deltaTime);//�摜�̈ړ�

            if (Vector2.Distance(playGuideGroup.anchoredPosition, onScreenPosition) < 0.1f)//���݂̉摜�̍��W�Ɖ�ʓ��̐ݒ���W�Ƃ̋��������ȉ��ɂȂ�����
            {
                isSliding = false;
                isSlidingIn = false;
                isImageDisplayed = true;
                playGuideGroup.anchoredPosition = onScreenPosition;
                playGuideInputModule.EnableSpecificUIActions();//�ꕔ���͂�L����
            }
        }

        else if (isSlidingOut)//��ʊO�ɃX���C�h������ꍇ
        {
            playGuideInputModule.DisableAllUIActions();//���͂𖳌���
            playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition, offScreenPosition, currentSpeed * Time.deltaTime);//�摜�̈ړ�

            if (Vector2.Distance(playGuideGroup.anchoredPosition, offScreenPosition) < 0.1f)//���݂̉摜�̍��W�Ɖ�ʊO�̐ݒ���W�Ƃ̋��������ȉ��ɂȂ�����
            {
                playGuideImages[currentIndex].gameObject.SetActive(false);
                isPlayGuideButtonClicked = false;
                isSliding = false;                
                isSlidingOut = false;
                isImageDisplayed = false;

                playGuideGroup.anchoredPosition = offScreenPosition;
                menuEffectController.ResetButtonClickEffect();//�{�^���̃G�t�F�N�g���Đݒ�
                playGuideInputModule.EnableAllUIActions();//�S�Ă̓��͂�L����
            }
        }
    }
}