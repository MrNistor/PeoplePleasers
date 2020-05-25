using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial6Animation : MonoBehaviour
{
    public GameObject tutorialButton1;
    public GameObject tutorialButton2;
    private bool secondButtonActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton1 = GameObject.Find("Tutorial6Button1");
        tutorialButton2 = GameObject.Find("Tutorial6Button2");
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

    public void Tutorial6Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
