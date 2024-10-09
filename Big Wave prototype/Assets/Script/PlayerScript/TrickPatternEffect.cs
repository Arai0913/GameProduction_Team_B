using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�쐬��:���R
//�g���b�N�p�^�[���̒��ۃN���X
public enum Button
{
    A,
    B,
    X,
    Y
}

public class TrickPatternEffect : MonoBehaviour
{
    [Header("�{�^���̎��")]
    [SerializeField] Button button;//�{�^���̎��
    [Header("����g���b�N��")]
    [SerializeField] int trickCost;
    [Header("�g���b�N���̌���(�C�x���g)")]
    [SerializeField] UnityEvent trickEffectEvent;
    
    public Button Button { get { return button; } }
    public int TrickCost { get {  return trickCost; } }
    
    public virtual void TrickEffect()//�g���b�N�̌���
    {
        trickEffectEvent.Invoke();
    }

}
