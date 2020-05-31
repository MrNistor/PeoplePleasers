using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial11Animation : MonoBehaviour
{
    public void Tutorial11Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController2>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
