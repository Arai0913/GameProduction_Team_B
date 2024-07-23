using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickTheCharger : MonoBehaviour
{
    [Header("�`���[�W�{��(�g���b�N�Q�[�W�̌����z���p�ӂ��Ă�������)")]
    [SerializeField] float[] chargeRate;//�`���[�W�{��
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���^���̃Q�[�W�̐��ɑΉ������`���[�W�{����Ԃ�
    public float ChargeRate()
    {
        int maxCount = player.MaxCount;
        maxCount = Mathf.Clamp(maxCount, 0, player.TrickGaugeNum - 1);
        return chargeRate[maxCount];
    }
}
