using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTower : MonoBehaviour
{
    public float coolDown = 1;
    public float cooldownTimer;

    public float maxDistirubtionPower = 0.3f;
    private bool hasDected = false;
    private int detectNumberInRange = 0;
    
    /// <summary>
    /// Increase number of count Hot person enter to tower
    /// </summary>
    /// <param name="other"></param>
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

    /// <summary>
    /// Calculate happiness distribution based on the number in tower range 
    /// </summary>
    /// <param name="other"></param>
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

    /// <summary>
    /// Decrease the number of Hot person when it leave the tower
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exited");
        detectNumberInRange--;
        //Debug.Log("Exited After Got out: " + detectNumberInRange);
    }
}
