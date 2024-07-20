using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class CustomerPatience : MonoBehaviour
{
    [SerializeField] private float patience;

    private float patienceTimer; 
    private Image patienceBar;
    private void Awake()
    {
        patienceBar = GetComponent<Image>(); 

    }
    private void Start()
    {
        patienceTimer = patience; 
        patienceBar = GetComponent<Image>();
    }

    void Update()
    {
        if(patience >= 0)
        {
            patienceTimer -= Time.deltaTime * 1;
            patienceBar.fillAmount = patienceTimer / patience;
        }       
    }


}
