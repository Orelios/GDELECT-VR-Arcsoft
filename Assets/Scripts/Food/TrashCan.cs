using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Food>() != null || other.GetComponent<Plate>() != null)
        { Destroy(other.gameObject); }
    }
}
