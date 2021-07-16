using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text[] scoreUI;
    public PlayerController player;
    private float score;
    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        Data.score = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player != null)
        {
            score += Time.deltaTime;
            if (score >= 1)
            {
                Data.score += 1;
                score = 0;
            }
            Score();
        }
    }

    private void Score()
    {
        for (int i = 0; i < scoreUI.Length; i++)
        {
            scoreUI[i].text = "Score : " + Data.score.ToString("0");
        }
    }
}