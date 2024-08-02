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
            Debug.Log("Works");
            CheckFood(other.gameObject.GetComponent<Plate>().Steak(),
                other.gameObject.GetComponent<Plate>().SideDish());
            other.transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Plate>() != null)
        {
            Debug.Log("Works");
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
            AudioManager.instance.PlayOneShot(FModEvents.instance.customerHitCorrect, this.transform.position);
            AudioManager.instance.PlayOneShot(FModEvents.instance.customerApproval, this.transform.position);
        }
        else 
        {
            onWrongFoodRecieved.Invoke();
            AudioManager.instance.PlayOneShot(FModEvents.instance.customerDisapproval, this.transform.position);
        }
    }

    public bool IsRightSteak { get { return isRightSteak; } }
    public bool IsRightSideDish { get { return isRightSideDish; } }
} 
