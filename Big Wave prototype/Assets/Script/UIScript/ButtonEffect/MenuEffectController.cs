using UnityEngine;
using UnityEngine.UI;

//�쐬�ҁF�K��

public class MenuEffectController : MonoBehaviour
{
    [Header("�����W�v�Z�̂��Ƃɂ���I�u�W�F�N�g")]
    [SerializeField] RectTransform menuPanel;
    [Header("���{�^���I�����ɐ��������G�t�F�N�g")]
    [SerializeField] GameObject selectedEffectPrefab;
    [Header("���{�^�����莞�ɐ��������G�t�F�N�g")]
    [SerializeField] GameObject clickedEffectPrefab;
    [Header("�t�F�[�h�A�E�g�̐ݒ�")]
    [SerializeField] FadeOut fadeOut;

    private TriangleWaveLine triangleWaveLine;

    private GameObject leftSelectedEffect;//�����ɐ��������{�^���I�����̃G�t�F�N�g
    private GameObject rightSelectedEffect;//�E���ɐ��������{�^���I�����̃G�t�F�N�g
    private GameObject leftClickedEffect;//�����ɐ��������{�^�����莞�̃G�t�F�N�g
    private GameObject rightClickedEffect;//�E���ɐ��������{�^�����莞�̃G�t�F�N�g

    private Image currentButtonImage;

    private float setSizeOffset = 5f;//���W�v�Z�̕␳�p
    private float aspectRatio = 0.75f;//�G�t�F�N�g�̉����ɑ΂��鍂���̔{��

    private bool clickedEffectGenerated = false;//���肳�ꂽ���ǂ���
    private bool effectColorChanged = false;

    public bool EffectColorChanged
    {
        get { return effectColorChanged; }
    }

    public bool EffectColorChange_FadeOutWasCompleted
    {
        get { return effectColorChanged && fadeOut.FadeCompleted; }
    }

    private void Start()
    {
        clickedEffectGenerated = false;
    }

    void Update()
    {
        if (triangleWaveLine == null && leftClickedEffect != null)
        {
            //���莞�̃G�t�F�N�g�̃R���|�[�l���g���擾
            triangleWaveLine = leftClickedEffect.GetComponent<TriangleWaveLine>();
        }

        if (clickedEffectGenerated)
        {
            if (triangleWaveLine.EffectCompleted)//����p�̃G�t�F�N�g�����ׂĕ\�����ꂽ��
            {
                if (currentButtonImage != null)
                {
                    currentButtonImage.color = new Color(1.0f, 0.64f, 0.0f, 1.0f);//�{�^���̐F���I�����W�F�ɂ���
                    effectColorChanged = true;
                }

                if (effectColorChanged)
                {
                    fadeOut.FadeOutTrigger();//��ʂ̈Ó]�������J�n
                }
            }
        }
    }

    public void ButtonSelectedProcess(RectTransform buttonRect)//�e�{�^�����I�����ꂽ�Ƃ��̏���
    {
        if (buttonRect != null)
        {
            DestroyEffects(ref leftSelectedEffect, ref rightSelectedEffect);
            GenerateEffects(buttonRect, selectedEffectPrefab, ref leftSelectedEffect, ref rightSelectedEffect);
        }
    }

    public void ButtonDeselectedProcess(RectTransform buttonRect)//�e�{�^������I�����O���ꂽ�Ƃ��̏���
    {
        if (buttonRect != null)
        {
            DestroyEffects(ref leftSelectedEffect, ref rightSelectedEffect);//�I���G�t�F�N�g�̍폜
        }
    }

    public void ButtonClickedProcess(RectTransform buttonRect)//�{�^�����N���b�N���ꂽ�Ƃ��̏���
    {
        DestroyEffects(ref leftClickedEffect, ref rightClickedEffect);//����G�t�F�N�g�̍폜
        GenerateEffects(buttonRect, clickedEffectPrefab, ref leftClickedEffect, ref rightClickedEffect);
        clickedEffectGenerated = true;//���莞�̃G�t�F�N�g���������ꂽ
        currentButtonImage = buttonRect.GetComponent<Image>();
    }

    //�G�t�F�N�g�̐���
    public void GenerateEffects(RectTransform buttonRect, GameObject effectPrefab, ref GameObject leftEffect, ref GameObject rightEffect)
    {
        float scaledPanelWidth = CalculateScaledWidth(menuPanel);
        float panelHalfWidth = scaledPanelWidth * 0.5f;

        float scaledButtonWidth = CalculateScaledWidth(buttonRect);
        float buttonHalfWidth = scaledButtonWidth * 0.5f;

        float buttonCenterY = buttonRect.anchoredPosition.y;//�{�^���̒����̃A���J�[Y���W

        Image buttonImage = buttonRect.GetComponent<Image>();
        Color buttonColor = buttonImage.color;//�Ώۂ̃{�^���̐F���擾

        leftEffect = Instantiate(effectPrefab, menuPanel);//�����G�t�F�N�g�̐���
        RectTransform leftEffectRect = leftEffect.GetComponent<RectTransform>();

        SetColorOfEffect(leftEffect, effectPrefab, buttonColor);//�����G�t�F�N�g�̐F��ݒ�

        float effectRectWidth = ((panelHalfWidth - buttonHalfWidth) + setSizeOffset) / menuPanel.localScale.x;//�G�t�F�N�g�̉������p�l���[����{�^���[�܂ł̕��ɐݒ�
        float effectRectHeight = effectRectWidth * aspectRatio;//�擾�������ɉ������G�t�F�N�g�̍�����ݒ�

        leftEffectRect.sizeDelta = new Vector2(effectRectWidth + buttonRect.anchoredPosition.x, effectRectHeight);//�p�l���̃X�P�[�����l�����ĕ���ݒ�

        float effectWidth = leftEffectRect.rect.width * 0.5f * menuPanel.localScale.x;//�X�P�[�����l�����ăG�t�F�N�g�̔����̕����擾

        float leftEffectX = (-panelHalfWidth + effectWidth) / menuPanel.localScale.x;//�p�l�����[�ɍ��킹�����G�t�F�N�g��X���W
        leftEffectRect.anchoredPosition = new Vector2(leftEffectX, buttonCenterY);//�X�P�[���␳���ăG�t�F�N�g��z�u

        rightEffect = Instantiate(effectPrefab, menuPanel);//�E���G�t�F�N�g�̐���
        RectTransform rightEffectRect = rightEffect.GetComponent<RectTransform>();

        SetColorOfEffect(rightEffect, effectPrefab, buttonColor);//�E���G�t�F�N�g�̐F��ݒ�

        rightEffectRect.sizeDelta = new Vector2(effectRectWidth - buttonRect.anchoredPosition.x, effectRectHeight);//�X�P�[�����l�����ĉE�G�t�F�N�g�̃T�C�Y��ݒ�

        float rightEffectX = (panelHalfWidth - effectWidth + buttonRect.anchoredPosition.x) / menuPanel.localScale.x;//�p�l���E�[�ɍ��킹���E�G�t�F�N�g��X���W
        rightEffectRect.anchoredPosition = new Vector2(rightEffectX, buttonCenterY);//�X�P�[���␳���ĉE�G�t�F�N�g��z�u
        rightEffectRect.localRotation = Quaternion.Euler(0, 180, 0);//�E�G�t�F�N�g�𔽓]
    }


    //�G�t�F�N�g�̔j��
    public void DestroyEffects(ref GameObject leftEffect, ref GameObject rightEffect)
    {
        if (leftEffect != null)
        {
            DestroyImmediate(leftEffect);
            leftEffect = null;
        }

        if (rightEffect != null)
        {
            DestroyImmediate(rightEffect);
            rightEffect = null;
        }
    }

    //�G�t�F�N�g�̐F�̐ݒ�
    private void SetColorOfEffect(GameObject effect, GameObject effectPrefab, Color buttonColor)
    {
        if (effectPrefab == selectedEffectPrefab)
        {
            Image effectImage = effect.GetComponent<Image>();
            effectImage.color = buttonColor;
        }
    }

    //�X�P�[���Ɋ�Â������̎擾
    private float CalculateScaledWidth(RectTransform rectTransform)
    {
        float width = rectTransform.rect.width;
        float scaleX = rectTransform.localScale.x;
        return width * scaleX;
    }
}
