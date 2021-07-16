using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public GameObject registerButton;
    public InputField usernameInput;

    public void MinimalChar()
    {
        if (usernameInput.text.Length == 3)
        {
            registerButton.SetActive(true);
        }
        else
        {
            registerButton.SetActive(false);
        }
    }
}