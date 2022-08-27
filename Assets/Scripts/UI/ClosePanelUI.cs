using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelUI : MonoBehaviour
{
    private void Update()
    {
    }

    public void ClosingPanel()
    {
        GameObject.Destroy(gameObject);
    }
}