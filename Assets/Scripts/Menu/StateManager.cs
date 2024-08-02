using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameplayObjects;
    [SerializeField] private List<MonoBehaviour> gameplayScripts;
    // This is super hardcoded rn
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;

    // Functions for state managing use
    public void StartGameplay()
    {
        EnableGameplayElements();
        //ResetGameplayElements();
        startScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    public void EndGameplay()
    {
        DisableGameplayElements();
        endScreen.SetActive(true);
    }

    public void EnableMainMenu()
    {
        EnableGameplayElements();
        startScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Player has exit the game");
    }

    // Functions for making the state changes
    private void EnableGameplayElements()
    {
        foreach (GameObject vrObject in gameplayObjects)
        {
            vrObject.SetActive(true);
        }

        foreach (var script in gameplayScripts)
        {
            script.enabled = true;
        }
    }

    private void ResetGameplayElements()
    {

    }

    private void DisableGameplayElements()
    {
        foreach (GameObject vrObject in gameplayObjects)
        {
            vrObject.SetActive(true);
        }

        foreach (var script in gameplayScripts)
        {
            script.enabled = false;
        }
    }
}
