using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�쐬�ҁF�K��

public class NavigationEventsManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = GetComponent<EventSystem>();

        AbleNavigationEvents();
    }

    public void AbleNavigationEvents()
    {
        if (eventSystem != null)
        {
            eventSystem.sendNavigationEvents = true;
        }
    }

    public void DisableNavigationEvents()
    {
        if (eventSystem != null)
        {
            eventSystem.sendNavigationEvents = false;
        }
    }
}
