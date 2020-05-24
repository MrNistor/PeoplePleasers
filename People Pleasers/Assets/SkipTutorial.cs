using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorial : MonoBehaviour
{
    public void SkipTutorialButton()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep = -1;
        gameObject.SetActive(false);
    }
}
