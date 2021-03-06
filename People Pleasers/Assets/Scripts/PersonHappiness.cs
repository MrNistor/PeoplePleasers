﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonHappiness : MonoBehaviour
{
    private float maxHappiness = 1.0f;
    public Slider happinessBar;
    public Slider happyPointLevel;
    public float happyDecreaseAmount = 0.11f;
    private float happyDecreaseRate = 0.07f;
    private SpriteRenderer spriteRenderer;
    public bool inTowerRange = false;
    

    // testing on store happiness values
    // private List<float> happinessStorer;
    // Start is called before the first frame update
    void Start()
    {
        happinessBar.value = maxHappiness;
        happyPointLevel.value = GameObject.Find("GameManager").GetComponent<ScoreManager>().happinessPercent;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!inTowerRange)
            DecreaseHappiness();
    }

    private void DecreaseHappiness()
    {
        happinessBar.value -= happyDecreaseAmount * happyDecreaseRate;
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
