using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntertainTower : MonoBehaviour
{
    public float coolDown = 1;
    public float cooldownTimer;

    public float maxDistirubtionPower = 0.3f;
    private bool hasDected = false;
    private int detectNumberInRange = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bored"))
        {
            hasDected = true;
            detectNumberInRange++;
            var happinessMeter = other.GetComponent<PersonHappiness>();
            happinessMeter.inTowerRange = true;
        }
        else
        {
            //hasDected = false;
            //Debug.Log("has Dected: " + hasDected);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bored"))
        {
            var happinessMeter = other.GetComponent<PersonHappiness>();
            var calculateDistribution = maxDistirubtionPower / detectNumberInRange;
            happinessMeter.RestoreHappiness((calculateDistribution));
            happinessMeter.inTowerRange = true;
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
        if (collision.gameObject.name.Contains("Bored"))
        {
            detectNumberInRange--;
            var happinessMeter = collision.GetComponent<PersonHappiness>();
            happinessMeter.inTowerRange = false;
        }
        //Debug.Log("Exited After Got out: " + detectNumberInRange);
    }
}
