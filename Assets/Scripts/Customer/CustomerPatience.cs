using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;
using UnityEngine.Events; 

public class CustomerPatience : MonoBehaviour
{
    [Header("Customer Settings")]
    [SerializeField] private Order customerOrder;

    [Header("Exit Waypoints")]
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float customerSpeed;
    private int waypointCount;
    [SerializeField] private bool customerDone = false;

    [Header("Patience bar settings")]
    private float patience;
    private float patienceTimer;
    [SerializeField] private Image patienceBar;

    [Header("Patience bar settings")]
    [SerializeField] private Image foodImages; 
    private ScoreManager scoreManager;

    private CustomerSpawner _customerLimitRef; 
 
    private void OnEnable()
    {
        //Main stuff
        CustomerSpawner.customerSpawnLimit -= 1; 
        foodImages.transform.GetChild(0).GetComponent<Image>().sprite = 
            customerOrder.steakImage.GetComponent<Image>().sprite;
        foodImages.transform.GetChild(1).GetComponent<Image>().sprite =
            customerOrder.sideDishImage.GetComponent<Image>().sprite;
        scoreManager = FindAnyObjectByType<ScoreManager>();
        patienceTimer = customerOrder.customerPatience;
        patience = customerOrder.customerPatience;
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        while (patience >= 0 && customerDone == false)
        {
            patienceTimer -= Time.deltaTime * 1;
            patienceBar.fillAmount = patienceTimer / patience;

            if (patienceBar.fillAmount == 0) 
            { customerDone = true;}

            yield return null;
        }

        if (customerDone == true)
        {
            AudioManager.instance.PlayOneShot(FModEvents.instance.customerDisapproval, this.transform.position);
            foodImages.gameObject.SetActive(false);
            StartCoroutine(CustomerExit()); 
        }
    }

    IEnumerator CustomerExit()
    {
        foreach (var item in _waypoints) { waypointCount++; }
        for(int x = 0; x < waypointCount; x++)
        {  
            while(Vector3.Distance(transform.position, _waypoints[x].position) !> 0.5f) 
            {
                Vector3 dir = _waypoints[x].position - transform.position; 
                Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 4 * Time.deltaTime);
                rot.x = 0; rot.z = 0; 
                transform.rotation = rot;
                transform.position = Vector3.MoveTowards(transform.position, 
                    _waypoints[x].position, customerSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    public void GetWaypoints(Transform waypoints, int waypointNumber) 
    { _waypoints[waypointNumber] = waypoints; }

    public void CustomerRecievedRightOrder() { customerDone = true; 
        scoreManager.RecievePoints(patienceBar.fillAmount); 
    }

    public void CustomerRecievedWrongOrder() { customerDone = true;  }

}
