﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    //buttons
    public Button rangeButton;
    public Button happyButton;
    public Button sellButton;

    //gameObjects
    public GameObject ui_prefab;
    public GameObject range;
    public GameObject moneyObj;

    //color change
    private float rangeAmount;
    public Color startColor;
    public Color mouseOverColor;
    public SpriteRenderer sprite;
    
    //money amount
    public float moneyAmount;

    //money shake
    private float shakeRange = 20f;

    //upgrade trackers
    private float rangeUpgradeCount;
    private float happyUpgradeCount;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        ui_prefab = transform.GetChild(1).gameObject;
        
        //buttons
        rangeButton = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>();
        rangeButton.onClick.AddListener(UpgradeRange);
        happyButton = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Button>();
        happyButton.onClick.AddListener(UpgradeHappy);
        happyButton = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Button>();
        happyButton.onClick.AddListener(SellTower);


        moneyObj = GameObject.Find("SpawnCanvas").transform.GetChild(2).gameObject;
        moneyAmount = float.Parse(moneyObj.GetComponent<Text>().text);


        range = transform.GetChild(0).gameObject;
        rangeAmount = range.transform.localScale.x / 2f;

        //upgrade trackers
        rangeUpgradeCount = 0;
        happyUpgradeCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(1))
        // {
        //     ui_prefab.gameObject.SetActive(true);
        // }
        
    }

    void OnMouseDown() {
        ui_prefab.gameObject.SetActive(true);
    }

    void OnMouseExit() {
        //Debug.Log("mouse exit");
        sprite.color = startColor;
    }

    void OnMouseOver() {
        //Debug.Log("mouse over");
        sprite.color = mouseOverColor;
    }

    // public void OnPointerEnter(PointerEventData pointerEventData)
    // {
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         ui_prefab.gameObject.SetActive(true);
    //     }
    // }

    // //Detect when Cursor leaves the GameObject
    // public void OnPointerExit(PointerEventData pointerEventData)
    // {
    //     //Output the following message with the GameObject's name
    //     Debug.Log("Cursor Exiting ");
    // }

    void UpgradeRange()
    {
        if (rangeUpgradeCount == 0 || rangeUpgradeCount == 1)
        {
            range.transform.localScale += new Vector3(rangeAmount, rangeAmount, range.transform.localScale.z);
            ++rangeUpgradeCount;
            float upgradeCost = -60f;
            //moneyAmount -= 60f;
            UpdateMoney(upgradeCost);
        }
        else
        {
            //max upgrade
        }
    }

    void UpgradeHappy()
    {
        string towerName = this.name.Substring(0, name.Length - 11);
        BurgerTower bTower;
        FanTower fTower;
        DrinkTower dTower;
        EntertainTower eTower;
        float upgradeCost = -40f;

        if (happyUpgradeCount < 3)
        {
            if (towerName == "Food")
            {
                bTower = range.GetComponent<BurgerTower>();
                bTower.maxDistirubtionPower += .2f;
                UpdateMoney(upgradeCost);
            }
            else if (towerName == "Fan")
            {
                fTower = range.GetComponent<FanTower>();
                fTower.maxDistirubtionPower += .2f;
                UpdateMoney(upgradeCost);
            }
            else if (towerName == "Drink")
            {
                dTower = range.GetComponent<DrinkTower>();
                dTower.maxDistirubtionPower += .2f;
                UpdateMoney(upgradeCost);
            }
            else if (towerName == "Entertainment")
            {
                eTower = range.GetComponent<EntertainTower>();
                eTower.maxDistirubtionPower += .2f;
                UpdateMoney(upgradeCost);
            }
            ++happyUpgradeCount;
        }
        else
        {
            //max upgrade
        }
        

    }

    void SellTower()
    {
        Destroy(this.gameObject);
        UpdateMoney(80f);
    }

    void UpdateMoney(float upgradeCost)
    {
        if (moneyAmount + upgradeCost < 0) //not enough money
        {
            StartCoroutine(MoneyIconShake());
        }
        else
        {
            moneyAmount += upgradeCost;
            moneyObj.GetComponent<Text>().text = moneyAmount.ToString();
        }
        
    }

    private IEnumerator MoneyIconShake()
    {
        float elpased = 0.0f;
        Quaternion orginalPos = moneyObj.transform.rotation;

        while (elpased < 1f)
        {
            elpased += Time.deltaTime;
            float z = UnityEngine.Random.value * shakeRange - (shakeRange / 2);
            moneyObj.transform.eulerAngles = new Vector3(orginalPos.x, orginalPos.y, orginalPos.z + z);

            yield return null;
        }
        moneyObj.transform.rotation = orginalPos;
    }

}
