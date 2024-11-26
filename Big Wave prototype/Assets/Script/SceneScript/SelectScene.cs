using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//�쐬��:���R
//�I�񂾃V�[���Ɉڍs����
class SelectScene
{
    [SerializeField] Scene _scene;
    [SerializeField] SceneController _sceneController;

    //�f�t�H���g�R���X�g���N�^
    public SelectScene() { }

    //�R���X�g���N�^
    public SelectScene(Scene scene)
    {
        _scene = scene;
    }

    public void ChangeScene()
    {
        switch(_scene)
        {
            case Scene.gameover: _sceneController.GameOverScene(); break;//�Q�[���I�[�o�[�V�[���Ɉڍs
            case Scene.clear: _sceneController.ClearScene(); break;//�N���A�V�[���Ɉڍs
            case Scene.menu: _sceneController.MenuScene(); break;//���j���[�V�[���Ɉڍs
            case Scene.game_1: _sceneController.GameScene_1(); break;//�Q�[���V�[��(�X�e�[�W1)�Ɉڍs
            case Scene.end: _sceneController.EndGame(); break;//�Q�[���I��
        }
    }
}
