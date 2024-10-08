using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyActionTypeBase : MonoBehaviour
{
    /// <summary>
    /// �s���J�n���ɌĂԏ���
    /// beforeActionType�͑O�̍s���p�^�[���ł����s��
    /// </summary>
    public virtual void OnEnter(EnemyActionTypeBase[] beforeActionType) { }

    /// <summary>
    /// �s�������t���[���Ăԏ���
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// �s���I�����ɌĂԏ���
    /// beforeActionType�͎��̍s���p�^�[���ł���s��
    /// </summary>
    public virtual void OnExit(EnemyActionTypeBase[] nextActionType) { }
}


//�s�����̃G�t�F�N�g
[System.Serializable]
class ActionEffect
{
    [Header("�G�t�F�N�g�𐶐����邩")]
    [SerializeField] bool generate = true;
    [Header("GenerateEffect(�G�t�F�N�g����)�R���|�[�l���g")]
    [SerializeField] GenerateEffect generateEffect;
    [Header("�x����������")]
    [SerializeField] float delayTime;

    public void Generate()
    {
        if(generate)//��������Ȃ�
        {
            generateEffect.Generate(delayTime);//delayTime�x�����ăG�t�F�N�g�𐶐�
        }
    }
}
