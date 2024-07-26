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
                GetFoodModel(1, other.gameObject); 
                steak = other.GetComponent<Food>().TypeOfSteak(); 
            }
            else
            {
                GetFoodModel(1, other.gameObject);
                sideDish = other.GetComponent<Food>().food.foodType; 
            }
        }
    }

    private void GetFoodModel(int childNum, GameObject other)
    {
        transform.GetChild(childNum).GetComponent<MeshFilter>().mesh
            = other.GetComponent<MeshFilter>().mesh;

        transform.GetChild(childNum).GetComponent<MeshCollider>().sharedMesh
            = other.GetComponent<MeshFilter>().mesh;

        Material[] materials = other.GetComponent<MeshRenderer>().materials;
        for (int x = 0; x < materials.Length; x++)
        { transform.GetChild(childNum).GetComponent<MeshRenderer>().materials[x] = materials[x]; }
    }

    public SteakType Steak(){return steak;}
    public MainOrSideDish SideDish() { return sideDish;}
}
