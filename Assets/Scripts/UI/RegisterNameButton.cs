using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterNameButton : MonoBehaviour
{
    public InputField textInput;
    public GameObject namePlayer;
    public Text[] playerName;

    public void RegisterName()
    {
        HighscoreTable.AddHighscoreEntry(Data.score, textInput.text);
        textInput.gameObject.SetActive(false);
        namePlayer.SetActive(true);
        for (int i = 0; i < playerName.Length; i++)
        {
            playerName[i].text = textInput.text;
        }
        this.gameObject.SetActive(false);
    }
}