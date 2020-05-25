using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2Animation : MonoBehaviour
{
    public GameObject tutorial2Person;
    public GameObject tutorial2Bar;
    public GameObject tutorial2Fill;

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
        personX = tutorial2Person.GetComponent<Transform>().position.x;
        personY = tutorial2Person.GetComponent<Transform>().position.y;
        personZ = tutorial2Person.GetComponent<Transform>().position.z;
        origPersonX = personX;

        barX = tutorial2Bar.GetComponent<Transform>().position.x;
        barY = tutorial2Bar.GetComponent<Transform>().position.y;
        barZ = tutorial2Bar.GetComponent<Transform>().position.z;
        origBarX = barX;

        fillX = tutorial2Fill.GetComponent<RectTransform>().position.x;
        fillY = tutorial2Fill.GetComponent<RectTransform>().position.y;
        fillZ = tutorial2Fill.GetComponent<RectTransform>().position.z;
        origFillX = fillX;

        fillWidth = tutorial2Fill.GetComponent<RectTransform>().sizeDelta.x;
        fillHeight = tutorial2Fill.GetComponent<RectTransform>().sizeDelta.y;
        origFillWidth = fillWidth;
    }

    // Update is called once per frame
    void Update()
    {
        personX += Time.deltaTime * 3;
        barX += Time.deltaTime * 3;

        if (personX >= -1.29 && personX <= 4.8)
        {
            fillX += Time.deltaTime * 3.15f;
            fillWidth += 0.5f;
        }
        else
        {
            fillX += Time.deltaTime * 2.84f;
            fillWidth -= 0.5f;
        }
        
        tutorial2Person.GetComponent<Transform>().position = new Vector3(personX, personY, personZ);
        tutorial2Bar.GetComponent<Transform>().position = new Vector3(barX, barY, barZ);
        tutorial2Fill.GetComponent<RectTransform>().position = new Vector3(fillX, fillY, fillZ);
        tutorial2Fill.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth, fillHeight);
        
        if (personX > 7f)
        {
            personX = origPersonX;
            barX = origBarX;
            fillX = origFillX;
            fillWidth = origFillWidth;
        }
    }

    public void Tutorial2Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
