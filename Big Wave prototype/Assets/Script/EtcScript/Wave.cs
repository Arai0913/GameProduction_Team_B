using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [HideInInspector] public bool isTouched;//�v���C���[�ɐG���ꂽ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touched()
    {
        isTouched = true;
    }
}
