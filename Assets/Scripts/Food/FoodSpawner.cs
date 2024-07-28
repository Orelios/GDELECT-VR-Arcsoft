using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] Transform spawnPosition;

    private void Start(){ SpawnFood(); }
    private void OnTriggerExit(Collider other){SpawnFood(); }

    private void SpawnFood() 
    {GameObject food = Instantiate(this.food);
        food.transform.position = spawnPosition.position; }
}
