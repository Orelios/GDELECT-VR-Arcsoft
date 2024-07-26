using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CustomerSpawner : MonoBehaviour
{
    [Header("Customer Settings")]
    public GameObject[] customerType; 
    public float minSpawnTimer, maxSpawnTimer;

    [Header("Exit Waypoints")]
    [SerializeField] private Transform[] waypoints; 

    private static int customerSpawnLimit = 10; 

    private void Start()
    { 
        int spawnCustomerAtStart = UnityEngine.Random.Range(1, 4);

        if (customerSpawnLimit != 0 && spawnCustomerAtStart == 1 ||
            spawnCustomerAtStart == 2)
        {
            StartCoroutine(SpawnCustomer());
            customerSpawnLimit--;
        }
        else if(customerSpawnLimit != 0 && spawnCustomerAtStart == 3 ||
            spawnCustomerAtStart == 4)
        {
            StartCoroutine(SpawnTrigger());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CustomerPatience>() != null)
        {
            for (int x = 0; x < waypoints.Length; x++)
            { other.GetComponent<CustomerPatience>().GetWaypoints(waypoints[x], x); }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer") || other.CompareTag("Trigger") && customerSpawnLimit != 0) 
        { 
            StartCoroutine(SpawnCustomer());
            customerSpawnLimit --;
        }
    }

    IEnumerator SpawnCustomer()
    {
        float spawnTime = UnityEngine.Random.Range(minSpawnTimer, maxSpawnTimer);

        yield return new WaitForSeconds(spawnTime);
        
        int customerType = UnityEngine.Random.Range(0, this.customerType.Length -2);
        GameObject customer = Instantiate(this.customerType[customerType]);
        customer.transform.position = transform.position;        
    }

    IEnumerator SpawnTrigger()
    {
        GameObject customer = Instantiate(customerType[customerType.Length - 1]);
        customer.transform.position = transform.position;
        float spawnTime = UnityEngine.Random.Range(minSpawnTimer, maxSpawnTimer);

        yield return new WaitForSeconds(spawnTime);

        customer.transform.position = Vector3.forward;

        yield return new WaitForSeconds(0.1f);

        Destroy(customer); 
    }

}
