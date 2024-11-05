using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ComboPopUp : MonoBehaviour
{
    [SerializeField] TMP_Text text_countPrefab;
    [SerializeField] Transform chasePlayer;
    //[SerializeField] Canvas canvas;  
    private TMP_Text text_countInstance;
    private int comboCount;
   
   
    public void PopUp()
    {

        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
        comboCount++;
        text_countPrefab.text = (comboCount+("COMBO!!"));
        // Canvas �̎q�v�f�Ƃ��ăC���X�^���X�𐶐�
        text_countInstance = Instantiate(text_countPrefab,chasePlayer.transform.position, chasePlayer.transform.rotation, chasePlayer.transform);
        //text_countInstance = Instantiate(text_countPrefab, canvas.transform);
        // �\�����e��ݒ�
        // �C���X�^���X�̈ʒu���^�[�Q�b�g�̃X�N���[�����W�ɍ��킹��
        //RectTransform rectTransformCount = text_countInstance.GetComponent<RectTransform>();
        // �X�N���[�����W�� UI �̃��[�J�����W�ɕϊ�
        //rectTransformCount.position = screenPosition;
    }
    public void ResetCount()
    {
        comboCount = 0;
    }
}
