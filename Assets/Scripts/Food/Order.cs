using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/customerOrder")]
public class Order : ScriptableObject
{
    public GameObject steak; 
    public GameObject sideDish;
    public Image steakImage;
    public Image sideDishImage;

    public float customerPatience;
}
