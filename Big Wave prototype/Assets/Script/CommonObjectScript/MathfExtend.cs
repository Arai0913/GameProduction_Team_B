using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���w�n�̃��\�b�h���g����������
public static class MathfExtend 
{
    public static float Cos01(float f)//cos�̒l��0�`1�ŕԂ��悤�ɂ���
    {
        const float cosWidth = 2f;//cos�̕�
        const float gap = 0.5f;//�ڕW�̒l��cos�̕��Ŋ�����cos�̒l�̍�(cos�̕��Ŋ��������Acos��-0.5�`0.5�̒l���Ƃ�̂ł����ڕW�l��0�`1�ɂ��邽�߂̒l)

        float ret = Mathf.Cos(f) / cosWidth + gap;

        return ret;
    }
}
