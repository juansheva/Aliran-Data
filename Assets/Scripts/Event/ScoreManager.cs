using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private PlayerController player;
    public Text[] scoreUI;
    private float score;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        for (int i = 0; i < scoreUI.Length; i++)
        {
            scoreUI[i].text = "Score : " + Data.score.ToString("0");
        }
    }
}