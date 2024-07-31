using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> Listeners = new List<GameEventListener>(); 

    public void RegisterListener(GameEventListener listener)
    {
        Listeners.Add(listener); 
    }

    public void UnRegisterListener(GameEventListener listener)
    {
        Listeners.Remove(listener); 
    }

    public void Raise()
    {
        for(int i = Listeners.Count - 1; i >= 0; i--)
        {
            Listeners[i].OnEventRaised(); 
        }
    }
}
