using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public int tutorialStep = 0;

    private GameObject tutorial1;
    private GameObject tutorial2;
    private GameObject tutorial3;
    private GameObject tutorial4;
    private GameObject tutorial5;
    private GameObject tutorial6;
    private GameObject tutorial7;
    private GameObject tutorial72;

    private GameObject tutorialTitle;
    private GameObject skipButton;

    private GameObject personSpawner0;
    private GameObject personSpawnerButton0;
    private GameObject personSpawner1;
    private GameObject personSpawnerButton1;

    // Start is called before the first frame update
    void Start()
    {
        tutorial1 = GameObject.Find("Tutorial1");
        tutorial2 = GameObject.Find("Tutorial2");
        tutorial3 = GameObject.Find("Tutorial3");
        tutorial4 = GameObject.Find("Tutorial4");
        tutorial5 = GameObject.Find("Tutorial5");
        tutorial6 = GameObject.Find("Tutorial6");
        tutorial7 = GameObject.Find("Tutorial7");
        tutorial72 = GameObject.Find("Tutorial7-2");

        tutorialTitle = GameObject.Find("TutorialTitle");
        skipButton = GameObject.Find("SkipButton");

        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        tutorial6.SetActive(false);
        tutorial7.SetActive(false);
        tutorial72.SetActive(false);
        tutorialTitle.SetActive(true);

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
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                tutorial5.SetActive(false);
                tutorial6.SetActive(false);
                tutorial7.SetActive(false);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(false);
                skipButton.SetActive(false);
                personSpawner0.SetActive(true);
                personSpawner1.SetActive(true);
                personSpawner0.GetComponent<PersonSpawner>().startPersonSpawn = true;
                personSpawner1.GetComponent<PersonSpawner>().startPersonSpawn = true;
                personSpawnerButton0.SetActive(true);
                personSpawnerButton1.SetActive(true);
                break;
            case 1:
                tutorial1.SetActive(false);
                tutorial2.SetActive(true);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                tutorial5.SetActive(false);
                tutorial6.SetActive(false);
                tutorial7.SetActive(false);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(true);
                break;
            case 2:
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(true);
                tutorial4.SetActive(false);
                tutorial5.SetActive(false);
                tutorial6.SetActive(false);
                tutorial7.SetActive(false);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(true);
                break;
            case 3:
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(true);
                tutorial5.SetActive(false);
                tutorial6.SetActive(false);
                tutorial7.SetActive(false);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(true);
                break;
            case 4:
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                tutorial5.SetActive(true);
                tutorial6.SetActive(false);
                tutorial7.SetActive(false);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(true);
                break;
            case 5:
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                tutorial5.SetActive(false);
                tutorial6.SetActive(true);
                tutorial7.SetActive(false);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(false);
                break;
            case 6:
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                tutorial5.SetActive(false);
                tutorial6.SetActive(false);
                tutorial7.SetActive(true);
                tutorial72.SetActive(false);
                tutorialTitle.SetActive(false);
                break;
            case 7:
                tutorial1.SetActive(false);
                tutorial2.SetActive(false);
                tutorial3.SetActive(false);
                tutorial4.SetActive(false);
                tutorial5.SetActive(false);
                tutorial6.SetActive(false);
                tutorial7.SetActive(false);
                tutorial72.SetActive(true);
                tutorialTitle.SetActive(false);
                break;
        }
    }
}
