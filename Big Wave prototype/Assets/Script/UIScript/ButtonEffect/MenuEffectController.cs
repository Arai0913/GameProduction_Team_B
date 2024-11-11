using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//作成者：桑原

public class MenuEffectController : MonoBehaviour
{
    [Header("▼座標計算のもとにするオブジェクト")]
    [SerializeField] RectTransform menuPanel;
    [Header("▼ボタン選択時に生成されるエフェクト")]
    [SerializeField] GameObject selectedEffectPrefab;
    [Header("▼ボタン決定時に生成されるエフェクト")]
    [SerializeField] GameObject clickedEffectPrefab;
    [Header("▼ボタン決定時に生成されるエフェクトの色")]
    [SerializeField] Color clickedEffectColor;
    [Header("フェードアウトの設定")]
    [SerializeField] FadeOut fadeOut;

    private TriangleWaveLine triangleWaveLine;

    private GameObject leftSelectedEffect;//左側に生成されるボタン選択時のエフェクト
    private GameObject rightSelectedEffect;//右側に生成されるボタン選択時のエフェクト
    private GameObject leftClickedEffect;//左側に生成されるボタン決定時のエフェクト
    private GameObject rightClickedEffect;//右側に生成されるボタン決定時のエフェクト

    private Color originalButtonColor;
    private Image currentButtonImage;
    private RectTransform currentButtonRect;

    private float setSizeOffset = 5f;//座標計算の補正用
    private float aspectRatio = 0.75f;//エフェクトの横幅に対する高さの倍率

    private bool clickedEffectGenerated = false;//決定されたかどうか
    private bool effectColorChanged = false;//エフェクトの色が変化したか

    public bool ClickedEffectGenerated
    {
        get { return clickedEffectGenerated; }
    }

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

        SetColorOfClickedEffect(clickedEffectPrefab);
    }

    void Update()
    {
        if (triangleWaveLine == null && leftClickedEffect != null)
        {
            //決定時のエフェクトのコンポーネントを取得
            triangleWaveLine = leftClickedEffect.GetComponent<TriangleWaveLine>();
        }

        if (clickedEffectGenerated)
        {
            if (triangleWaveLine.EffectCompleted)//決定用のエフェクトがすべて表示されたら
            {
                if (currentButtonImage != null)
                {
                    currentButtonImage.color = clickedEffectColor;//ボタンの色を決定時エフェクトの色に変更する
                    effectColorChanged = true;
                }
            }
        }
    }

    public void ButtonSelectedProcess(RectTransform buttonRect)//各ボタンが選択されたときの処理
    {
        if (buttonRect != null)
        {
            currentButtonRect = buttonRect;
            currentButtonImage = buttonRect.GetComponent<Image>();
            originalButtonColor = currentButtonImage.color;
            DestroyEffects(ref leftSelectedEffect, ref rightSelectedEffect);
            GenerateEffects(buttonRect, selectedEffectPrefab, ref leftSelectedEffect, ref rightSelectedEffect);
        }
    }

    public void ButtonDeselectedProcess(RectTransform buttonRect)//各ボタンから選択が外されたときの処理
    {
        if (buttonRect != null)
        {
            DestroyEffects(ref leftSelectedEffect, ref rightSelectedEffect);//選択エフェクトの削除
        }
    }

    public void ButtonClickedProcess(RectTransform buttonRect)//ボタンがクリックされたときの処理
    {
        GenerateEffects(buttonRect, clickedEffectPrefab, ref leftClickedEffect, ref rightClickedEffect);
        clickedEffectGenerated = true;//決定時のエフェクトが生成された
        currentButtonImage = buttonRect.GetComponent<Image>();
    }

    //エフェクトの生成
    public void GenerateEffects(RectTransform buttonRect, GameObject effectPrefab, ref GameObject leftEffect, ref GameObject rightEffect)
    {
        float scaledPanelWidth = CalculateScaledWidth(menuPanel);
        float panelHalfWidth = scaledPanelWidth * 0.5f;

        float scaledButtonWidth = CalculateScaledWidth(buttonRect);
        float buttonHalfWidth = scaledButtonWidth * 0.5f;

        float buttonCenterY = buttonRect.anchoredPosition.y;//ボタンの中央のアンカーY座標

        Image buttonImage = buttonRect.GetComponent<Image>();
        Color buttonColor = buttonImage.color;//対象のボタンの色を取得

        leftEffect = Instantiate(effectPrefab, menuPanel);//左側エフェクトの生成
        RectTransform leftEffectRect = leftEffect.GetComponent<RectTransform>();

        SetColorOfSelectedEffect(leftEffect, effectPrefab, buttonColor);//左側エフェクトの色を設定

        float effectRectWidth = ((panelHalfWidth - buttonHalfWidth) + setSizeOffset) / menuPanel.localScale.x;//エフェクトの横幅をパネル端からボタン端までの幅に設定
        float effectRectHeight = effectRectWidth * aspectRatio;//取得した幅に応じたエフェクトの高さを設定

        leftEffectRect.sizeDelta = new Vector2(effectRectWidth + buttonRect.anchoredPosition.x, effectRectHeight);//パネルのスケールを考慮して幅を設定

        float effectWidth = leftEffectRect.rect.width * 0.5f * menuPanel.localScale.x;//スケールを考慮してエフェクトの半分の幅を取得

        float leftEffectX = (-panelHalfWidth + effectWidth) / menuPanel.localScale.x;//パネル左端に合わせた左エフェクトのX座標
        leftEffectRect.anchoredPosition = new Vector2(leftEffectX, buttonCenterY);//スケール補正してエフェクトを配置

        rightEffect = Instantiate(effectPrefab, menuPanel);//右側エフェクトの生成
        RectTransform rightEffectRect = rightEffect.GetComponent<RectTransform>();

        SetColorOfSelectedEffect(rightEffect, effectPrefab, buttonColor);//右側エフェクトの色を設定

        rightEffectRect.sizeDelta = new Vector2(effectRectWidth - buttonRect.anchoredPosition.x, effectRectHeight);//スケールを考慮して右エフェクトのサイズを設定

        float rightEffectX = (panelHalfWidth - effectWidth + buttonRect.anchoredPosition.x) / menuPanel.localScale.x;//パネル右端に合わせた右エフェクトのX座標
        rightEffectRect.anchoredPosition = new Vector2(rightEffectX, buttonCenterY);//スケール補正して右エフェクトを配置
        rightEffectRect.localRotation = Quaternion.Euler(0, 180, 0);//右エフェクトを反転
    }


    //エフェクトの破棄
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

    //決定時のエフェクトの破棄
    public void DestroyClickedEffect()
    {
        if (leftClickedEffect != null && rightClickedEffect != null)
        {
            DestroyImmediate(leftClickedEffect);
            leftClickedEffect = null;

            DestroyImmediate(rightClickedEffect);
            rightClickedEffect = null;
        }
    }

    //エフェクトの色の設定
    private void SetColorOfSelectedEffect(GameObject effect, GameObject effectPrefab, Color buttonColor)
    {
        if (effectPrefab == selectedEffectPrefab)
        {
            Image effectImage = effect.GetComponent<Image>();
            effectImage.color = buttonColor;
        }
    }

    //決定時のエフェクトの色の設定
    private void SetColorOfClickedEffect(GameObject effectPrefab)
    {
        if (effectPrefab == clickedEffectPrefab)
        {
            Image effectImage = effectPrefab.GetComponent<Image>();
            effectImage.color = clickedEffectColor;
        }
    }

    //スケールに基づく横幅の取得
    private float CalculateScaledWidth(RectTransform rectTransform)
    {
        float width = rectTransform.rect.width;
        float scaleX = rectTransform.localScale.x;
        return width * scaleX;
    }

    public void ResetButtonClickEffect()//ボタン決定時のエフェクト削除・選択時エフェクトの再設定
    {
        DestroyClickedEffect();

        clickedEffectGenerated = false;
        effectColorChanged = false;

        if (currentButtonImage != null)
        {
            currentButtonImage.color = originalButtonColor;
        }

        ButtonSelectedProcess(currentButtonRect);
    }
}
