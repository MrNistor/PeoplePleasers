﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject ui_prefab;
    public Button rangeButton;
    public Button happyButton;
    public GameObject range;

    // Start is called before the first frame update
    void Start()
    {
        ui_prefab = transform.GetChild(1).gameObject;
        //rangeButton = ui_prefab.transform.Find("RangeButton").GetComponent<Button>();
        rangeButton = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        rangeButton.onClick.AddListener(UpgradeRange);
        happyButton = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Button>();
        happyButton.onClick.AddListener(UpgradeHappy);
        range = this.transform.GetChild(0).gameObject;
        //ui_prefab = GameObject.Find("UI_Shop");
        // ui_prefab.SetActive(false);

        //ui_prefab.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ui_prefab.gameObject.SetActive(true);
        }
        
    }

    public void Clicked()
    {
        //ui_prefab.SetActive(true);
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ui_prefab.gameObject.SetActive(true);
        }
    }

    void UpgradeRange()
    {
        range.transform.localScale *= 2;
    }

    void UpgradeHappy()
    {
        string towerName = this.name.Substring(0, name.Length - 11);
        BurgerTower bTower;
        FanTower fTower;
        DrinkTower dTower;
        EntertainTower eTower;


        if (towerName == "Food")
        {
            bTower = range.GetComponent<BurgerTower>();
            bTower.maxDistirubtionPower *= 2;
        }
        else if (towerName == "Fan")
        {
            fTower = range.GetComponent<FanTower>();
            fTower.maxDistirubtionPower *= 2;
        }
        else if (towerName == "Drink")
        {
            dTower = range.GetComponent<DrinkTower>();
            dTower.maxDistirubtionPower *= 2;
        }
        else if (towerName == "Entertainment")
        {
            eTower = range.GetComponent<EntertainTower>();
            eTower.maxDistirubtionPower *= 2;
        }
        
    }

}
