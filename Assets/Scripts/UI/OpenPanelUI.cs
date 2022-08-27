using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelUI : MonoBehaviour
{
    public void OpeningPanel(GameObject _panelToOpen)
    {
        GameObject.Instantiate(_panelToOpen, transform);
    }
}