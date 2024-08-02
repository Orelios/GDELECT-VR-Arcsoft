using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance { get; private set; }

    private EventInstance fireEventInstance, restaurantEventInstance;

    private EventInstance musicEventInstance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        InitializeFire(FModEvents.instance.fireAmbience);
        InitializeRestaurant(FModEvents.instance.restaurantAmbience);
        InitializeMusic(FModEvents.instance.music);
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }

    private void InitializeFire(EventReference ambienceEventReference)
    {
        fireEventInstance = CreateEventInstance(ambienceEventReference);
        fireEventInstance.start();
    }

    private void InitializeRestaurant(EventReference ambienceEventReference)
    {
        restaurantEventInstance = CreateEventInstance(ambienceEventReference);
        restaurantEventInstance.start();
    }

    public void SetMusicState(float x)
    {
        Debug.Log("Changing States");
        musicEventInstance.setParameterByName("states", x);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
