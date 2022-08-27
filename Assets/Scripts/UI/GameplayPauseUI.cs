using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPauseUI : MonoBehaviour
{
    private GameplayUI gameplayUI;

    private void Start()
    {
        gameplayUI = FindObjectOfType<GameplayUI>();
    }

    public void Resume()
    {
        gameplayUI.Resume();
    }
}