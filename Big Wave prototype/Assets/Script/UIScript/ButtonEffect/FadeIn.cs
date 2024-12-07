using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�t�F�[�h�C��
public class FadeIn : MonoBehaviour
{
    [Header("�����S�ɉ�ʂ��t�F�[�h�A�E�g����܂łɂ����鎞��")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("���t�F�[�h�A�E�g�Ɏg���摜")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//�t�F�[�h�A�E�g���Ԃ̊Ǘ��p
    private bool fadeStart = false;//�t�F�[�h�A�E�g���J�n���ꂽ��
    private bool fadeCompleted = false;//�t�F�[�h�A�E�g���I�������
    const float _maxAlpha = 1;

    public bool FadeStart
    {
        get { return fadeStart; }
    }

    public bool FadeCompleted
    {
        get { return fadeCompleted; }
    }

    void Update()
    {
        FadeOutDisplay();
    }

    public void FadeOutTrigger()//�t�F�[�h�A�E�g�J�n���������ɌĂ�
    {
        fadeStart = true;
        fadeTimer = 0f;
        fadeCompleted = false;
    }

    private void FadeOutDisplay()//�t�F�[�h�A�E�g�̏���
    {
        if (!fadeStart || fadeCompleted) return;//�t�F�[�h�A�E�g���܂��n�܂��ĂȂ��������̓t�F�[�h�A�E�g�����������Ȃ�A���������Ȃ�

        //�o�ߎ��Ԃ����Ƃɓ����x���v�Z
        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = _maxAlpha - Mathf.Clamp01(normalizedTime);

        //�t�F�[�h�A�E�g�p�̉摜�̓����x���X�V
        Color currentColor = fadeImage.color;
        currentColor.a = newAlpha;
        fadeImage.color = currentColor;

        if (fadeTimer >= fadeDuration)
        {
            fadeCompleted = true;//���S�ɉ�ʂ��Ó]����
        }
    }
}
