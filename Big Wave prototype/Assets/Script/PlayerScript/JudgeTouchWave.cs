using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeTouchWave : MonoBehaviour
{
    [HideInInspector] public bool touchWaveNow=false;//���g�ɐG���Ă��邩
    private float sinceLastTouchWaveTime = 0.1f;//�Ō�ɔg�ɐG���Ă���̎���
    private float touchBorderTime = 0.1f;//�G�����E�G���ĂȂ��̋��E�̎���
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JudgeTouchWaveNow();////�g�ɐG��Ă��邩����
    }

    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.CompareTag("InsideWave") || t.gameObject.CompareTag("OutsideWave"))//�g�ɐG��Ă���Ȃ�Wave�̏��(isTouched)���擾
        {
            sinceLastTouchWaveTime = 0f;//�Ō�ɔg�ɐG���Ă���̎��Ԃ��X�V
        }
    }

    void JudgeTouchWaveNow()//�g�ɐG��Ă��邩����
    {
        sinceLastTouchWaveTime += Time.deltaTime;

        if (sinceLastTouchWaveTime < touchBorderTime)//�Ō�ɐG���Ă���
        {
            touchWaveNow = true;
        }
        else
        {
            touchWaveNow = false;
        }
    }
}
