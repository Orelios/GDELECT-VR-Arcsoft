using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodData food;
    [SerializeField] private SteakType steakType;
    private GameObject _foodModel;
    private string _foodName;

    public enum SteakType
    {
        NotSteak,
        Raw,
        Rare,
        MediumWell,
        WellDone,
        Burnt
    }
    private void OnEnable()
    {
        _foodName = food.name;
        _foodModel = food.foodmodel;
    }
    public GameObject FoodModel(){return _foodModel;}

    public SteakType TypeOfSteak(){return steakType; }

    public void ChangeSteak(SteakType steak) { steakType = steak; }

    //for cooking steak
    public void CookSteak(SteakType steak, Food steakModel)
    {
        steakType = steak;
        /*
        for (int x = 0; x < steakModel.GetComponent<MeshRenderer>().sharedMaterials.Length; x++)
        { GetComponent<MeshRenderer>().materials[x] = steakModel.GetComponent<MeshRenderer>().sharedMaterials[x]; }
        */
        GetComponent<MeshFilter>().mesh = steakModel.GetComponent<MeshFilter>().sharedMesh;

        GetComponent<MeshRenderer>().materials[1].color = steakModel.GetComponent<MeshRenderer>().sharedMaterials[1].color;
        
        
        
        
    }
}
