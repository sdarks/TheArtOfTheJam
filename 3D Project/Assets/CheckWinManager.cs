using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWinManager : MonoBehaviour
{
    // Checks whether we're out of cards
    public string nextLevelName = "";

    public void Start()
    {
        StartCoroutine("CheckWin");
    }

    IEnumerator CheckWin()
    {
        // Run a coroutine that checks if we've won the level
        // Check every second
        while (true)
        {
            yield return new WaitForSeconds(1f);

            // Check for all cards using tags
            GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");

            if (cards.Length == 0)
            {
                // winner
                ChangeLevel();
            }
        }
    }

    private void ChangeLevel()
    {
        if (nextLevelName == "")
        {
            Debug.LogError("Haven't set a next level in the CheckWinManager on the managers prefab");
        }
        else
        {
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
        }
    }


}
