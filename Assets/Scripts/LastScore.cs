using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour
{
    public Text[] score;

    public Text[] highscore;

    public GameObject inputName;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < score.Length; i++)
        {
            score[i].text = "Score : " + Data.score.ToString("0");
        }
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (highscores == null)
        {
            for (int i = 0; i < highscore.Length; i++)
            {
                highscore[i].text = "Highscore : " + Data.score.ToString("0");
            }
            inputName.SetActive(true);
        }
        if (highscores != null)
        {
            for (int i = 0; i < highscore.Length; i++)
            {
                highscore[i].text = "Highscore : " + highscores.highscoreEntryList[0].score;
            }
            if (highscores.highscoreEntryList.Count < 3)
            {
                inputName.SetActive(true);
            }
            if (Data.score > highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1].score)
            {
                inputName.SetActive(true);
                if (Data.score > highscores.highscoreEntryList[0].score)
                {
                    for (int i = 0; i < highscore.Length; i++)
                    {
                        highscore[i].text = "Highscore : " + Data.score.ToString("0");
                    }
                }
            }
        }
    }
}