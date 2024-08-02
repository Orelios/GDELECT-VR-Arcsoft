using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameplayObjects;
    [SerializeField] private List<MonoBehaviour> gameplayScripts;
    // This is super hardcoded rn

    public void EnableGameplayElements()
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

    public void ResetGameplayElements()
    {

    }

    public void DisableGameplayElements()
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
