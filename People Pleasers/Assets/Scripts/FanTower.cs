﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTower : MonoBehaviour
{
    public float coolDown = 1;
    public float cooldownTimer;

    public float maxDistirubtionPower = 0.3f;
    private bool hasDected = false;
    private int detectNumberInRange = 0;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Hot"))
        {
            hasDected = true;
            detectNumberInRange++;
        }
        else
        {
            //hasDected = false;
            //Debug.Log("has Dected: " + hasDected);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Hot"))
        {
            var happinessMeter = other.GetComponent<PersonHappiness>();
            var calculateDistribution = maxDistirubtionPower / detectNumberInRange;
            happinessMeter.RestoreHappiness((calculateDistribution));

        }
        else
        {
            //hasDected = false;
            //Debug.Log("has Dected: " + hasDected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exited");
        detectNumberInRange--;
        //Debug.Log("Exited After Got out: " + detectNumberInRange);
    }
}