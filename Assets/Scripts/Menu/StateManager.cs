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

    void Awake()
    {
        EnableGameObjects(false);
        //EnableScripts(false);
        EnableMainMenu();
    }

    // Functions for state managing use
    public void StartGameplay()
    {
        // enable/disable gameplay stuff
        EnableGameObjects(true);
        //ResetGameplayElements();
        // show/hide the menu for this state
        startScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    public void EndGameplay()
    {
        // enable/disable gameplay stuff
        EnableGameObjects(false);
        EnableScripts(false);
        // show/hide the menu for this state
        endScreen.SetActive(true);
    }

    public void EnableMainMenu()
    {
        // enable/disable gameplay stuff
        EnableGameObjects(false);
        EnableScripts(false);
        // show/hide the menu for this state
        startScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Player has exit the game");
    }

    // Functions for making the state changes
    private void EnableGameObjects(bool boolSet)
    {
        foreach (GameObject vrObject in gameplayObjects)
        {
            vrObject.SetActive(boolSet);
        }
    }

    private void EnableScripts(bool boolSet)
    {
        foreach (var script in gameplayScripts)
        {
            script.enabled = boolSet;
        }
    }

    private void ResetGameplayElements()
    {

    }
}
