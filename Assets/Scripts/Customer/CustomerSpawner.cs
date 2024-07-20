using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customer; 
    public float minSpawnTimer, maxSpawnTimer;

    private static int customerSpawnLimit = 10; 

    private void Start()
    { 
        int spawnCustomerAtStart = UnityEngine.Random.Range(1, 4);
        Debug.Log(spawnCustomerAtStart);
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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer") && customerSpawnLimit != 0) 
        { 
            StartCoroutine(SpawnCustomer());
            customerSpawnLimit --;
            Debug.Log(customerSpawnLimit);
        }
    }

    IEnumerator SpawnCustomer()
    {
        float spawnTime = UnityEngine.Random.Range(minSpawnTimer, maxSpawnTimer);

        yield return new WaitForSeconds(spawnTime);
        
        int customerType = UnityEngine.Random.Range(0, this.customer.Length -2);
        GameObject customer = Instantiate(this.customer[customerType]);
        customer.transform.position = transform.position;        
    }

    IEnumerator SpawnTrigger()
    {
        GameObject customer = Instantiate(this.customer[this.customer.Length - 1]);
        customer.transform.position = transform.position;
        float spawnTime = UnityEngine.Random.Range(minSpawnTimer, maxSpawnTimer);

        yield return new WaitForSeconds(spawnTime);

        customer.transform.position = Vector3.forward;

        yield return new WaitForSeconds(1);

        Destroy(customer); 
    }
}
