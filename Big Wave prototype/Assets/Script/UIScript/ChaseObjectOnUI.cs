using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObjectOnUI : MonoBehaviour
{
    [Header("UIが追いかける対象")]
    [SerializeField] Transform targetTfm;//UIが追いかける対象
    private RectTransform myRectTfm;

    // Start is called before the first frame update
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRectTfm.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position);
    }
}
