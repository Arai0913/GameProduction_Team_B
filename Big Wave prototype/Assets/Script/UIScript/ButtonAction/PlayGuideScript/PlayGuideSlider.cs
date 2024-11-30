using UnityEngine;

//�쐬�ҁG�K��

public class PlayGuideSlider : MonoBehaviour
{
    [SerializeField] RectTransform playGuideGroup;//�X���C�h���������摜�̃O���[�v
    [SerializeField] float slideSpeed = 5f;//�X���C�h���x

    private Vector2 offScreenPosition;//��ʊO�ҋ@�ʒu
    private Vector2 onScreenPosition;//��ʓ��摜�\���ʒu
    private bool isSliding = false;//�X���C�h���Ă��邩
    private bool isDisplay = false;//�\�����Ă��邩
    private bool startSlidingIn = false;//�X���C�h�C�����Ă��邩
    private bool startSlidingOut = false;//�X���C�h�A�E�g���Ă��邩

    public bool CompletedSlideOut { get; set; } = false;//�X���C�h�A�E�g������������

    public bool IsSliding
    {
        get { return isSliding; }
    }

    public bool IsDisplay
    {
        get { return isDisplay; }
    }

    private void Start()
    {
        offScreenPosition = new Vector2(0, Screen.height);//��ʊO�ҋ@�ʒu�̐ݒ�
        onScreenPosition = playGuideGroup.anchoredPosition;//��ʓ��\���ʒu�̐ݒ�
        playGuideGroup.anchoredPosition = offScreenPosition;//�����ʒu�̐ݒ�
    }

    private void Update()
    {
        if (!IsSliding) return;//�X���C�h���Ă��Ȃ��Ȃ牽�����Ȃ�

        Vector2 targetPosition = startSlidingIn ? onScreenPosition : offScreenPosition;//�X���C�h�����ɉ������ڕW�ʒu�̐ݒ�
        playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);

        if (Vector2.Distance(playGuideGroup.anchoredPosition, targetPosition) < 0.1f)//�ڕW�̈ʒu�ƌ��݈ʒu�̍������l�ȉ��Ȃ�
        {
            CompleteSlide();//�X���C�h�������̏���
        }
    }

    public void SlideIn()
    {
        if (!IsDisplay)//�摜���\������Ă��Ȃ��Ȃ�
        {
            startSlidingIn = true;//�X���C�h�C�����Ă���
            isSliding = true;//�摜���X���C�h���Ă���
        }
    }

    public void SlideOut()
    {
        if (IsDisplay)//�摜���\������Ă���Ȃ�
        {
            startSlidingOut = true;//�X���C�h�A�E�g���Ă���
            isSliding = true;//�摜���X���C�h���Ă���
        }
    }

    private void CompleteSlide()//�摜�̃X���C�h�������̏���
    {
        isSliding = false;//�X���C�h���Ă��Ȃ�
        playGuideGroup.anchoredPosition = startSlidingIn ? onScreenPosition : offScreenPosition;

        if (startSlidingIn)//�X���C�h�C�����̏���
        {
            startSlidingIn = false;//�X���C�h�C�����Ă��Ȃ�
            isDisplay = true;//�摜��\�����Ă���
        }

        else if (startSlidingOut)//�X���C�h�A�E�g���̏���
        {
            startSlidingOut = false;//�X���C�h�A�E�g���Ă��Ȃ�
            isDisplay = false;//�摜��\�����Ă��Ȃ�
            CompletedSlideOut = true;//�X���C�h�A�E�g����������
        }
    }
}
