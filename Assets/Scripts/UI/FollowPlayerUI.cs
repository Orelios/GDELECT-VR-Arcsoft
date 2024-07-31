using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerUI : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    //[SerializeField] private float distance;

    private void Update()
    {
        transform.position = cameraTransform.position * Time.deltaTime;
        //transform.LookAt(Camera.main.transform.position);
    }

    
}
