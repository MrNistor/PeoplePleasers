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

    private GameObject personSpawner0;
    private GameObject personSpawnerButton0;
    private GameObject personSpawner1;
    private GameObject personSpawnerButton1;

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

        personSpawner0 = GameObject.Find("PersonSpawner(0)");
        personSpawner1 = GameObject.Find("PersonSpawner (1)");
        personSpawner0.SetActive(false);
        personSpawner1.SetActive(false);
        personSpawnerButton0 = GameObject.Find("LSpawnButton");
        personSpawnerButton1 = GameObject.Find("RSpawnButton");
        personSpawnerButton0.SetActive(false);
        personSpawnerButton1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialStep)
        {
            case -1:
                tutorialButton1.SetActive(false);
                tutorialButton2.SetActive(false);
                tutorialButton3.SetActive(false);
                tutorialButton4.SetActive(false);
                personSpawner0.SetActive(true);
                personSpawner1.SetActive(true);
                personSpawner0.GetComponent<PersonSpawner>().startPersonSpawn = true;
                personSpawner1.GetComponent<PersonSpawner>().startPersonSpawn = true;
                personSpawnerButton0.SetActive(true);
                personSpawnerButton1.SetActive(true);
                break;
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
