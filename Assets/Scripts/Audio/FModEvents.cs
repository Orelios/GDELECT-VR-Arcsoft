using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
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
