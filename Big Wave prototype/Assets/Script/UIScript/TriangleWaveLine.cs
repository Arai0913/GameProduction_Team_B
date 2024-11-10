using UnityEngine;
using UnityEngine.UI;

public class TriangleWaveLine : MonoBehaviour
{
    [SerializeField] Image electricImage;  // �d���G�t�F�N�g�̃C���[�W
    [SerializeField] float speed = 1.0f;   // �G�t�F�N�g�̐i�s���x
    [SerializeField] bool isStop = true;

    private bool effectCompleted;

    public bool EffectCompleted
    {
        get { return effectCompleted; }
    }

    void Start()
    {
        electricImage.fillAmount = 0.0f;
        effectCompleted = false;
    }

    void Update()
    {
        // Fill Amount�����Ԃɉ����Ē���
        electricImage.fillAmount += speed * Time.deltaTime;

        // Fill Amount��1�ɂȂ�����0�ɖ߂�
        if (electricImage.fillAmount >= 1.0f)
        {
            if (isStop)
            {
                electricImage.fillAmount = 1.0f;
                effectCompleted = true;
            }

            else
            {
                electricImage.fillAmount = 0.0f;
            }
        }
    }
}
