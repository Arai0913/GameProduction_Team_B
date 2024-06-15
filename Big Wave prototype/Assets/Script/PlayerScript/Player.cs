using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //������������
    private float hp = 100;//���݂̗̑�
    [Header("�v���C���[�̍ő�̗�")]
    [SerializeField] float hpMax = 100;//�ő�̗�
    private float trick = 0;//���݂̃g���b�N�Q�[�W
    [Header("�v���C���[�̍ő�g���b�N")]
    [SerializeField] float trickMax = 200;//�ő�g���b�N�Q�[�W
    SceneControlManager sceneControlManager;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float HpMax
    {
       get { return hpMax; }
    }

    public float Trick
    {
        get { return trick; }
        set { trick = value; }
    }

    public float TrickMax
    {
        get { return trickMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//�X�e�[�^�X������
        trick = 0;
        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp=Mathf.Clamp(hp,0,hpMax);//�̗͂����E�˔j���Ȃ��悤��

        trick=Mathf.Clamp(trick, 0, trickMax);//�g���b�N�����E�˔j���Ȃ��悤��

        Dead();//�G�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    }

    void Dead()//�v���C���[���S���Q�[���I�[�o�[�V�[���Ɉڍs
    {
        if(hp <=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
    //public void AttackVibration(float a)//�U���̋����ɍ��킹�ĐU������������
    //{
    //    if (gamepad != null)
    //    { 

    //        gamepad.SetMotorSpeeds(a,a);
    //    }
    //}
    //public void StopVibration()
    //{
    //    if (gamepad != null)
    //    { 

    //        gamepad.SetMotorSpeeds(0,0);
    //    }
    //}



}
