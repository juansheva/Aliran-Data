using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    public GameObject pauseMenu;

    private GameObject pausePanel;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel != null)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;

        Destroy(pausePanel);
    }

    public void Pause()
    {
        Time.timeScale = 0;

        pausePanel = Instantiate(pauseMenu, transform);
    }
}