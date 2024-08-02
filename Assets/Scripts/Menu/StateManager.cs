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

    [Header("MainMenu")]
    [SerializeField] private MusicState mainMenu;

    [Header("Gameplay")]
    [SerializeField] private MusicState gameplay;



    void Awake()
    {
        EnableGameObjects(false);
        //EnableScripts(false);
        EnableMainMenu();
    }

    // Functions for state managing use
    public void StartGameplay()
    {
        AudioManager.instance.PlayOneShot(FModEvents.instance.gameStart, this.transform.position);
        // enable/disable gameplay stuff
        EnableGameObjects(true);
        //ResetGameplayElements();
        // show/hide the menu for this state
        startScreen.SetActive(false);
        endScreen.SetActive(false);
        AudioManager.instance.SetMusicState(1);
    }

    public void EndGameplay()
    {
        AudioManager.instance.PlayOneShot(FModEvents.instance.gameOver, this.transform.position);
        // enable/disable gameplay stuff
        EnableGameObjects(false);
        EnableScripts(false);
        // show/hide the menu for this state
        endScreen.SetActive(true);
        AudioManager.instance.SetMusicState(0);
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
        AudioManager.instance.PlayOneShot(FModEvents.instance.gameEnd, this.transform.position);
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
