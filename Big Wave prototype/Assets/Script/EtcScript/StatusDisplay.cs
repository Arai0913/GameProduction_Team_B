using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    //������������
    [SerializeField] GameObject playerOfHpGauge;//�v���C���[��HP�Q�[�W
    [SerializeField] GameObject playerOfTrickGauge;//�v���C���[�̃g���b�N�Q�[�W
    [SerializeField] GameObject enemyOfHpGauge;//�G��HP�Q�[�W
    Enemy enemy;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOfHPGage();

        PlayerOfTRICKGage();

        EnemyOfHPGage();
    }

    void PlayerOfHPGage()//�v���C���[��HP�Q�[�W�̏���
    {
        float hpratio = player.Hp / player.HpMax;
        playerOfHpGauge.GetComponent<Image>().fillAmount = hpratio;
    }

    void PlayerOfTRICKGage()//�v���C���[�̃g���b�N�Q�[�W�̏���
    {
        float trickratio = player.Trick / player.TrickMax;
        playerOfTrickGauge.GetComponent<Image>().fillAmount = trickratio;
    }

    void EnemyOfHPGage()//�G��HP�Q�[�W�̏���
    {
        if (enemy != null)
        {
            float enemy_hpratio = enemy.Hp / enemy.HpMax;
            enemyOfHpGauge.GetComponent<Image>().fillAmount = enemy_hpratio;
        }
    }
}
