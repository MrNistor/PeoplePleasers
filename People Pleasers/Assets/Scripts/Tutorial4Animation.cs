using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial4Animation : MonoBehaviour
{
    public GameObject tutorial4Person;
    public GameObject tutorial4Bar;
    public GameObject tutorial4Fill;

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

    private Color origColor;

    // Start is called before the first frame update
    void Start()
    {
        personX = tutorial4Person.GetComponent<Transform>().position.x;
        personY = tutorial4Person.GetComponent<Transform>().position.y;
        personZ = tutorial4Person.GetComponent<Transform>().position.z;
        origPersonX = personX;

        barX = tutorial4Bar.GetComponent<Transform>().position.x;
        barY = tutorial4Bar.GetComponent<Transform>().position.y;
        barZ = tutorial4Bar.GetComponent<Transform>().position.z;
        origBarX = barX;

        fillX = tutorial4Fill.GetComponent<RectTransform>().position.x;
        fillY = tutorial4Fill.GetComponent<RectTransform>().position.y;
        fillZ = tutorial4Fill.GetComponent<RectTransform>().position.z;
        origFillX = fillX;

        fillWidth = tutorial4Fill.GetComponent<RectTransform>().sizeDelta.x;
        fillHeight = tutorial4Fill.GetComponent<RectTransform>().sizeDelta.y;
        origFillWidth = fillWidth;

        origColor = tutorial4Person.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        personX += Time.deltaTime * 3;
        barX += Time.deltaTime * 3;

        if (fillWidth > 0)
        {
            fillX += Time.deltaTime * 2.84f;
            fillWidth -= 0.5f;
        }
        else
        {
            fillX += Time.deltaTime * 3f;
            fillWidth = 0f;
            tutorial4Person.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        
        tutorial4Person.GetComponent<Transform>().position = new Vector3(personX, personY, personZ);
        tutorial4Bar.GetComponent<Transform>().position = new Vector3(barX, barY, barZ);
        tutorial4Fill.GetComponent<RectTransform>().position = new Vector3(fillX, fillY, fillZ);
        tutorial4Fill.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth, fillHeight);
        
        if (personX > 7f)
        {
            personX = origPersonX;
            barX = origBarX;
            fillX = origFillX;
            fillWidth = origFillWidth;
            tutorial4Person.GetComponent<SpriteRenderer>().color = origColor;
        }
    }

    public void Tutorial4Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
