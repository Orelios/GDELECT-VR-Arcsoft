using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CustomerSpawner : MonoBehaviour
{
    [Header("Customer Settings")]
    public GameObject[] customerType; 
    public float minSpawnTimer, maxSpawnTimer;
    [SerializeField] private Transform spawn; 

    [Header("Exit Waypoints")]
    [SerializeField] private Transform[] waypoints; 

    public static int customerSpawnLimit = 10;
    private int customerVariant; 

    private void Start()
    {
        customerVariant = 0; 
        StartCoroutine(SpawnCustomer());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CustomerPatience>() != null)
        {
            for (int x = 0; x < waypoints.Length; x++)
            { if (waypoints[x] != null) { other.GetComponent<CustomerPatience>().GetWaypoints(waypoints[x], x); } }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer") || other.CompareTag("Trigger") && customerSpawnLimit !<= 0) 
        { 
            StartCoroutine(SpawnCustomer());
        }
    }

    IEnumerator SpawnCustomer()
    {
        if(customerSpawnLimit > 0)
        {
            float spawnTime = UnityEngine.Random.Range(minSpawnTimer, maxSpawnTimer);
            customerVariant = UnityEngine.Random.Range(0, customerType.Length - 1);
            yield return new WaitForSeconds(spawnTime);

            GameObject customer = Instantiate(customerType[customerVariant]);
            AudioManager.instance.PlayOneShot(FModEvents.instance.customerSpawn, this.transform.position);
            //Debug.Log(customerVariant);
            customer.transform.position = spawn.position;
            if(customerSpawnLimit <= 0) { Destroy(customer); }
            //customerSpawnLimit--;
        } 
    }
}
