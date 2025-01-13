using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�R���{��(�N���e�B�J���̘A����)�𐔂���
public class CountTrickCombo : MonoBehaviour
{
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Critical critical;
    private int m_comboCount = 0;//�R���{��
    private int m_comboCountMax = 0;//�ő�R���{��
    private bool m_continueCombo=false;//�R���{�������Ă��邩
    //const int m_resetComboCount = 0;//���Z�b�g���̃R���{��

    public int ComboCount{ get { return m_comboCount; } }

    public int ComboCountMax{ get { return m_comboCountMax; } }

    public bool ContinueCombo{ get { return m_continueCombo; } }

    public void Count()//�񐔂𑝂₷
    {
        if(critical.CriticalNow)//�N���e�B�J����������
        {
            AddCombo();//�񐔉��Z����
        }
        else//�N���e�B�J������Ȃ�������
        {
            ResetCombo();//�񐔃��Z�b�g����
        }
    }

    void AddCombo()//�񐔉��Z����
    {
        //�R���{�񐔂����Z
        m_comboCount++;

        //�R���{�񐔂��ő傾������X�V
        if (m_comboCount > m_comboCountMax) m_comboCountMax = m_comboCount;

        m_continueCombo = true;
    }

    void ResetCombo()//�񐔃��Z�b�g����
    {
        //�R���{�񐔂��ő傾������X�V
        if(m_comboCount>m_comboCountMax) m_comboCountMax = m_comboCount;

        //�R���{�񐔂����Z�b�g
       // m_comboCount = m_resetComboCount;

        m_continueCombo = false;
    }
}
