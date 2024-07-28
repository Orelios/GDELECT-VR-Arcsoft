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

    public UnityEvent onWrongFoodRecieved;
    public UnityEvent onProperFoodRecieved;
    private bool isRightSteak;
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
            CheckFood(other.gameObject.GetComponent<Food>().TypeOfSteak(), 
                other.gameObject.GetComponent<Food>().food.foodType); 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Plate>() != null)
        {
            CheckFood(other.gameObject.GetComponent<Food>().TypeOfSteak(),
                other.gameObject.GetComponent<Food>().food.foodType);
            Destroy(other.gameObject);
        }
    }

    private void CheckFood(SteakType steak, MainOrSideDish sideDish)
    {
        if(customerOrder.steak.GetComponent<Plate>().Steak() == steak && 
            customerOrder.steak.GetComponent<Plate>().SideDish() == sideDish)
        {
            onProperFoodRecieved.Invoke();
            isRightSteak =true;
            isRightSideDish = true;
        }
        else { onWrongFoodRecieved.Invoke(); }
    }

    public bool IsRightSteak { get { return isRightSteak; } }
    public bool IsRightSideDish { get { return isRightSideDish; } }
} 
