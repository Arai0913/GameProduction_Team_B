using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeleteObject : MonoBehaviour
{
    //������������
    [SerializeField] float deleteTime = 4f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        Destroy(gameObject,deleteTime);
       
    }
}
