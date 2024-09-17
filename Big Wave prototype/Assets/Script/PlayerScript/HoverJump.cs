using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:�K��
public class HoverJump : MonoBehaviour
{
    [Header("�g���b�N�g�p���̑؋󎞊�")]
    [SerializeField] float hoverTime = 0.2f;//�g���b�N�g�p���̑؋󎞊�
    [Header("�؋�I�����ɋN����W�����v�̋���")]
    [SerializeField] float hoverJumpStrength = 5f;//�؋�I�����ɋN����W�����v�̋���
    //private Coroutine coroutine;
    Rigidbody rb;
    JudgeOnceReachedHighestPoint_Jumping judgeOnceReachedHighestPoint_Jumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        judgeOnceReachedHighestPoint_Jumping=GetComponent<JudgeOnceReachedHighestPoint_Jumping>();
    }

    public void HoverDelayJump()//hoverTime�b�z�o�[������W�����v����
    {
        bool hoverJump=judgeOnceReachedHighestPoint_Jumping.Reached;//�z�o�[�W�����v���邩

        Debug.Log(hoverJump);

        if(hoverJump) StartCoroutine(HoverJumpCoroutine());//�����Ă��鎞�̂݃z�o�[�W�����v����
    }

    IEnumerator HoverJumpCoroutine()//�x��ăz�o�[�W�����v����
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;//�d�͂ƃW�����v�̉^�����ꎞ�I�Ɏ~�߂�

        yield return new WaitForSeconds(hoverTime);

        rb.useGravity = true;
        rb.velocity = new(0, hoverJumpStrength, 0);
    }
}
