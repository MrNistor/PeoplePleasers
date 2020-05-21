using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGlow : MonoBehaviour
{
    private float alpha = 0f;
    private Color imageColor;
    private bool isIncreasing = true;

    // Start is called before the first frame update
    void Start()
    {
        imageColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing)
        {
            alpha += Time.deltaTime;
            if (alpha >= 0.9)
            {
                alpha = 0.9f;
                isIncreasing = false;
            }
        }
        else
        {
            alpha -= Time.deltaTime;
            if (alpha <= 0)
            {
                alpha = 0f;
                isIncreasing = true;
            }
        }
        imageColor.a = alpha;
        GetComponent<Image>().color = imageColor;
    }

    public void PointerEnter()
    {
        GameObject.Find("TutorialCanvas").GetComponent<TutorialController>().tutorialStep++;
        gameObject.SetActive(false);
    }
}
