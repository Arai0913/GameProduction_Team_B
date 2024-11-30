using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�G�̎��S���[�V����
//���b���[�V������������A���������ă��f���̕����\���ɂ���
public class EnemyDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _enemy_animator;
    [SerializeField] string _deadTriggerName;
    [Header("�G�̃��f��")]
    [SerializeField] HideObject _enemy;
    [Header("�����Ԃ�")]
    [SerializeField] HideObject _waterSplash;
    bool _startMotion=false;

    public void Trigger()
    {
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
    }

    void Update()
    {
        _enemy.UpdateDeleteTime(_startMotion);
        _waterSplash.UpdateDeleteTime(_startMotion);
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


