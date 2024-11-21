using UnityEngine;

// �쐬��: ���R�A�K�����ꕔ�C��
// ���ړ�(Rigidbody�Ȃ��j

public class MoveLeftAndRight : MonoBehaviour
{
    [Header("�������Ώ�")]
    [SerializeField] Transform target;
    [Header("�ړ��Ɋ��������邩�ǂ���")]
    [SerializeField] bool isInertiaEnabled;
    [Header("�����ֈ����񂹂���͂������邩�ǂ���")]
    [SerializeField] bool isCenterPullEnabled;
    [Header("�ړ��X�s�[�h")]
    [SerializeField] float speed = 11.5f;//�ړ��X�s�[�h
    [Header("�����x")]
    [SerializeField] float acceleration = 300f;
    [Header("�����x")]
    [SerializeField] float deceleration = 150f;
    [Header("�ō����x")]
    [SerializeField] float targetSpeed = 150f;
    [Header("�����Ɉ����񂹂��")]
    [SerializeField] float centerPullStrength = 10f;
    [Header("�����񂹂�͂̍ő�l")]
    [SerializeField] float maxCenterPullStrength = 100f;
    [Header("��������̋�����臒l")]
    [SerializeField] float centerThreshold = 0.1f;

    Vector3 move;
    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Move();
    }

    void Move()//�v���C���[�̈ړ�
    {
        if (!isInertiaEnabled)
            target.Translate(move * Time.deltaTime * speed);

        else
        {
            if (move.x != 0)
            {
                //����
                velocity.x = Mathf.MoveTowards(velocity.x, move.x * targetSpeed,  /*speed **/ acceleration * Time.deltaTime);
            }

            else
            {
                //����
                velocity.x = Mathf.MoveTowards(velocity.x, 0f, deceleration * Time.deltaTime);
            }

            float targetPosition = target.localPosition.x + velocity.x * Time.deltaTime;
            target.localPosition = Vector3.Lerp(target.localPosition, new Vector3(targetPosition, target.localPosition.y, target.localPosition.z), 0.1f); // Lerp�ŃX���[�Y�Ɉړ�

            //�ő呬�x����
            if (velocity.x > targetSpeed)
            {
                velocity.x = targetSpeed;
            }

            if (move.x == 0 && Mathf.Approximately(velocity.x, 0f) || Mathf.Approximately(target.localPosition.x, 9f))
            {
                velocity.x = 0f;
            }

            if (isCenterPullEnabled)
            ApplyCenterPull();
        }
    }

    void ApplyCenterPull()//�v���C���[�𒆉��Ɉ����񂹂�@�\
    {
        float centerPosition = 0f;

        float distanceFromCenter = target.localPosition.x - centerPosition;

        if (Mathf.Abs(distanceFromCenter) > centerThreshold)
        {
            float pullForce = Mathf.Clamp(Mathf.Abs(distanceFromCenter) * centerPullStrength, 0f, maxCenterPullStrength);

            target.localPosition = Vector3.Lerp(target.localPosition, new Vector3(target.localPosition.x - Mathf.Sign(distanceFromCenter) * pullForce * Time.deltaTime, target.localPosition.y, target.localPosition.z), 0.1f);
        }
    }

    public void GetMoveVector(Vector2 getVec)//�����������󂯎��
    {
        //x�����̓��͂����󂯎��
        move = new Vector3(getVec.x, 0f, 0f);
    }
}
