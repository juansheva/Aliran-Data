using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsLeaderboard = false;

    public GameObject pauseMenu;
    public GameObject LeaderboardMenu;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                pauseMenu.SetActive(false);
            }
            else
            {
                Pause();
                pauseMenu.SetActive(true);
            }
        }
        if (GameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        GameIsPaused = false;
    }

    public void Pause()
    {
        GameIsPaused = true;
    }

    public void LeaderboardTable()
    {
        LeaderboardMenu.SetActive(true);
        GameIsLeaderboard = true;
    }

    public void CloseLeaderboardTable()
    {
        LeaderboardMenu.SetActive(false);
        GameIsLeaderboard = false;
    }
}