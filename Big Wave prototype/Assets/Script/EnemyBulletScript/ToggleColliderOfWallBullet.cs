using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleColliderOfWallBullet : MonoBehaviour
{
    WallBullet wallBullet;

    bool colliderToggled = false;//�R���C�_�[�̐؂�ւ��̊Ǘ��p

    public void SetWallBullet(WallBullet wallBullet)
    {
        this.wallBullet = wallBullet;
    }

    void OnTriggerEnter(Collider other)
    {
        if (wallBullet != null && other.CompareTag("Player") && wallBullet.Generated && !colliderToggled)
        {
            wallBullet.ToggleCollider();
            colliderToggled = true;
        }
    }
}
