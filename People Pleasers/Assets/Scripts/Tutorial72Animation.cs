using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial72Animation : MonoBehaviour
{
    public void Tutorial72Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep = -1;
        gameObject.SetActive(false);
    }
}
