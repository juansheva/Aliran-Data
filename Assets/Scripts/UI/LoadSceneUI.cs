using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneUI : MonoBehaviour
{
    public void LoadingScene(string _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}