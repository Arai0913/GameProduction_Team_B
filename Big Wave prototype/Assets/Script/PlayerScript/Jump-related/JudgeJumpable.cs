using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���W�����v�ł��邩���肷��
public class JudgeJumpable : MonoBehaviour
{
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] JudgeTouchWave _judgeTouchWave;

    public bool Jumpable//�W�����v�\����
    {
        get { return _judgeTouchWave.TouchWaveNow&&!_judgeJumpNow.JumpNow(); }//�g�ɐG��Ă��鎞���W�����v���Ă��Ȃ����̂݃W�����v�\
    }
}
