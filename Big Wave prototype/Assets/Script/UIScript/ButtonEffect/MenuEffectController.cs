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

    //[Header("���t�F�[�h�A�E�g�Ɏg���摜")]
    //[SerializeField] Image fadeImage;
    /*[Header("���Q�[�����J�n����{�^��")]
    [SerializeField] GameObject startGameButton;
    [Header("���Q�[�����I������{�^��")]
    //[SerializeField] GameObject endGameButton;*/
    //[Header("�����S�ɉ�ʂ��t�F�[�h�A�E�g����܂łɂ����鎞��")]
    //[SerializeField] float fadeDuration = 1.0f;


    private TriangleWaveLine triangleWaveLine;

    private GameObject leftSelectedEffect;//�����ɐ��������{�^���I�����̃G�t�F�N�g
    private GameObject rightSelectedEffect;//�E���ɐ��������{�^���I�����̃G�t�F�N�g
    private GameObject leftClickedEffect;//�����ɐ��������{�^�����莞�̃G�t�F�N�g
    private GameObject rightClickedEffect;//�E���ɐ��������{�^�����莞�̃G�t�F�N�g

    private Image currentButtonImage;

    private float setPositionOffset = 2.5f;//���W�v�Z�̕␳�p
    //private float fadeTimer = 0f;//�t�F�[�h�A�E�g���Ԃ̊Ǘ��p
    //private bool fadeCompleted;
    private bool clickedEffectGenerated = false;//���肳�ꂽ���ǂ���
    private bool effectColorChanged = false;

    //public bool FadeCompleted
    //{
    //    get { return fadeCompleted; }
    //}

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
        //fadeImage.color = new Color(0, 0, 0, 0);//�t�F�[�h�A�E�g�p�̉摜�𓧖��ɐݒ�

        //fadeCompleted = false;

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
        float panelWidth = menuPanel.rect.width;//�p�l���̉���
        float panelLeftX = -panelWidth * 0.5f;//�p�l���̍��[
        float panelRightX = panelWidth * 0.5f;//�p�l���̉E�[

        //float buttonWidth = buttonRect.rect.width;//�{�^���̕�

        float buttonCenterY = buttonRect.anchoredPosition.y;//�{�^���̒����̃A���J�[Y���W���擾
                
        leftEffect = Instantiate(effectPrefab, menuPanel);//�����̃G�t�F�N�g�𐶐�
        RectTransform leftEffectRect = leftEffect.GetComponent<RectTransform>();
                
        float effectWidth = leftEffectRect.rect.width;//�G�t�F�N�g�̕��̔������擾

        float leftEffectX = panelLeftX + effectWidth * setPositionOffset;//���G�t�F�N�g�̍��W���p�l���̍��[�̍��W�ɍ��킹��
        leftEffectRect.anchoredPosition = new Vector2(leftEffectX, buttonCenterY);//�v�Z�������W�ɔz�u

        rightEffect = Instantiate(effectPrefab, menuPanel);//�E���̃G�t�F�N�g�𐶐�
        RectTransform rightEffectRect = rightEffect.GetComponent<RectTransform>();

        float rightEffectX = panelRightX - effectWidth * setPositionOffset;//�E�G�t�F�N�g�̍��W���p�l���̉E�[�̍��W�ɍ��킹��
        rightEffectRect.anchoredPosition = new Vector2(rightEffectX, buttonCenterY);//�v�Z�������W�ɔz�u
        rightEffectRect.localRotation = Quaternion.Euler(0, 180, 0);//�E���̃G�t�F�N�g����]������
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

    ////��ʂ̈Ó]
    //private void FadeOutDisplay()
    //{
    //    fadeTimer += Time.deltaTime;
    //    float normalizedTime = fadeTimer / fadeDuration;
    //    float newAlpha = Mathf.Clamp01(normalizedTime);//�o�ߎ��Ԃ����Ƃɓ����x���v�Z
    //    fadeImage.color = new Color(0, 0, 0, newAlpha);//�t�F�[�h�A�E�g�p�̉摜�̓����x���X�V

    //    if (fadeTimer >= fadeDuration)
    //    {
    //        fadeCompleted = true;//���S�ɉ�ʂ��Ó]����
    //    }
    //}
}
