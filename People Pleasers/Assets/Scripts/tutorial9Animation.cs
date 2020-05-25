using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial9Animation : MonoBehaviour
{
    public GameObject tutorialButton1;
    public GameObject tutorialButton2;
    private bool secondButtonActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton1 = GameObject.Find("Tutorial9Button1");
        tutorialButton2 = GameObject.Find("Tutorial9Button2");
        tutorialButton2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialButton1.GetComponent<TutorialGlow>().isActive && !secondButtonActivated)
        {
            secondButtonActivated = true;
            tutorialButton2.SetActive(true);
        }
    }

    public void Tutorial9Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController2>().tutorialStep = -1;
        gameObject.SetActive(false);
    }
}
