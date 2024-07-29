using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Food;
using static FoodData;

public class Plate : MonoBehaviour
{
    [SerializeField] private SteakType steak; 
    [SerializeField] private MainOrSideDish sidedishType;
    [SerializeField] private GameObject[] sidedishModels; 

    private bool steakOnPlate;
    private bool sidedishOnPlate;

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        for (int x = 0; x < sidedishModels.Length; x++) 
        { sidedishModels[x].gameObject.SetActive(false); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Food>() != null)
        {
            if (other.gameObject.GetComponent<Food>().food.foodType ==
                MainOrSideDish.Steak && steakOnPlate == false)
            {
                GetSteakModel(0, other.gameObject);
                steak = other.gameObject.GetComponent<Food>().TypeOfSteak();
                steakOnPlate = true;
                Destroy(other.gameObject);
            }
            else if (sidedishOnPlate == false)
            {
                //GetSteakModel(1, other.gameObject);
                sidedishType = other.gameObject.GetComponent<Food>().food.foodType;
                GetSidedisheModel(sidedishType);
                sidedishOnPlate = true;
                Destroy(other.gameObject);
            }          
        }
    }

    private void GetSteakModel(int childNum, GameObject other) //rework this logic cause of the models issue
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<MeshRenderer>().materials[1].color = 
            other.GetComponent<MeshRenderer>().sharedMaterials[1].color;
    }

    private void GetSidedisheModel(MainOrSideDish sidedish)
    {
        if(sidedish == MainOrSideDish.MashPotatoes) { sidedishModels[0].gameObject.SetActive(true); }
        else if(sidedish == MainOrSideDish.GarlicBred) { sidedishModels[1].gameObject.SetActive(true); }
        else if (sidedish == MainOrSideDish.Fries) { sidedishModels[2].gameObject.SetActive(true); }
    }

    public SteakType Steak(){return steak;}
    public MainOrSideDish SideDish() { return sidedishType;}
}
