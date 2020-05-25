using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial5Animation : MonoBehaviour
{
    public GameObject tutorial5Person1;
    public GameObject tutorial5Bar1;
    public GameObject tutorial5Fill1;
    public GameObject tutorial5Level1;
    public GameObject tutorial5Person2;
    public GameObject tutorial5Bar2;
    public GameObject tutorial5Fill2;
    public GameObject tutorial5Level2;
    public Text score;

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

    private float origLevelX1 = 0;
    private float origLevelX2 = 0;
    private float levelX1 = 0;
    private float levelX2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        personX1 = tutorial5Person1.GetComponent<Transform>().position.x;
        personX2 = tutorial5Person2.GetComponent<Transform>().position.x;
        personY = tutorial5Person1.GetComponent<Transform>().position.y;
        personZ = tutorial5Person1.GetComponent<Transform>().position.z;
        origPersonX1 = personX1;
        origPersonX2 = personX2;

        barX1 = tutorial5Bar1.GetComponent<Transform>().position.x;
        barX2 = tutorial5Bar2.GetComponent<Transform>().position.x;
        barY = tutorial5Bar1.GetComponent<Transform>().position.y;
        barZ = tutorial5Bar1.GetComponent<Transform>().position.z;
        origBarX1 = barX1;
        origBarX2 = barX2;

        fillX1 = tutorial5Fill1.GetComponent<RectTransform>().position.x;
        fillX2 = tutorial5Fill2.GetComponent<RectTransform>().position.x;
        fillY = tutorial5Fill1.GetComponent<RectTransform>().position.y;
        fillZ = tutorial5Fill1.GetComponent<RectTransform>().position.z;
        origFillX1 = fillX1;
        origFillX2 = fillX2;

        fillWidth1 = tutorial5Fill1.GetComponent<RectTransform>().sizeDelta.x;
        fillWidth2 = tutorial5Fill2.GetComponent<RectTransform>().sizeDelta.x;
        fillHeight = tutorial5Fill1.GetComponent<RectTransform>().sizeDelta.y;
        origFillWidth1 = fillWidth1;
        origFillWidth2 = fillWidth2;

        levelX1 = tutorial5Level1.GetComponent<Transform>().position.x;
        levelX2 = tutorial5Level2.GetComponent<Transform>().position.x;
        origLevelX1 = levelX1;
        origLevelX2 = levelX2;
    }

    // Update is called once per frame
    void Update()
    {
        personX1 += Time.deltaTime * 3;
        personX2 += Time.deltaTime * 3;
        barX1 += Time.deltaTime * 3;
        barX2 += Time.deltaTime * 3;
        levelX1 += Time.deltaTime * 3;
        levelX2 += Time.deltaTime * 3;
        fillX1 += Time.deltaTime * 2.84f;
        fillWidth1 -= 0.5f;
        fillX2 += Time.deltaTime * 2.84f;
        fillWidth2 -= 0.5f;
        
        tutorial5Person1.GetComponent<Transform>().position = new Vector3(personX1, personY, personZ);
        tutorial5Person2.GetComponent<Transform>().position = new Vector3(personX2, personY, personZ);
        tutorial5Bar1.GetComponent<Transform>().position = new Vector3(barX1, barY, barZ);
        tutorial5Bar2.GetComponent<Transform>().position = new Vector3(barX2, barY, barZ);
        tutorial5Fill1.GetComponent<RectTransform>().position = new Vector3(fillX1, fillY, fillZ);
        tutorial5Fill2.GetComponent<RectTransform>().position = new Vector3(fillX2, fillY, fillZ);
        tutorial5Fill1.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth1, fillHeight);
        tutorial5Fill2.GetComponent<RectTransform>().sizeDelta = new Vector2(fillWidth2, fillHeight);
        tutorial5Level1.GetComponent<Transform>().position = new Vector3(levelX1, barY, barZ);
        tutorial5Level2.GetComponent<Transform>().position = new Vector3(levelX2, barY, barZ);

        if (personX2 >= 1.5)
            score.text = "Score: 1";

        if (personX2 > 7f)
        {
            personX1 = origPersonX1;
            barX1 = origBarX1;
            fillX1 = origFillX1;
            fillWidth1 = origFillWidth1;
            levelX1 = origLevelX1;

            personX2 = origPersonX2;
            barX2 = origBarX2;
            fillX2 = origFillX2;
            fillWidth2 = origFillWidth2;
            levelX2 = origLevelX2;

            score.text = "Score: 0";
        }
    }

    public void Tutorial5Done()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
