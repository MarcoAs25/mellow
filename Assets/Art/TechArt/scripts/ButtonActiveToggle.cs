using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActiveToggle : MonoBehaviour
{
    [SerializeField]
    GameObject preMenu, menu, toActiveOrDisable;
    public void ActiveToggle()
    {
        if(toActiveOrDisable.activeSelf == true)
        {
            toActiveOrDisable.SetActive(false);
        }
        else
        {
            toActiveOrDisable.SetActive(true);
        }
    }

    public void _EnterMenu()
    {
        preMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void ReturnToOpening()
    {
        preMenu.SetActive(true);
        menu.SetActive(false);
    }
}
