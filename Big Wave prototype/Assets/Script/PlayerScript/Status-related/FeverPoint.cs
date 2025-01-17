using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//フィーバーポイント
public class FeverPoint : MonoBehaviour
{
    [Header("最大フィーバーポイント")]
    [SerializeField] float feverPointMax = 500f;//最大フィーバーポイント
    private float feverPoint = 0f;//現在のフィーバーポイント

    public float FeverPoint_
    {
        get { return feverPoint; }
        set
        {
            feverPoint = value;
            feverPoint = Mathf.Clamp(feverPoint, 0f, feverPointMax);//フィーバーポイントが限界突破しないように
        }
    }

    public float FeverPointMax
    {
        get { return feverPointMax; }
    }
    // Start is called before the first frame update
    void Start()
    {
        feverPoint = 0f;
    }
}
