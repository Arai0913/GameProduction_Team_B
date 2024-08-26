using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Button
{
    A,
    B,
    X,
    Y
}

public class TrickPattern : MonoBehaviour
{
    [Header("�{�^���̎��")]
    [SerializeField] Button button;//�{�^���̎��
    [Header("����g���b�N(�Q�[�W�{��)")]
    [SerializeField] int trickCost;//����g���b�N
    [Header("�g���b�N�ɗp������ʉ�")]
    [SerializeField] AudioClip soundEffect;//�g���b�N�ɗp������ʉ�
    [Header("�G�ɗ^����_���[�W")]
    [SerializeField] float damageAmount = 100;//�G�ɗ^����_���[�W

    public Button Button { get { return button; } }
    public int TrickCost { get { return trickCost; } }
    public AudioClip SoundEffect { get { return soundEffect; } }
    public float DamageAmount { get {  return damageAmount; } }

}
