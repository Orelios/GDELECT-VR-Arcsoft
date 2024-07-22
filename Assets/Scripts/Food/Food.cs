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
    private void Start()
    {
        _foodName = food.name;
        _foodModel = food.foodmodel;
    }

    public string FoodName(){return _foodName;}
    public GameObject FoodModel(){return _foodModel;}

    public SteakType TypeOfSteak()
    {
        return steakType; 
    }

    //for cooking steak
    public SteakType CookSteak(SteakType steak, GameObject steakModel)
    {
        steakType = steak;
        _foodModel = steakModel;
        return steakType;
    }
}
