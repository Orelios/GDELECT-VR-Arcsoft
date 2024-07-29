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

    public UnityEvent onWrongFoodRecieved = new UnityEvent();
    public UnityEvent onProperFoodRecieved = new UnityEvent();
    private bool isRightSteak;
    private bool isRightSideDish;

    private BonusScore scoreManager;
    private void OnEnable()
    {
        scoreManager = FindAnyObjectByType<BonusScore>();
        onProperFoodRecieved.AddListener(scoreManager.AddCustomerCount);
        isRightSteak = false;
        isRightSideDish = false;
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
            CheckFood(other.gameObject.GetComponent<Plate>().Steak(),
                other.gameObject.GetComponent<Plate>().SideDish());
            Destroy(other.gameObject);
        }
    }

    private void CheckFood(SteakType steak, MainOrSideDish sideDish)
    {
        if(customerOrder.steak.GetComponent<Food>().TypeOfSteak() == steak && 
            customerOrder.sideDish.GetComponent<Food>().food.foodType == sideDish)
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
