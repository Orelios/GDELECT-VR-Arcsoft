using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            AudioManager.instance.PlayOneShot(FModEvents.instance.shoot, this.transform.position);
        }
        
    }
}
