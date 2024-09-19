using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallBullet : MonoBehaviour
{
    GameObject[,] walls;//���������ǂ̃v���n�u���Ǘ�����z��

    GameObject[,] wallsPreview;//�U���͈͗\���v���n�u���Ǘ�����z��

    Rigidbody wallAreaRigidbody;//�ǂ̐����͈̓v���n�u�̑��x�Ǘ��p�̕ϐ�

    Camera mainCamera;

    EnemyActionTypeShotWall enemyActionTypeShotWall;

    private float currentDelayTime;//�o�ߎ��Ԃ̌v���p

    private float groundY;//�n�ʂ�Y���W

    private bool generated = false;//�ǂ��������ꂽ���ǂ���

    private int wallsCount;//�ǂ̖����Ǘ��p�̕ϐ�

    public bool Generated
    {
        get { return generated; }
        private set { generated = value; }
    }

    public void SetWallBullet(EnemyActionTypeShotWall enemyActionTypeShotWall)
    {
        this.enemyActionTypeShotWall = enemyActionTypeShotWall;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyActionTypeShotWall.WallAreaInstance != null)
        {
            wallAreaRigidbody = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Rigidbody>();

            groundY = enemyActionTypeShotWall.Ground.GetComponent<Renderer>().bounds.min.y;//�n�ʂ̍Œ�Y���W���擾

            mainCamera = Camera.main;

            PositioningWallArea();//�ǂ̐����͈͂̈ʒu��ݒ�

            GenerateWalls();//�ǂ𐶐�
            PositioningWalls();//�ǂ̈ʒu�𒲐�

            GenerateWallsPreview();//�U���͈͗\���̐���
            PositioningWallsPreview();//�U���͈͗\���̈ʒu�𒲐�

            generated = true;

            currentDelayTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime < enemyActionTypeShotWall.PreviewDisplayDuration)
        {
            float alpha = Mathf.PingPong(currentDelayTime / enemyActionTypeShotWall.TransparencyCycleDuration * 255f, 255f);
            SetPreviewTransparency(alpha / 255f);//�U���͈͗\���̓����x��ݒ肷��
        }

        else//��莞�Ԍo�߂��o�߂�����
        {
            DisableWallsPreview();//�U���͈̗͂\���̖���������
        }

        AddForceToWalls();//�ǂɗ͂�������
    }

    void PositioningWallArea()//�ǂ̐����͈̓v���n�u�̈ʒu�̐ݒ�
    {
        if (enemyActionTypeShotWall.MatchCameraSize)//�J�����̕`�ʔ͈͂ɍ��킹��ꍇ
        {
            float screenHeight = 2f * mainCamera.orthographicSize;//�J�����̕`�ʔ͈͂̍������v�Z
            float screenWidth = screenHeight * mainCamera.aspect;//�J�����̕`�ʔ͈͂̉������v�Z

            //�ǂ̐����͈̓v���n�u�̃X�P�[���ݒ�
            enemyActionTypeShotWall.WallAreaInstance.transform.localScale = new Vector3(
                screenWidth,
                screenHeight,
                enemyActionTypeShotWall.WallAreaInstance.transform.localScale.z
                );
        }

        float wallAreaHeight = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.size.y;//�ǂ̐����͈̓v���n�u�̍������擾

        Vector3 wallAreaPos = enemyActionTypeShotWall.WallAreaInstance.transform.position;//�ǂ̐����͈̓v���n�u�̌��݈ʒu���擾

        wallAreaPos.y = groundY + wallAreaHeight / 2;//�ǂ̐����͈̓v���n�u��Y���W��n�ʂ̍����ɍ��킹��        

        enemyActionTypeShotWall.WallAreaInstance.transform.position = wallAreaPos;//�ǂ̐����͈̓v���n�u�̈ʒu��ݒ�
    }

    void GenerateWalls()
    {
        walls = new GameObject[enemyActionTypeShotWall.Height, enemyActionTypeShotWall.Width];//�ǂ̃v���n�u���Ǘ�����z���������

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            wallsCount = 0;

            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                //�ǂ̃v���n�u�𐶐����A�ǂ̐����͈̓v���n�u�̎q�I�u�W�F�N�g�ɐݒ�
                GameObject wallInstance = Instantiate(enemyActionTypeShotWall.WallPrefab, enemyActionTypeShotWall.WallAreaInstance.transform);

                if (wallInstance != null)
                {
                    walls[i, j] = wallInstance;//�������ꂽ�ǂ̃v���n�u��z��Ɋi�[

                    if (Random.value < enemyActionTypeShotWall.GenerationProbability && wallsCount < enemyActionTypeShotWall.Width - 1)
                    {
                        walls[i, j].SetActive(true);//�ǂ̃v���n�u��L����

                        //ToggleColliderOfWallBullet�X�N���v�g��L���������ǂ̃v���n�u�ɒǉ�
                        ToggleColliderOfWallBullet toggleColliderScript = wallInstance.AddComponent<ToggleColliderOfWallBullet>();

                        //ToggleColliderOfWallBullet��wallBullet�̎Q�Ƃ�ݒ�
                        toggleColliderScript.SetWallBullet(this);

                        wallsCount++;
                    }

                    else
                    {
                        walls[i, j].SetActive(false);//�ǂ̃v���n�u�𖳌���
                    }
                }
            }
        }
    }

    void PositioningWalls()
    {
        Vector3 size_WallArea = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.size;//�ǂ̐����͈̓v���n�u�̑傫�����擾
        Vector3 size_Wall = walls[0, 0].GetComponent<Renderer>().bounds.size;//�������ꂽ�ǃv���n�u�̑傫�����擾

        //�ǃv���n�u�̃X�P�[���v�Z
        Vector3 scaleFactor = new Vector3(
        size_WallArea.x / (enemyActionTypeShotWall.Width * size_Wall.x),//X���̑傫���𒲐�
        size_WallArea.y / (enemyActionTypeShotWall.Height * size_Wall.y),//Y���̑傫���𒲐�
        size_WallArea.z);

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                walls[i, j].transform.localScale = scaleFactor;//���ꂼ��̕ǃv���n�u�̑傫����ݒ�

                //�ǃv���n�u��z�u����ʒu�̌v�Z
                Vector3 localPos_Wall = new Vector3(
                (j - (enemyActionTypeShotWall.Width / 2f) + 0.5f) * scaleFactor.x,//x���̈ʒu����
                (i - (enemyActionTypeShotWall.Height / 2f) + 0.5f) * scaleFactor.y,//y���̈ʒu����
                0);

                //���[�J�����W�n�ł̈ʒu�ݒ�
                walls[i, j].transform.localPosition = localPos_Wall;//���ꂼ��̕ǃv���n�u�̈ʒu��ݒ�
            }
        }
    }

    void GenerateWallsPreview()//�U���͈̗͂\���\���̐���
    {
        wallsPreview = new GameObject[enemyActionTypeShotWall.Height, enemyActionTypeShotWall.Width];//�U���͈̗͂\���\���p�v���n�u���Ǘ�����z���������

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (walls[i, j].activeSelf)//�ǃv���n�u���L���Ȃ�
                {
                    wallsPreview[i, j] = Instantiate(enemyActionTypeShotWall.WallPreviewPrefab, enemyActionTypeShotWall.WallAreaInstance.transform);
                    wallsPreview[i, j].SetActive(true);//�U���͈͗\���v���n�u��L����
                }
            }
        }
    }

    void PositioningWallsPreview()//�U���͈̗͂\���v���n�u�̈ʒu�𒲐�
    {
        //SpawnPosOfWallPreview�̃��[���h���W���擾
        Vector3 spawnPosWorld = enemyActionTypeShotWall.SpawnPosOfWallPreview.transform.position;

        //wallAreaInstance�̃��[�J�����W�n�ɕϊ�
        Vector3 spawnPosLocal = enemyActionTypeShotWall.WallAreaInstance.transform.InverseTransformPoint(spawnPosWorld);

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)//�U���͈̗͂\���v���n�u�����݂���Ȃ�
                {
                    wallsPreview[i, j].transform.localScale = walls[i, j].transform.localScale;

                    Vector3 wallsPreviewPos = walls[i, j].transform.localPosition;

                    //�U���͈̗͂\���v���n�u�̈ʒu��ݒ�
                    wallsPreview[i, j].transform.localPosition = new Vector3(
                    wallsPreviewPos.x,//x���W�𒲐�
                    wallsPreviewPos.y,//y���W�𒲐�
                    spawnPosLocal.z);//z���W��SpawnPosOfWallPreview��z���W�ɍ��킹��
                }
            }
        }
    }

    void DisableWallsPreview()//�U���͈̗͂\���̖���������
    {
        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)
                {
                    wallsPreview[i, j].SetActive(false);//�U���͈̗͂\���v���n�u�𖳌���
                }
            }
        }
    }

    void SetPreviewTransparency(float alpha)//�U���͈̗͂\���̓����x��ݒ�
    {
        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)//�U���͈̗͂\���v���n�u�����݂���Ȃ�
                {
                    //�U���͈̗͂\���v���n�u��Renderer���擾
                    Renderer renderer = wallsPreview[i, j].GetComponent<Renderer>();

                    if (renderer != null)//Renderer�����݂���Ȃ�
                    {
                        Color color = renderer.material.color;//���݂̐F���擾
                        color.a = alpha;//�����x��ݒ�
                        renderer.material.color = color;//�F���X�V
                    }
                }
            }
        }
    }

    void AddForceToWalls()//�ǃv���n�u�ɗ͂�������
    {
        if (wallAreaRigidbody != null)
        {
            Vector3 velocity = wallAreaRigidbody.velocity;//�ǂ̐����͈̓v���n�u�̑��x���擾

            for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
            {
                for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
                {
                    if (walls[i, j] != null)
                    {
                        //�ǂ�Rigidbody���擾
                        Rigidbody wallRigidbody = walls[i, j].GetComponent<Rigidbody>();

                        if (wallRigidbody != null)
                        {
                            wallRigidbody.velocity = velocity;//���ꂼ��̕ǃv���n�u�ɑ��x��ݒ�
                        }
                    }
                }
            }
        }
    }

    public void ToggleCollider()//�ǂ̃R���C�_�[�𖳌�������
    {
        if (walls != null)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    if (walls[i, j] != null)
                    {
                        //�ǃv���n�u�̃R���C�_�[���擾
                        Collider wallCollider = walls[i, j].GetComponent<Collider>();

                        if (wallCollider != null)
                        {
                            wallCollider.enabled = false;//�ǃv���n�u�̃R���C�_�[�𖳌���
                        }
                    }
                }
            }
        }
    }
}
