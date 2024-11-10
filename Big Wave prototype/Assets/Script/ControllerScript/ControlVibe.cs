using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�R���g���[�����o�C�u������
public class ControlVibe : MonoBehaviour
{
    [SerializeField] float low;
    [SerializeField] float high;
    private Gamepad gamepad = Gamepad.current;

    public void Vibe()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(low, high);
        }
    }
}
