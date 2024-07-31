using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

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
        if (GetComponent<Plate>() != null) {
            
        }
        GameObject spawnedFood = Instantiate(gameObject);
        //Destroy(spawnedFood.GetComponent<XRGrabInteractable>());
        //Destroy(spawnedFood.GetComponent<XRGeneralGrabTransformer>());
        spawnedFood.transform.position = spawnPoint.position;
        spawnedFood.GetComponent<Rigidbody>().velocity = spawnPoint.forward * objectSpeed;
        Destroy(gameObject);

    }
}
