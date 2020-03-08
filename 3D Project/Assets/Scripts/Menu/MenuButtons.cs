using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject levelSelectRoot;
    public GameObject menuRoot;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void LevelSelectButton()
    {
        levelSelectRoot.SetActive(true);
        menuRoot.SetActive(false);
    }

    public void BackButton()
    {
        levelSelectRoot.SetActive(false);
        menuRoot.SetActive(true);
    }

    public void LoadLevelButton(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
