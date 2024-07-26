using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Food;

public class Cooking : MonoBehaviour
{
    [SerializeField] private float[] steakCookTimes;
    [SerializeField] private GameObject[] steaks;
    [SerializeField] private SteakType[] steakType;

    private bool isCooking;
    private float cookingTimer;
    private GameObject cookingTimerImage;
    private GameObject _steak;
    private int ChangeSteak; 

    private void Start()
    {
        cookingTimerImage = GameObject.FindGameObjectWithTag("CookingTimerImage");
        cookingTimerImage.GetComponent<Image>().fillAmount = 0; 
        cookingTimerImage.SetActive(false);
        isCooking = true;
        _steak = steaks[0];
        ChangeSteak = 0; 
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.GetComponent<Food>() != null && other.GetComponent<Food>().TypeOfSteak() 
            != SteakType.NotSteak && other.GetComponent<Food>().steakCooked() == false) 
        {
            isCooking = true;
            cookingTimerImage.SetActive(true);
            CookSteak();
            other.gameObject.GetComponent<Food>().
                CookSteak(_steak.GetComponent<Food>().TypeOfSteak(), _steak);
            Debug.Log(other.GetComponent<Food>().TypeOfSteak());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Food>() != null && other.GetComponent<Food>().TypeOfSteak() 
            != SteakType.NotSteak && other.GetComponent<Food>().steakCooked() == false) 
        {
            other.GetComponent<Food>().SteakAlreadyCooked();
            cookingTimerImage.SetActive(false);
            cookingTimerImage.GetComponent<Image>().fillAmount = 0;
            ChangeSteak = 0;
            _steak = steaks[0];
            cookingTimer = 0;
        }
    }

    private void CookSteak() 
    {
        if(cookingTimer < steakCookTimes[4] && isCooking == true)
        {
            cookingTimer += Time.deltaTime;
            cookingTimerImage.GetComponent<Image>().fillAmount = cookingTimer/steakCookTimes[4];
            ChangeSteakModel();
            if(cookingTimer >= steakCookTimes[4]) { isCooking = false; }
        }     
    }

    private void ChangeSteakModel()
    {
        if (cookingTimer !> steakCookTimes[ChangeSteak]) 
        {
            _steak = steaks[ChangeSteak];
            _steak.GetComponent<Food>().ChangeSteak(steakType[ChangeSteak]); 
            if(ChangeSteak != 4) { ChangeSteak++; Debug.Log(ChangeSteak); }   
        }
    } 
}
