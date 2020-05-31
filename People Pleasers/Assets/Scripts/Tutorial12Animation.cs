using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial12Animation : MonoBehaviour
{
    public GameObject spawnButton;
    public GameObject person1;
    public GameObject person2;
    public GameObject person3;

    private float origPersonX1 = 0;
    private float origPersonX2 = 0;
    private float origPersonX3 = 0;

    private float personX1 = 0;
    private float personX2 = 0;
    private float personX3 = 0;
    private float personY = 0;
    private float personZ = 0;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        personX1 = person1.GetComponent<Transform>().position.x;
        personX2 = person2.GetComponent<Transform>().position.x;
        personX3 = person3.GetComponent<Transform>().position.x;
        personY = person1.GetComponent<Transform>().position.y;
        personZ = person1.GetComponent<Transform>().position.z;

        origPersonX1 = personX1;
        origPersonX2 = personX2;
        origPersonX3 = personX3;

        person1.SetActive(false);
        person2.SetActive(false);
        person3.SetActive(false);
        spawnButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1f)
        {
            person1.SetActive(true);
            person2.SetActive(true);
            person3.SetActive(true);
            spawnButton.SetActive(false);

            personX1 += Time.deltaTime * 3;
            personX2 += Time.deltaTime * 3;
            personX3 += Time.deltaTime * 3;
        }
        else
        {
            person1.SetActive(false);
            person2.SetActive(false);
            person3.SetActive(false);
            spawnButton.SetActive(true);
            timer += Time.deltaTime;
        }

        person1.GetComponent<Transform>().position = new Vector3(personX1, personY, personZ);
        person2.GetComponent<Transform>().position = new Vector3(personX2, personY, personZ);
        person3.GetComponent<Transform>().position = new Vector3(personX3, personY, personZ);

        if (personX3 > 5f)
        {
            personX1 = origPersonX1;
            personX2 = origPersonX2;
            personX3 = origPersonX3;
            timer = 0f;
        }
    }

    public void Tutorial12Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController2>().tutorialStep = -1;
        gameObject.SetActive(false);
    }
}
