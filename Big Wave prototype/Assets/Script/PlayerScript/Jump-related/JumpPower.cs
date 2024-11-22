using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�W�����v�͂�Ԃ�
public class JumpPower : MonoBehaviour
{
    [Header("�W�����v�p���[�̎����ƃ{�^��������������̏����l")]
    [SerializeField] RepetitiveValue_Sin _repetitiveValue;
    [Header("�W�����v�֌W�̃R���g���[������")]
    [SerializeField] ControllerOfJump _controllerOfJump;//�W�����v�֌W�̃R���g���[������
    [Header("�ő�W�����v��")]
    [SerializeField] float _powerMax;
    [Header("�ŏ��W�����v��")]
    [SerializeField] float _powerMin;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] JudgeJumpable _judgeJumpable;

    public float Power//�W�����v��
    {
        get
        {
            float gap=_powerMax - _powerMin;//�ő�W�����v�͂ƍŏ��W�����v�͂̍�

            return _powerMin+gap*_repetitiveValue.Value;
        }
    }

    public float Ratio//�W�����v�͂̊���(�ŏ��Ȃ�0�A�ő�Ȃ�1)
    {
        get { return _repetitiveValue.Value; }
    }

    public void ResetJumpPower()//�W�����v�͂̃��Z�b�g�A�W�����v(����)����������̓W�����v���o���Ȃ��Ȃ�������ɂ���
    {
        _repetitiveValue.ResetCycle();
    }

    void Start()
    {
        _repetitiveValue.ResetCycle();
    }

    void Update()
    {
        Charge();
    }

    void Charge()
    {
        //�W�����v�̓`���[�W�����̓W�����v�ł��鎞���R���g���[���̃W�����v�{�^�������������Ă��鎞
        bool chargeNow = _judgeJumpable.Jumpable && _controllerOfJump.Pushing;

        if (chargeNow)
        {
            _repetitiveValue.UpdateValue();
        }    
    }
}
