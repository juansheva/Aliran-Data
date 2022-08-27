using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    public GameObject entryContainer;
    public GameObject entryTemplate;

    [SerializeField]
    private List<GameObject> highscoreList;

    // Start is called before the first frame update
    private void Awake()
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Debug.Log(jsonString);

        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscoreList = new List<GameObject>();
        if (highscores != null)
        {
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreList);
            }
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry _highScoreEntry, GameObject _entryContainer, List<GameObject> _highscoreList)
    {
        GameObject rankUI = Instantiate(entryTemplate, _entryContainer.transform);
        int rankNumber = _highscoreList.Count + 1;

        string rankString;
        switch (rankNumber)
        {
            default:
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        HighscoreTemplate UI = rankUI.GetComponent<HighscoreTemplate>();

        for (int j = 0; j < 3; j++)
        {
            UI.rankUI[j].text = rankString;

            int score = _highScoreEntry.score;
            UI.score[j].text = score.ToString();

            string name = _highScoreEntry.name;
            UI.playerName[j].text = name;
        }
        _highscoreList.Add(rankUI);
    }

    public static void AddHighscoreEntry(int _score, string _name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = _score, name = _name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];

                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        if (highscores.highscoreEntryList.Count >= 4)
        {
            highscores.highscoreEntryList.RemoveAt(3);
        }
        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void DeleteRank()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 0; i < highscoreList.Count; i++)
        {
            Destroy(highscoreList[i].gameObject);
        }
        highscoreList.Clear();
    }
}