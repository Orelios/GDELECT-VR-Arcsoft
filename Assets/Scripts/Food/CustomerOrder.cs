using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static Food;
using static FoodData;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] private Order customerOrder;

    public UnityEvent onFoodRecieved;
    public bool isRightSteak = false;
    private bool isRightSideDish; 
    private void OnEnable()
    {
        isRightSteak = false;
        isRightSideDish = false;
        //onFoodRecieved.AddListener(test());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Plate>() != null) 
        { 
            onFoodRecieved.Invoke();
            CheckFood(other.gameObject.GetComponent<Food>().TypeOfSteak(), 
                other.gameObject.GetComponent<Food>().food.foodType); 
        }
    }

    private void CheckFood(SteakType steak, MainOrSideDish sideDish)
    {
        if(customerOrder.steak.GetComponent<Plate>().Steak() == steak && 
            customerOrder.steak.GetComponent<Plate>().SideDish() == sideDish)
        {
            onFoodRecieved.Invoke();
            isRightSteak =true;
            isRightSideDish = true;
        }
    }
} 
