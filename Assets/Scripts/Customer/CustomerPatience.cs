using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

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
 
    private void OnEnable()
    {
        //Main stuff
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
                transform.LookAt(_waypoints[x].position);   
                transform.position = Vector3.MoveTowards(transform.position, 
                    _waypoints[x].position, customerSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    public void GetWaypoints(Transform waypoints, int waypointNumber) 
    { _waypoints[waypointNumber] = waypoints; }

    public void CustomerRecievedRightOrder() { customerDone = true; }
}
