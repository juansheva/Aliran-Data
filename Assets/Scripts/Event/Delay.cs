using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delay : MonoBehaviour
{
    private PlayerController player;
    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (player == null & timer >= player.timer + 1)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}