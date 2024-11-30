using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _player_animator;
    [SerializeField] string _deadTriggerName;
    [Header("�v���C���[")]
    [SerializeField] HideObject _player;
    bool _startMotion = false;

    public void Trigger()
    {
        //_player_animator.SetTrigger(_deadTriggerName);
        Debug.Log("�������������������I�I�I(�f����)");//���[�V����������܂ł͑���Ƀf�o�b�O���O�ŃT�[�t�N�̒f�����ł������Ă����܂�
        _startMotion = true;
    }

    void Update()
    {
        _player.UpdateDeleteTime(_startMotion);
    }


    [System.Serializable]
    class HideObject
    {
        [SerializeField] GameObject _hideObject;
        [Header("���b��ɏ�����")]
        [SerializeField] float _hideTime;
        float _currentDeleteTime = 0;

        public void UpdateDeleteTime(bool start)
        {
            if (!start) return;

            _currentDeleteTime += Time.deltaTime;

            if (_currentDeleteTime >= _hideTime)
            {
                _hideObject.SetActive(false);
            }
        }
    }
}
