using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    [field: Header("Fire Ambience")]
    [field: SerializeField] public EventReference fireAmbience { get; private set; }

    [field: Header("Restaurant Ambience")]
    [field: SerializeField] public EventReference restaurantAmbience { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header ("Pick Up")]
    [field: SerializeField] public EventReference pickUp { get; private set; }

    [field: Header("Shoot")]
    [field: SerializeField] public EventReference shoot { get; private set; }

    [field: Header("Customer Hit Correct")]
    [field: SerializeField] public EventReference customerHitCorrect { get; private set; }

    [field: Header("Meat Cooking")]
    [field: SerializeField] public EventReference meatCooking { get; private set; }

    [field: Header("Burnt")]
    [field: SerializeField] public EventReference burnt { get; private set; }

    [field: Header("CustomerSpawn")]
    [field: SerializeField] public EventReference customerSpawn { get; private set; }

    [field: Header("CustomerApproval")]
    [field: SerializeField] public EventReference customerApproval { get; private set; }

    [field: Header("CustomerDisapproval")]
    [field: SerializeField] public EventReference customerDisapproval { get; private set; }

    [field: Header("Game Start")]
    [field: SerializeField] public EventReference gameStart { get; private set; }

    [field: Header("Game End")]
    [field: SerializeField] public EventReference gameEnd { get; private set; }

    [field: Header("Game Over")]
    [field: SerializeField] public EventReference gameOver { get; private set; }


    public static FModEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Fmod Events instance in the scene.");
        }
        instance = this;
    }
}
