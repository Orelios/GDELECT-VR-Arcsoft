using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int[] scoresToAdd; 
    [SerializeField]private int score;
    [SerializeField]private int bonusMultiplier; 

    private void Start() //Add text component once ma figure out ang canvas situation
    {
        score = 0;
        bonusMultiplier = 1; 
    }

    public void RecievePoints(float barPercentage)
    {
        if(barPercentage <= 1) { score += scoresToAdd[0] * bonusMultiplier; }
        else if(barPercentage <= 0.75) { score += scoresToAdd[0] * bonusMultiplier; }
        else if(barPercentage <= 0.50) { score += scoresToAdd[0] * bonusMultiplier; }
        else if(barPercentage <= 0.25) { score += scoresToAdd[0] * bonusMultiplier; }
    }

    public void MultiplierActive() { bonusMultiplier = 2; }
    public void MultiplierInactive() { bonusMultiplier = 1; } 
}
