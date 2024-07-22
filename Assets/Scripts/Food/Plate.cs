using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Food;
using static FoodData;

public class Plate : MonoBehaviour
{
    [SerializeField] private SteakType steak; 
    [SerializeField] private MainOrSideDish sideDish; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Food>() != null)
        {
            if (other.GetComponent<Food>().food.foodType == MainOrSideDish.Steak)
            {
                transform.GetChild(0).GetComponent<MeshFilter>().mesh 
                    = other.GetComponent<MeshFilter>().mesh;
                steak = other.GetComponent<Food>().TypeOfSteak(); 
            }
            else
            {
                transform.GetChild(1).GetComponent<MeshFilter>().mesh
                    = other.GetComponent<MeshFilter>().mesh;
                sideDish = other.GetComponent<Food>().food.foodType; 
            }
        }
    }

    public SteakType Steak(){return steak;}
    public MainOrSideDish SideDish() { return sideDish;}
}
