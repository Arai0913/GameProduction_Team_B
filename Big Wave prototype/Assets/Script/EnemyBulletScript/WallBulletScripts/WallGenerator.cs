using UnityEngine;

//�쐬�ҁF�K��

public partial class WallBullet
{
    void GenerateWalls()//�ǂ̐���
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
}