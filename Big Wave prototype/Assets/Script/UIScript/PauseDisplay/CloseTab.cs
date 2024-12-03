using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseTab : MonoBehaviour
{
    [SerializeField] EventSystem _eventSystem;

    public void Close()
    {
        GameObject selectButton = _eventSystem.currentSelectedGameObject;//���I�����Ă���{�^��(Slider�Ƃ��ł�����)���擾

        //���I�����Ă�{�^������e�����ǂ��Ă��̃{�^���̐e�̃^�u��������(�e�̃^�u�ɂ�CloseTab�Ƃ����^�O�����Ă���)
        //������Ȃ������炱���ŏ������I��
        Transform closeTab=selectButton.transform.parent;

        while(closeTab!=null)
        {
            if(closeTab.gameObject.tag=="CloseTab")
            {
                break;
            }

            closeTab=closeTab.parent;
        }

        if(closeTab==null)
        {
            return;
        }


        Button[] buttons =closeTab.GetComponentsInChildren<Button>();

        for(int i=0; i<buttons.Length;i++)
        {
            if (buttons[i].tag=="CloseButton")
            {
                buttons[i].onClick.Invoke();
                return;
            }
        }


        //�e�̃^�u���擾�o�����炻�̎q�̒�����e�̃^�u�����{�^����T��(���̃{�^���ɂ�CloseButton�^�O�����Ă���)
        //������Ȃ������炱���ŏ������I��
        

        //���̕���{�^������{�^���R���|�[�l���g���擾
        //�擾�o���Ȃ������炱���ŏ������I��
        //�擾�o�����炻�̃R���|�[�l���g��OnClick�𔭓�
    }
}
