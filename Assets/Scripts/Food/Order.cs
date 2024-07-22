using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/customerOrder")]
public class Order : ScriptableObject
{
    public GameObject steak; 
    public GameObject sideDish;

    public float customerPatience;
}
