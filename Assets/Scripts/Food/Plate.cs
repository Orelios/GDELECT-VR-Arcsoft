using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Food;
using static FoodData;

public class Plate : MonoBehaviour
{
    [SerializeField] private SteakType steak; 
    [SerializeField] private MainOrSideDish sideDish;

    private bool steakOnPlate;
    private bool sidedishOnPlate; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Food>() != null)
        {
            if (other.GetComponent<Food>().food.foodType == MainOrSideDish.Steak && steakOnPlate == false)
            {
                GetFoodModel(0, other.gameObject); 
                steak = other.GetComponent<Food>().TypeOfSteak();
                steakOnPlate = true; 
            }
            else if(sidedishOnPlate == false)
            {
                GetFoodModel(1, other.gameObject);
                sideDish = other.GetComponent<Food>().food.foodType; 
                sidedishOnPlate = true;
            }
        }
    }

    private void GetFoodModel(int childNum, GameObject other) //rework this logic cause of the models issue
    {
        transform.GetChild(childNum).GetComponent<MeshFilter>().mesh
            = other.GetComponent<MeshFilter>().mesh;

        transform.GetChild(childNum).GetComponent<MeshCollider>().sharedMesh
            = other.GetComponent<MeshFilter>().sharedMesh;

        Material[] materials = other.GetComponent<MeshRenderer>().sharedMaterials;
        for (int x = 0; x < materials.Length; x++)
        { transform.GetChild(childNum).GetComponent<MeshRenderer>().materials[x].color = materials[x].color; }
    }

    public SteakType Steak(){return steak;}
    public MainOrSideDish SideDish() { return sideDish;}
}
