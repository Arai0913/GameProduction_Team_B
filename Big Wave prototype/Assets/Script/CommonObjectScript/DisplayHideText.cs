using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DisplayHideText
{
    [Header("表示する文字")]
    [SerializeField] TMP_Text _text;
    [Header("遅延時間")]
    [SerializeField] float _delayTime;
    [Header("表示時間")]
    [SerializeField] float _displayTime;
    float _currentDelayTime = 0;
    float _currentDisplayTime = 0;
    bool _displayed = false;
    bool _hided = false;

    public void Update()
    {
        UpdateDisplayTiming();
        UpdateHideTiming();
    }

    void UpdateDisplayTiming()
    {
        if (_displayed) return;

        _currentDelayTime += Time.deltaTime;

        if(_currentDelayTime>=_delayTime)
        {
            _displayed = true;
            _text.enabled = true;
        }
    }

    void UpdateHideTiming()
    {
        if (_hided||!_displayed) return;

        _currentDisplayTime += Time.deltaTime;

        if(_currentDisplayTime>=_displayTime)
        {
            _text.enabled = false;
        }
    }
}
