using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�t�B�[�o�[��Ԃ̌���
public class FeverMode : MonoBehaviour
{
    [Header("�t�B�[�o�[��Ԃ̃G�t�F�N�g")]
    [SerializeField] GameObject feverEffect;//�t�B�[�o�[��Ԃ̃G�t�F�N�g
    [Header("�t�B�[�o�[��Ԃ̌��ʎ���")]
    [SerializeField] float feverTime=20f;//�t�B�[�o�[��Ԃ̌��ʎ���
    private float remainingFeverTime = 0f;//�t�B�[�o�[��Ԃ̎c����ʎ���
    [Header("�t�B�[�o�[��Ԉڍs���ɋN�����C�x���g")]
    [SerializeField] UnityEvent feverEvent;//�t�B�[�o�[��Ԉڍs���ɋN�����C�x���g

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] FeverPoint player_FeverPoint;

    private bool feverNow=false;//���t�B�[�o�[��Ԃ�

    public bool FeverNow
    {
        get { return feverNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        feverEffect.SetActive(false);
        remainingFeverTime = 0f;
        feverNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFeverMode();//�t�B�[�o�[��ԂɈڍs

        UpdateFeverTime();//�t�B�[�o�[��Ԃ̎c�莞�Ԃ��Ǘ�

        FeverModeEffect();//�t�B�[�o�[��Ԃ̌��ʂ̏���
    }

    //�܂��t�B�[�o�[��ԂɂȂ��Ă��Ȃ����t�B�[�o�[�|�C���g�����^���ɂȂ�����t�B�[�o�[��ԂɈڍs
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint_ >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
            feverEvent.Invoke();
        }
    }

    //�t�B�[�o�[��Ԃ̎c�莞�Ԃ��X�V
    void UpdateFeverTime()
    {
        remainingFeverTime -= Time.deltaTime;

        if(remainingFeverTime<=0f)//�t�B�[�o�[��Ԃ̎c�莞�Ԃ�0�ɂȂ�����t�B�[�o�[��Ԃ�����
        {
            remainingFeverTime=0f;
            feverNow = false;
        }
    }

    //�t�B�[�o�[��Ԃ̌��ʂ̏���
    void FeverModeEffect()
    {
        //�t�B�[�o�[��Ԓ���...
        //�G�t�F�N�g���t��
        //�t�B�[�o�[�|�C���g�����Ԃ��ƂɌ����Ă���(�t�B�[�o�[��Ԃ̎c�莞�Ԃ�\���Ă���)
        if (feverNow)
        {
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint_ = player_FeverPoint.FeverPointMax * ratio;
        }

        feverEffect.SetActive(feverNow);//�t�B�[�o�[���G�t�F�N�g��\��
    }
}
