using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject[] crystals;
    [SerializeField] private Material[] materials;
    [SerializeField] private StateManager stateManager;

    private int lives;
    private bool gameOver;

    private void Start()
    {
        lives = 3;
        gameOver = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CustomerOrder>() != null && gameOver == false)
        {
            if(other.GetComponent<CustomerOrder>().IsRightSteak == true
                && other.GetComponent<CustomerOrder>().IsRightSideDish == true) { }
            else
            {
                lives--;
                crystals[lives].GetComponent<MeshRenderer>().material = materials[lives];
                if(lives <= 0)
                {
                    gameOver = true;
                    stateManager.EndGameplay();
                }
            }
        }
        Destroy(other.gameObject);
    }
}
