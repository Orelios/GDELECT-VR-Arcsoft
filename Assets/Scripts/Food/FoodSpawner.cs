using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; 
    [SerializeField] private Transform spawnPoint; 
    private GameObject currentItem; 

    private void Start()
    {
        SpawnItem(); 
    }

    private void SpawnItem()
    {
        currentItem = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.gameObject == currentItem && 
            other.gameObject.GetComponent<Plate>() == null && 
            other.gameObject.GetComponent<FireProjectile>() == null) { SpawnItem(); Debug.Log("plate1"); }

        if(other.gameObject.GetComponent<Plate>() != null) { SpawnItem(); Debug.Log("plate2"); }
    }
}
