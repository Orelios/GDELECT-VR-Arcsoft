using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private float[] spawnIntervals;
    private float timer;
    private int spawner; 
    void Start()
    {
        timer = 0; 
        spawner = 0;
        for (int x = 0; x < spawners.Length; x++) 
        { spawners[x].GetComponent<CustomerSpawner>().enabled = false; }
        
    }

    private void Update()
    {
        SpawnIntervals(); 
    }

    private void SpawnIntervals()
    {
        timer += Time.deltaTime;
        MakeSpawnersActive();
    }

    private void MakeSpawnersActive()
    {
        if (timer <= spawnIntervals[3])
        {
            if (timer <= spawnIntervals[0])
            {
                Debug.Log("1");
                for (int x = 0; x < 3; x++)
                {
                    if (spawner != 2)
                    {
                        spawners[spawner].GetComponent<CustomerSpawner>().enabled = true;
                        spawner++;
                    }

                }

            }
            else if (timer <= spawnIntervals[1])
            {
                Debug.Log("2");
                for (int x = 0; x < 3; x++)
                {
                    if (spawner != 6)
                    {
                        spawners[spawner].GetComponent<CustomerSpawner>().enabled = true;
                        spawner++;
                    }
                }
            }
            else if (timer <= spawnIntervals[2])
            {
                Debug.Log("3");
                for (int x = 0; x < 3; x++)
                {
                    if (spawner != 9)
                    {
                        spawners[spawner].GetComponent<CustomerSpawner>().enabled = true;
                        spawner++;
                    }
                }
            }
            else if (timer <= spawnIntervals[3])
            {
                Debug.Log("4");
                for (int x = 0; x < 3; x++)
                {
                    if (spawner != 12)
                    {
                        spawners[spawner].GetComponent<CustomerSpawner>().enabled = true;
                        spawner++;
                    }
                }
            }
        }
        else { GetComponent<CustomerWaveSpawner>().enabled = false; }
    }
}
