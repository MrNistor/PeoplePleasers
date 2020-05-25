using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial1Animation : MonoBehaviour
{
    public GameObject tutorial1Person;
    public GameObject tutorial1Bar;
    public GameObject tutorial1Fill;

    private float origPersonX = 0;
    private float personX = 0;
    private float personY = 0;
    private float personZ = 0;

    private float origBarX = 0;
    private float barX = 0;
    private float barY = 0;
    private float barZ = 0;

    private float origFillX = 0;
    private float fillX = 0;
    private float fillY = 0;
    private float fillZ = 0;

    private float origFillWidth = 0;
    private float fillWidth = 0;
    private float fillHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        personX = tutorial1Person.GetComponent<Transform>().position.x;
        personY = tutorial1Person.GetComponent<Transform>().position.y;
        personZ = tutorial1Person.GetComponent<Transform>().position.z;
        origPersonX = personX;

        barX = tutorial1Bar.GetComponent<Transform>().position.x;
        barY = tutorial1Bar.GetComponent<Transform>().position.y;
        barZ = tutorial1Bar.GetComponent<Transform>().position.z;
        origBarX = barX;

        fillX = tutorial1Fill.GetComponent<RectTransform>().position.x;
        fillY = tutorial1Fill.GetComponent<RectTransform>().position.y;
        fillZ = tutorial1Fill.GetComponent<RectTransform>().position.z;
        origFillX = fillX;

        fillWidth = tutorial1Fill.GetComponent<RectTransform>().sizeDelta.x;
        fillHeight = tutorial1Fill.GetComponent<RectTransform>().sizeDelta.y;
        origFillWidth = fillWidth;

    }

    // Update is called once per frame
    void Update()
    {
        personX += Time.deltaTime * 3;
        barX += Time.deltaTime * 3;
        fillX += Time.deltaTime * 2.84f;
        fillWidth -= 0.5f;
        tutorial1Person.GetComponent<Transform>().position = new Vector3(personX, personY, personZ);
        tutorial1Bar.GetComponent<Transform>().position = new Vector3(barX, barY, barZ);
        tutorial1Fill.GetComponent<RectTransform>().position = new Vector3(fillX, fillY, fillZ);
        tutorial1Fill.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth, fillHeight);
        if (personX > 7f)
        {
            personX = origPersonX;
            barX = origBarX;
            fillX = origFillX;
            fillWidth = origFillWidth;
        }
    }

    public void Tutorial1Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
