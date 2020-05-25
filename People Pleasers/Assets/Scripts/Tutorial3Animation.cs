using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3Animation : MonoBehaviour
{
    public GameObject tutorial3Person1;
    public GameObject tutorial3Bar1;
    public GameObject tutorial3Fill1;
    public GameObject tutorial3Person2;
    public GameObject tutorial3Bar2;
    public GameObject tutorial3Fill2;

    private float origPersonX1 = 0;
    private float origPersonX2 = 0;
    private float personX1 = 0;
    private float personX2 = 0;
    private float personY = 0;
    private float personZ = 0;

    private float origBarX1 = 0;
    private float origBarX2 = 0;
    private float barX1 = 0;
    private float barX2 = 0;
    private float barY = 0;
    private float barZ = 0;

    private float origFillX1 = 0;
    private float origFillX2 = 0;
    private float fillX1 = 0;
    private float fillX2 = 0;
    private float fillY = 0;
    private float fillZ = 0;

    private float origFillWidth1 = 0;
    private float origFillWidth2 = 0;
    private float fillWidth1 = 0;
    private float fillWidth2 = 0;
    private float fillHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        personX1 = tutorial3Person1.GetComponent<Transform>().position.x;
        personX2 = tutorial3Person2.GetComponent<Transform>().position.x;
        personY = tutorial3Person1.GetComponent<Transform>().position.y;
        personZ = tutorial3Person1.GetComponent<Transform>().position.z;
        origPersonX1 = personX1;
        origPersonX2 = personX2;

        barX1 = tutorial3Bar1.GetComponent<Transform>().position.x;
        barX2 = tutorial3Bar2.GetComponent<Transform>().position.x;
        barY = tutorial3Bar1.GetComponent<Transform>().position.y;
        barZ = tutorial3Bar1.GetComponent<Transform>().position.z;
        origBarX1 = barX1;
        origBarX2 = barX2;

        fillX1 = tutorial3Fill1.GetComponent<RectTransform>().position.x;
        fillX2 = tutorial3Fill2.GetComponent<RectTransform>().position.x;
        fillY = tutorial3Fill1.GetComponent<RectTransform>().position.y;
        fillZ = tutorial3Fill1.GetComponent<RectTransform>().position.z;
        origFillX1 = fillX1;
        origFillX2 = fillX2;

        fillWidth1 = tutorial3Fill1.GetComponent<RectTransform>().sizeDelta.x;
        fillWidth2 = tutorial3Fill2.GetComponent<RectTransform>().sizeDelta.x;
        fillHeight = tutorial3Fill1.GetComponent<RectTransform>().sizeDelta.y;
        origFillWidth1 = fillWidth1;
        origFillWidth2 = fillWidth2;
    }

    // Update is called once per frame
    void Update()
    {
        personX1 += Time.deltaTime * 3;
        personX2 += Time.deltaTime * 3;
        barX1 += Time.deltaTime * 3;
        barX2 += Time.deltaTime * 3;

        if (personX1 >= -1.29 && personX1 <= 4.8)
        {
            fillX1 += Time.deltaTime * 3.08f;
            fillWidth1 += 0.2f;
        }
        else
        {
            fillX1 += Time.deltaTime * 2.84f;
            fillWidth1 -= 0.5f;
        }

        if (personX2 >= -1.29 && personX2 <= 4.8)
        {
            fillX2 += Time.deltaTime * 3.08f;
            fillWidth2 += 0.2f;
        }
        else
        {
            fillX2 += Time.deltaTime * 2.84f;
            fillWidth2 -= 0.5f;
        }
        
        tutorial3Person1.GetComponent<Transform>().position = new Vector3(personX1, personY, personZ);
        tutorial3Person2.GetComponent<Transform>().position = new Vector3(personX2, personY, personZ);
        tutorial3Bar1.GetComponent<Transform>().position = new Vector3(barX1, barY, barZ);
        tutorial3Bar2.GetComponent<Transform>().position = new Vector3(barX2, barY, barZ);
        tutorial3Fill1.GetComponent<RectTransform>().position = new Vector3(fillX1, fillY, fillZ);
        tutorial3Fill2.GetComponent<RectTransform>().position = new Vector3(fillX2, fillY, fillZ);
        tutorial3Fill1.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth1, fillHeight);
        tutorial3Fill2.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth2, fillHeight);

        if (personX2 > 7f)
        {
            personX1 = origPersonX1;
            barX1 = origBarX1;
            fillX1 = origFillX1;
            fillWidth1 = origFillWidth1;

            personX2 = origPersonX2;
            barX2 = origBarX2;
            fillX2 = origFillX2;
            fillWidth2 = origFillWidth2;
        }
    }

    public void Tutorial3Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
