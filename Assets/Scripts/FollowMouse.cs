using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera povCam;
    [SerializeField] float zDistanceFromCam = 1f;

    void Start()
    {
        povCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        MoveToMousePosition();
    }

    void MoveToMousePosition()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceFromCam);
        mousePosition = povCam.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
        //mousePosition.z = transform.position.z;
        // transform.position = povCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -povCam.transform.position.z));
    }
}
