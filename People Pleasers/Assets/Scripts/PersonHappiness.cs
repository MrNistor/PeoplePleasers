using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonHappiness : MonoBehaviour
{
    private float maxHappiness = 1.0f;
    public Slider happinessBar;
    public float happyDecreaseAmount = 0.11f;
    private SpriteRenderer spriteRenderer;

    // testing on store happiness values
    // private List<float> happinessStorer;
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

    // method that is being used in HambergerTower
    public void RestoreHappiness(float restoreAmount)
    {
        if (happinessBar.value == 0)
        {
            //...
        }
        else
        {
            happinessBar.value += restoreAmount * Time.fixedDeltaTime;
            //Debug.Log(restoreAmount);
        }
    }
    // testing on store happiness value
    public float GetHappinessValue()
    {
        return happinessBar.value;
    }
}
