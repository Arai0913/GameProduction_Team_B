using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWave : MonoBehaviour
{
    private LineInstantiate m_lineInstantiate;

    //�������ɌĂяo��
    public void Method1(LineInstantiate lineInstantiate)
    {
        m_lineInstantiate = lineInstantiate;
    }

    //�������ɌĂяo��
    public void Method2()
    {
        m_lineInstantiate.Method2();
    }
}
