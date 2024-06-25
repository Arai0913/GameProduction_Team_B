using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

[System.Serializable]
class Borderline
{
    [Header("��_���[�W�]����")]
    [SerializeField] int borderCount = 0;//��_���]�����
    [Header("���̕]�����̃X�R�A��")]
    [SerializeField] int addScore = 100;//�]�����Ɋl���ł���X�R�A��

    public int BorderCount
    {
        get { return borderCount; }
        set { borderCount = value; }
    }

    public int AddScore
    {
        get { return addScore; }
        set { addScore = value; }
    }
}

public class ManagementOfScore : MonoBehaviour
{
    [Header("�`���Ԃ̃X�R�A�ݒ�`")]
    [Header("�c�莞�Ԃ̃X�R�A�{���i�b���j")]
    [SerializeField] float timeScore_ratio = 10;//�c�莞�ԕ]���{��

    [Header("�`�g���b�N�Q�[�W�c�ʂ̃X�R�A�ݒ�`")]
    [Header("�g���b�N�Q�[�W�c�ʂ̃X�R�A�{��")]
    [SerializeField] float trickScore_ratio = 1;//�g���b�N�Q�[�W�c�ʂ̃X�R�A�{��

    [Header("�`�g���b�N�̃X�R�A�ݒ�`")]
    [Header("�g���b�N�������̃X�R�A��")]
    [SerializeField] int trickScore = 10;//�g���b�N�������̃X�R�A

    [Header("�`��_���]���̃X�R�A�ݒ�`")]
    [Header("�_���[�W���󂯂��񐔂�")]
    [Header("�eborderCount�̒l�i�񐔁j�𒴂���ƁA")]
    [Header("�]�����P���̒i�K�ɉ�����܂��B")]

    [Header("��_���[�W�]�����C���i�ō��j")]
    [SerializeField] Borderline bestRank;

    [Header("��_���[�W�]�����C���i���j")]
    [SerializeField] Borderline goodRank;

    [Header("��_���[�W�]�����C���i���ԁj")]
    [SerializeField] Borderline normalRank;

    [Header("��_���[�W�]�����C���i��j")]
    [SerializeField] Borderline badRank;

    [Header("�Œ�]�����̃X�R�A��")]
    [SerializeField] int lowestRank_AddScore = 0;

    private static int totalScore;//���v�X�R�A
    private static int nowScore;//�Q�[���i�s���̃X�R�A
    private static int damageCount;//�_���[�W���󂯂���
    private int remainingTime;//�N���A���̎c�莞��(�b���j
    private float oldPlayerHp;//�_���[�W���󂯂�O�̃v���C���[��HP�B�_���[�W���󂯂���̔�r�p
    private bool scoreCalculated;//�ŏI�X�R�A���v�Z�������ǂ����̔���

    Player player;
    Enemy enemy;
    TrickControl trickControl;

    public static int TotalScore
    {
        get { return totalScore; }
        private set { totalScore = value; }
    }

    public static int NowScore
    {
        get { return nowScore; }
        private set { nowScore = value; }
    }

    public static int DamageCount
    {
        get { return damageCount; }
        private set { damageCount = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        trickControl = GameObject.FindWithTag("Player").GetComponent<TrickControl>();

        totalScore = 0;
        nowScore = 0;
        damageCount = 0;
        remainingTime = 0;
        oldPlayerHp = player.Hp;
        scoreCalculated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreCalculated && (player.Hp <= 0 || enemy.Hp <= 0))
        //�N���A���̃X�R�A�v�Z������Ă��Ȃ��A���v���C���[���G��HP��0�ȉ��ɂȂ�����
        {
            CalculateTimeScore();
            CalculateTrickGageScore();
            CalculateDamageScore();

            totalScore += nowScore;//���v�X�R�A�Ƀv���C���̃X�R�A�����_
            scoreCalculated = true;//�N���A���̃X�R�A���v�Z���ꂽ
        }

        CheckDamage();
    }

    void CheckDamage()//�_���[�W�̏���
    {
        if (player.Hp < oldPlayerHp)//�v���C���[��HP������������
        {
            damageCount++;
        }

        if (player.Hp != oldPlayerHp)//�v���C���[��HP������������
        {
            oldPlayerHp = player.Hp;//���݂�HP���L�^

            if (oldPlayerHp >= player.HpMax)
            {
                oldPlayerHp = player.HpMax;
            }
        }
    }

    public void AddTrickScore()//�g���b�N�������ɃX�R�A�����_
    {
        nowScore += trickScore;
    }

    void CalculateTimeScore()//�c�莞�Ԃ̃X�R�A�v�Z
    {
        remainingTime = (int)(TimeDisplay.Minutes * 60 + TimeDisplay.Seconds);
        totalScore += (int)(remainingTime * timeScore_ratio);//�c�莞�Ԃɉ������X�R�A�����_
    }

    void CalculateTrickGageScore()//�g���b�N�Q�[�W�c�ʂ̃X�R�A�v�Z
    {
        for (int i = 0; i < player.TrickPoint.Length; i++)
        {
            totalScore += (int)(player.TrickPoint[i] * trickScore_ratio);//�g���b�N�Q�[�W�̎c�ʂɉ������X�R�A�����_
        }
    }

    void CalculateDamageScore()//�_���[�W�]���̃X�R�A�v�Z
    {
        switch (damageCount)//�_���[�W���󂯂��񐔂̕]��
        {
            case int n when (n <= bestRank.BorderCount)://�_���[�W���󂯂��񐔂�bestRank.BoderCount��ȉ��̎�
                totalScore += bestRank.AddScore;//���v�X�R�A�ɍō��]�����̃X�R�A�����_
                break;

            case int n when (bestRank.BorderCount < n && n <= goodRank.BorderCount):
                //�_���[�W���󂯂��񐔂�bestRank.BorderCount��𒴂��A����goodRank.BorderCount��ȉ��ł��鎞
                totalScore += goodRank.AddScore;//���v�X�R�A�ɍ��]�����̃X�R�A�����_
                break;

            case int n when (goodRank.BorderCount < n && n <= normalRank.BorderCount):
                //�_���[�W���󂯂��񐔂�goodRank.borderCount��𒴂��A����normalRank.BoarderCount��ȉ��ł��鎞
                totalScore += normalRank.AddScore;//���v�X�R�A�ɕ��ʕ]�����̃X�R�A�����_
                break;

            case int n when (normalRank.BorderCount < n && n <= badRank.BorderCount):
                //�_���[�W���󂯂��񐔂�normalRank.BorderCount��𒴂��A����badRank.BorderCount��ȉ��ł��鎞
                totalScore += badRank.AddScore;//���v�X�R�A�ɒ�]�����̃X�R�A�����_
                break;

            case int n when (badRank.BorderCount < n):
                //�_���[�W���󂯂��񐔂�badRank.BorderCount��𒴂�����
                totalScore += lowestRank_AddScore;//���v�X�R�A�ɍŒ�]�����̃X�R�A�����_
                break;
        }
    }
}
