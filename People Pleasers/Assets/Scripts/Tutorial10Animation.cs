using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial10Animation : MonoBehaviour
{
    public void Tutorial10Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController2>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
