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
    [Header("���j���ɐ�������G�t�F�N�g")]
    [SerializeField] DefeatEffect _defeatEffect;
    bool _startMotion = false;

    public void Trigger()
    {
        _defeatEffect.DefeatStart();
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
       
    }

    void Update()
    { 
        _defeatEffect.GenerateDefeatEffect();
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
   
    [System.Serializable]
    class DefeatEffect
    {
        [Header("���𔭐�������ʒu")]
        [SerializeField] Transform _defeatObject;
        [Header("�����𔭐�������ʒu")]
        [SerializeField] Transform _expObject;
        [Header("��������G�t�F�N�g(��)")]
        [SerializeField] GameObject _defeatSmoke;
        [Header("���̐����Ԋu")]
        [SerializeField] float _smokeInterval;
        [Header("���𐶐�����͈�")]
        [SerializeField] Limit Smoke;
        [Header("��������G�t�F�N�g(����)")]
        [SerializeField] GameObject _defeatBoom;
        [Header("���b��ɔ������邩")]
        [SerializeField] float _boomTime;
        [Header("Y���W�̃Y��")]
        [SerializeField] float _boomOffset;
        bool judgeDefeat = false;
        bool boomed=false;
        float countTime;
        int countSmoke = 1;
        private List<GameObject> Effects=new();
        [System.Serializable]
        public struct Limit
        {
            public float Max_x;
            public float Max_y;
            public float Min_x;
            public float Min_y;
        }
        public void GenerateDefeatEffect()
        {
            if (!judgeDefeat) return;
            
                countTime += Time.deltaTime;
                if (countTime > _smokeInterval * countSmoke )
                {
                    countSmoke += 1;
                    Vector3 randomPosition = new Vector3(_defeatObject.transform.position.x+(Random.Range(Smoke.Min_x, Smoke.Max_x)),_defeatObject.transform.position.y+( Random.Range(Smoke.Min_y, Smoke.Max_y)), _defeatObject.transform.position.z);

                    GameObject Effect = Instantiate(_defeatSmoke, randomPosition, Quaternion.Euler(-90f, 0f, 0f), _defeatObject.transform);
                Effects.Add(Effect);
                }
                else if (countTime>_boomTime&&!boomed)//��񂾂��Ă�
                {
                DestroySmoke();
                Vector3 expPosition = new Vector3(_expObject.transform.position.x, _expObject.transform.position.y + _boomOffset, _expObject.transform.position.z);
                Instantiate(_defeatBoom, expPosition,Quaternion.identity,_expObject.transform);
                   boomed = true;
                }
            
        }
      public void DefeatStart()
        {
            judgeDefeat = true;
        }
        public void DestroySmoke()
        {
            foreach (var Smoke in Effects)
            {
                if (Smoke != null)
                {
                    Destroy(Smoke);
                }
              
            }
            Effects.Clear();
        }
    }
   
}


