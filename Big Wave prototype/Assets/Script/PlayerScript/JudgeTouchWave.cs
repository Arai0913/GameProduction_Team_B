using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�ɐG���Ă��邩���f
public class JudgeTouchWave : MonoBehaviour
{
    [SerializeField] OnTriggerActionEvent onTriggerActionEvent;
    [SerializeField] float touchBorderTime = 0.1f;//�G�����E�G���ĂȂ��̋��E�̎���
    private bool touchWaveNow=false;//���g�ɐG���Ă��邩
    private float sinceLastTouchWaveTime = 0.1f;//�Ō�ɔg�ɐG���Ă���̎���
   
    public bool TouchWaveNow
    {
        get { return touchWaveNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        onTriggerActionEvent.EnterAction += TouchWave;
        sinceLastTouchWaveTime = touchBorderTime;
    }

    // Update is called once per frame
    void Update()
    {
        JudgeTouchWaveNow();//�g�ɐG��Ă��邩����
    }

    public void TouchWave(Collider c)
    {
        if (c.gameObject.CompareTag("InsideWave") || c.gameObject.CompareTag("OutsideWave"))
        {
            sinceLastTouchWaveTime = 0f;//�Ō�ɔg�ɐG���Ă���̎��Ԃ��X�V
        }
    }

    void JudgeTouchWaveNow()//�g�ɐG��Ă��邩����
    {
        sinceLastTouchWaveTime += Time.deltaTime;

        if (sinceLastTouchWaveTime < touchBorderTime)//�Ō�ɐG���Ă���touchBorderTime�b���������o���Ă��Ȃ���΍��g�ɐG��Ă��锻��
        {
            touchWaveNow = true;
        }
        else
        {
            touchWaveNow = false;
        }
    }
}
