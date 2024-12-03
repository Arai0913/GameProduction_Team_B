using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�������̃v���C���[�̃��[�V����
public class PlayerWinMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;

    public void Trigger()
    {
        _player_animator.SetTrigger(_deadTriggerName);
    }
}
