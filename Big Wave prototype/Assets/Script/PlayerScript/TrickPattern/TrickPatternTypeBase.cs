using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g���b�N�p�^�[���̒��ۃN���X
public enum Button
{
    A,
    B,
    X,
    Y
}

public abstract class TrickPatternTypeBase : MonoBehaviour
{
    [Header("�{�^���̎��")]
    protected Button button;//�{�^���̎��
    [Header("����g���b�N(�Q�[�W�{��)")]
    [SerializeField] int trickCost;//����g���b�N
    
    public Button Button { get { return button; } }
    public int TrickCost { get { return trickCost; } }
    
    public virtual void TrickEffect() {}//�g���b�N�̌���

}
