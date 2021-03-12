using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCards : MonoBehaviour
{
    public int maxPowerUpCount;
    private int powerUpCount;

    private void Start()
    {
        powerUpCount = maxPowerUpCount;
    }
    public void AddPowerUp()
    {      
        Debug.Log("ass");
        powerUpCount--;
        if (powerUpCount <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
