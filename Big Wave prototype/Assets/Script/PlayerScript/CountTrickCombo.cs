using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTrickCombo : MonoBehaviour
{
    [Header("���b�o������R���{�񐔂����Z�b�g���邩")]
    [SerializeField] float resetTime;//���b�o������R���{�񐔂����Z�b�g���邩
    [Header("�g���b�N�̃R���{�񐔂̃X�R�A")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//�g���b�N�̃R���{�񐔂̃X�R�A
    private float currentResetTime=0;//�Ō�Ƀg���b�N�����Ă���o�������ԁAResetTime�ɂȂ�����R���{�񐔂����Z�b�g
    private int comboCount = 0;//�R���{��
    private bool comboContinue = false;//�R���{�������Ă��邩

    public int ComboCount
    {
        get { return comboCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateResetTime();
    }

    public void AddCombo()//�g���b�N�������Ƃ��ɃR���{�񐔂𑝂₷
    {
        comboCount++;
        comboContinue = true;//�R���{������
        currentResetTime = 0;//�Ō�Ƀg���b�N�����Ă���̎��Ԃ����Z�b�g
    }

    void UpdateResetTime()//�R���{�̃��Z�b�g���Ԃ̍X�V����
    {
        currentResetTime += Time.deltaTime;

        //�R���{���r�؂ꂽ�΂���ł��Ō�Ƀg���b�N�����Ă���resetTime�b�A���Ԃ��o�����Ƃ�true(���Z�b�g����������)
        bool reset = (comboContinue && currentResetTime >= resetTime);//�R���{�񐔂����Z�b�g���邩

        if (reset)
        {
            ResetProcess();
        }
    }

    void ResetProcess()//���Z�b�g����
    {
        score_TrickCombo.AddScore(comboCount);//�R���{�񐔕��X�R�A�𑝂₷
        comboContinue = false;//�R���{���r�؂ꂽ
        comboCount = 0; //�R���{�񐔂����Z�b�g
    }
}
