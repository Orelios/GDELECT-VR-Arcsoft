using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireProjectile : MonoBehaviour
{
    public GameObject food;
    public Transform spawnPoint;
    public float objectSpeed; 

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire); 
    }
    public void Fire(ActivateEventArgs args)
    {
        GameObject spawnedFood = Instantiate(food);
        spawnedFood.transform.position = spawnPoint.position;
        spawnedFood.GetComponent<Rigidbody>().velocity = spawnPoint.forward * objectSpeed;
        Destroy(food, 3); 
    }
}
