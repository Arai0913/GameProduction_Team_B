using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerOfMove : MonoBehaviour
{
    MoveLeftAndRight moveLeftAndRight;

    void Start()
    {
        moveLeftAndRight = GameObject.FindWithTag("Player").GetComponent<MoveLeftAndRight>();
    }

    public void GettInputVector(InputAction.CallbackContext context)//�R���g���[���̓��͕������󂯎��
    {
        Vector2 getVec = context.ReadValue<Vector2>();//���͕������󂯎��
        moveLeftAndRight.GetMoveVector(getVec);//�v���C���[�̈ړ��R���|�[�l���g�ɓ��͕�����n��
    }
}
