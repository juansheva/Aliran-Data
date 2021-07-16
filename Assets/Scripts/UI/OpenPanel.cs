using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject panelToOpen;

    public void OpeningPanel()
    {
        panelToOpen.SetActive(true);
    }
}