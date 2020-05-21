using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public int tutorialStep = 0;
    private GameObject tutorialButton1;
    private GameObject tutorialButton2;
    private GameObject tutorialButton3;
    private GameObject tutorialButton4;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton1 = GameObject.Find("TutorialButton1");
        tutorialButton2 = GameObject.Find("TutorialButton2");
        tutorialButton3 = GameObject.Find("TutorialButton3");
        tutorialButton4 = GameObject.Find("TutorialButton4");
        tutorialButton1.SetActive(true);
        tutorialButton2.SetActive(false);
        tutorialButton3.SetActive(false);
        tutorialButton4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialStep)
        {
            case 1:
                tutorialButton2.SetActive(true);
                break;
            case 2:
                tutorialButton3.SetActive(true);
                break;
            case 3:
                tutorialButton4.SetActive(true);
                break;
        }
    }
}
