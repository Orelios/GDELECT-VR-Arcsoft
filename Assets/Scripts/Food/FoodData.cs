using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Food")]
public class FoodData : ScriptableObject
{
    public string foodName; 
    public GameObject foodmodel;
    public MainOrSideDish foodType;
    public enum MainOrSideDish
    {
        Steak,
        Fries,
        MashPotatoes,
        GarlicBred
    }
}
