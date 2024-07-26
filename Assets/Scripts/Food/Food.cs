using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodData food;
    [SerializeField] private SteakType steakType; 
    private GameObject _foodModel;
    private string _foodName;
    [SerializeField]private bool _steakCooked; 

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
        _steakCooked = false;
    }
    public string FoodName(){return _foodName;}
    public GameObject FoodModel(){return _foodModel;}

    public SteakType TypeOfSteak(){return steakType; }

    public void ChangeSteak(SteakType steak) { steakType = steak; }

    //for cooking steak
    public SteakType CookSteak(SteakType steak, GameObject steakModel)
    {
        steakType = steak;
        _foodModel = steakModel;
        return steakType;
    }

    public bool steakCooked() {  return _steakCooked;}
    public void SteakAlreadyCooked() {  _steakCooked = true;}
}
