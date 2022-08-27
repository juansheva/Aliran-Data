using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadDelay : MonoBehaviour
{
    private PlayerController player;
    public float timer;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == null)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}