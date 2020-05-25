using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial8Animation : MonoBehaviour
{
    public GameObject tutorialButton1;
    public GameObject tutorialButton2;
    private bool secondButtonActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton1 = GameObject.Find("Tutorial8Button1");
        tutorialButton2 = GameObject.Find("Tutorial8Button2");
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

    public void Tutorial8Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController2>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
