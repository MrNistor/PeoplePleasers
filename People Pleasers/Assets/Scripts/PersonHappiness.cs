using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonHappiness : MonoBehaviour
{
    private float maxHappiness = 1.0f;
    public Slider happinessBar;
    public float happyDecreaseAmount = 0.08f;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        happinessBar.value = maxHappiness;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHappiness();
    }

    private void DecreaseHappiness()
    {
        happinessBar.value -= happyDecreaseAmount * Time.deltaTime;
        ChangePersonColor();
    }

    private void ChangePersonColor()
    {
        if (happinessBar.value == 0)
        {
            spriteRenderer.color = Color.black;
        }
    }

}
