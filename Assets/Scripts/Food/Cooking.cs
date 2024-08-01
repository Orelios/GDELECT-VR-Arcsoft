using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;
using static Food;

public class Cooking : MonoBehaviour
{
    [Header("Steak Cooking Times")]
    [SerializeField] private float[] steakCookTimes;
    [Header("Steak Types")]
    [SerializeField] private Food[] steaks;
    [SerializeField] private SteakType[] steakTypes; 
    [SerializeField] private Image cookTimerImage; 

    private float cookTimer;
    private int changeSteak; 
    private bool steakCooked;

    //audio

    private EventInstance meatCooking;

    private void Start()
    {
        Debug.Log("Initialized Instance");
        meatCooking = AudioManager.instance.CreateEventInstance(FModEvents.instance.meatCooking);
    }

    private void OnEnable()
    {
        steakCooked = false;
        cookTimer = 0;
        changeSteak = 1;
        cookTimerImage.fillAmount = 0;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pan")) 
        {
            meatCooking.start();
            transform.GetChild(0).gameObject.SetActive(true);
            if (steakCooked == false) { StartCoroutine(CookSteak()); } 
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        meatCooking.stop(STOP_MODE.IMMEDIATE);
        transform.GetChild(0).gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Pan")) { steakCooked = true; }
    }

    IEnumerator CookSteak()
    {
        while (steakCooked == false)
        {
            cookTimer += Time.deltaTime; 
            cookTimerImage.fillAmount = cookTimer/steakCookTimes[4];           
            ChangeSteakType();           
            yield return null;

            if (cookTimerImage.fillAmount == 99)
            {
                AudioManager.instance.PlayOneShot(FModEvents.instance.burnt, this.transform.position);
            }
        }
    }

    private void ChangeSteakType()
    {
        if (cookTimer >= steakCookTimes[changeSteak]) 
        {
            GetComponent<Food>().CookSteak(steakTypes[changeSteak], steaks[changeSteak]);
            //Debug.Log(GetComponent<Food>().TypeOfSteak());
            if (changeSteak != 4) { changeSteak++; }
        }
    }
}
