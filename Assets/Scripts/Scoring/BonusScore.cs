using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class BonusScore : MonoBehaviour
{
    [Header("CustomerCounterWaitTimeSettings")]
    [SerializeField] private float CustomerCounterWaitTime;
    private float CustomerWaitTimer;

    [Header("BonusPointsSettings")]
    [SerializeField] private float bonusPointsActiveTime;
    private float bonusPointsTimer;

    [Header("CustomerCounterLimit")]
    [SerializeField] private int customerServedLimit;
    [SerializeField]private int customerServedCounter;
    
    private Image CustomerTimerBar;
    private TMP_Text customerServedCountText;

    private bool isCustomerComboWindowTrue;
    private bool isBonusPointsActive; 

    private ScoreManager scoreManager;
     
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        isCustomerComboWindowTrue = true;
        isBonusPointsActive = true;
        customerServedCounter = 0;
        CustomerWaitTimer = CustomerCounterWaitTime;
        bonusPointsTimer = bonusPointsActiveTime;
        CustomerTimerBar = transform.GetChild(2).transform.
            GetChild(1).transform.GetChild(0).GetComponent<Image>();
        customerServedCountText = transform.GetChild(2).
            transform.GetChild(0).GetComponent<TMP_Text>();
        transform.GetChild(2).gameObject.SetActive(false);
        //StartCoroutine(CustomerCountComboWindow());
    }

    public void AddCustomerCount() 
    {
        if (customerServedCounter != customerServedLimit) 
        { customerServedCounter++; }

        if(CustomerWaitTimer == CustomerCounterWaitTime) 
        { StartCoroutine(CustomerCountComboWindow()); }

        if (customerServedCounter == customerServedLimit) 
        { ExtendBonusPointsTime(); }
    }

    private void ExtendBonusPointsTime() 
    { 
        bonusPointsTimer += bonusPointsActiveTime/4; 
        if(bonusPointsTimer > bonusPointsActiveTime) 
        { bonusPointsTimer = bonusPointsActiveTime; }
    } 

    IEnumerator CustomerCountComboWindow()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        while (isCustomerComboWindowTrue == true)
        {
            CustomerWaitTimer -= Time.deltaTime;
            CustomerTimerBar.fillAmount = CustomerWaitTimer / CustomerCounterWaitTime;

            customerServedCountText.text = "Customers Served: " + 
                customerServedCounter + "/" + customerServedLimit;

            if (CustomerTimerBar.fillAmount == 0) 
            {
                isBonusPointsActive = true;
                CustomerTimerBar.fillAmount = 1;
                transform.GetChild(2).gameObject.SetActive(false);
                bonusPointsTimer = bonusPointsActiveTime;
                customerServedCountText.text = "";
            }

            if(customerServedCounter == customerServedLimit) 
            {                 
                isBonusPointsActive = true;
                CustomerTimerBar.fillAmount = 1;
                transform.GetChild(2).gameObject.SetActive(false);
                bonusPointsTimer = bonusPointsActiveTime;               
                customerServedCountText.text = "";
                StartCoroutine(BonusPointsActive());
                isCustomerComboWindowTrue = false;
            }
            yield return null;
        }
 
    }
    IEnumerator BonusPointsActive() 
    {      
        transform.GetChild(2).gameObject.SetActive(true);
        customerServedCountText.text = "Magister Mode";
        while (bonusPointsTimer >= 0)
        {
            bonusPointsTimer -= Time.deltaTime;
            CustomerTimerBar.fillAmount = bonusPointsTimer / bonusPointsActiveTime;
            scoreManager.MultiplierActive();
            if (bonusPointsTimer <= 0.1)
            {
                scoreManager.MultiplierInactive();
                customerServedCounter = 0;
                customerServedCountText.text = "";
                CustomerTimerBar.fillAmount = 1;
                CustomerWaitTimer = CustomerCounterWaitTime;
                transform.GetChild(2).gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
