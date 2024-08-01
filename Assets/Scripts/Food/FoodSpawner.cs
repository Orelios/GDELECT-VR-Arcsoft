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
        if (other.gameObject == currentItem){SpawnItem(); }
        if(other.gameObject.GetComponent<Plate>() != null) { SpawnItem(); }
    }
}
