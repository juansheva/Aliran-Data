using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject panelToClose;

    public void ClosingPanel()
    {
        panelToClose.SetActive(false);
    }
}