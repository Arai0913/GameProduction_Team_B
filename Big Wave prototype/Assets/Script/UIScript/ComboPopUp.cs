using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ComboPopUp : MonoBehaviour
{
   

    [SerializeField] Canvas canvas;  
    [SerializeField] TMP_Text text_countPrefab;
    [SerializeField] TMP_Text text_comboPrefab;
    [SerializeField] Transform target;
  
    private TMP_Text text_countInstance;
    private TMP_Text text_comboInstance;
    private int comboCount;
   
   
    public void PopUp()
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
        comboCount++;
        text_countPrefab.text = (("")+comboCount);
        // Canvas �̎q�v�f�Ƃ��ăC���X�^���X�𐶐�
        text_countInstance = Instantiate(text_countPrefab, canvas.transform);
        text_comboInstance = Instantiate(text_comboPrefab, canvas.transform);
       
        // �\�����e��ݒ�
       

        // �C���X�^���X�̈ʒu���^�[�Q�b�g�̃X�N���[�����W�ɍ��킹��
      
        

        RectTransform rectTransformCount = text_countInstance.GetComponent<RectTransform>();
        RectTransform rectTransformCombo = text_comboInstance.GetComponent<RectTransform>();

        // �X�N���[�����W�� UI �̃��[�J�����W�ɕϊ�
        rectTransformCount.position = screenPosition;
        rectTransformCombo.position = screenPosition;


    }
    public void ResetCount()
    {
        comboCount = 0;
    }
}
