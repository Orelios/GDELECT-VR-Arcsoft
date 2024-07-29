using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] Transform spawnPosition;
    [SerializeField] private int spawnCooldown; 

    private void Start(){ StartCoroutine(SpawnFood()); }
    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Food>()!= null || other.GetComponent<Plate>() != null) 
        { StartCoroutine(SpawnFood()); }      
    }

    IEnumerator SpawnFood() 
    {
        yield return new WaitForSeconds(spawnCooldown); 
        GameObject food = Instantiate(this.food);
        food.transform.position = spawnPosition.position; 
    }
}
