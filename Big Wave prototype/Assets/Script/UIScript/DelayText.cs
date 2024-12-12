using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:����
//
public class DelayText : MonoBehaviour
{
    [Header("�x������")]
    [SerializeField] float _delayTime;//�x������
    [Header("�\������")]
    [SerializeField] float _displayTime;//�\������
    [Header("�\������I�u�W�F�N�g")]
    [SerializeField] GameObject _delayObject;//�\������I�u�W�F�N�g
    private bool _startDisplay;//�\�����Ԃ̍X�V�����邩
    private float count;//����

    public bool _StartDisplay
    {
        get { return _startDisplay; }
        set { _startDisplay = value; }
    }

    void Start()
    {
        _startDisplay = false;
    }

    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if (!_startDisplay) return;

        count += Time.deltaTime;

        if (count > _delayTime)
        {
            _delayObject.SetActive(true);

            if (count > _displayTime)
            {
                _delayObject.SetActive(false);
                _startDisplay = false;
            }
        }
    }
}
