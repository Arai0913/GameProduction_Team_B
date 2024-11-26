using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�t�F�[�h�A�E�g����
public class FadeOut : MonoBehaviour
{
    [Header("�����S�ɉ�ʂ��t�F�[�h�A�E�g����܂łɂ����鎞��")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("���t�F�[�h�A�E�g�Ɏg���摜")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//�t�F�[�h�A�E�g���Ԃ̊Ǘ��p
    private bool fadeStart;//�t�F�[�h�A�E�g���J�n���ꂽ��
    private bool fadeCompleted;//�t�F�[�h�A�E�g���I�������

    public bool FadeStart
    {
        get { return fadeStart; }
    }

    public bool FadeCompleted
    {
        get { return fadeCompleted; }
    }

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0);//�t�F�[�h�A�E�g�p�̉摜�𓧖��ɐݒ�

        fadeStart = false;
        fadeCompleted = false;
    }

    void Update()
    {
        FadeOutDisplay();
    }

    public void FadeOutTrigger()//�t�F�[�h�A�E�g�J�n���������ɌĂ�
    {
        fadeStart = true;
    }

    private void FadeOutDisplay()//�t�F�[�h�A�E�g�̏���
    {
        if (!fadeStart) return;//�t�F�[�h�A�E�g���܂��n�܂��ĂȂ��Ȃ珈�������Ȃ�

        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = Mathf.Clamp01(normalizedTime);//�o�ߎ��Ԃ����Ƃɓ����x���v�Z
        fadeImage.color = new Color(0, 0, 0, newAlpha);//�t�F�[�h�A�E�g�p�̉摜�̓����x���X�V

        if (fadeTimer >= fadeDuration)
        {
            fadeCompleted = true;//���S�ɉ�ʂ��Ó]����
        }
    }
}
