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

    //button text
    public Text rangeLevel;
    public Text happyLevel;

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

    //score manager for upgrade menu
    public ScoreManager sMan;

    // hold tower coordinates
    private Vector3[] v = new Vector3[4];
    private float vMinX = 0f;
    private float vMaxX = 0f;
    private float vMinY = 0f;
    private float vMaxY = 0f;

    private Vector3 mousePosition;  // get mouse position
    private float delayTimer = 0f;  // delay for mouse click when tower first placed

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

        rangeLevel = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>();
        happyLevel = ui_prefab.transform.GetChild(0).GetChild(0).GetChild(9).GetComponent<Text>();

        moneyObj = GameObject.Find("SpawnCanvas").transform.GetChild(2).gameObject;
        moneyAmount = float.Parse(moneyObj.GetComponent<Text>().text);


        range = transform.GetChild(0).gameObject;
        rangeAmount = range.transform.localScale.x / 2f;

        //upgrade trackers
        rangeUpgradeCount = 0;
        happyUpgradeCount = 0;

        //score manager
        sMan = GameObject.Find("GameManager").GetComponent<ScoreManager>();

        // get tower coordinates to check if mouse clicked on tower        
        GetTowerCoordinateRange();
    }

    // get max and min X and Y coordinates usd to check if mouse is within range
    void GetTowerCoordinateRange()
    {
        GetComponent<RectTransform>().GetWorldCorners(v);
        vMinX = v[0].x;
        vMaxX = vMinX;
        vMinY = v[0].y;
        vMaxY = vMinY;
        for (var i = 1; i < 4; i++)
        {
            if (v[i].x < vMinX)
                vMinX = v[i].x;
            if (v[i].x > vMaxX)
                vMaxX = v[i].x;
            if (v[i].y < vMinY)
                vMinY = v[i].y;
            if (v[i].y > vMaxY)
                vMaxY = v[i].y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // delay timer so upgrade menu not displayed once tower is placed
        if (delayTimer < 0.5f)
            delayTimer += Time.deltaTime;
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (mousePosition.x > vMinX && mousePosition.x < vMaxX && mousePosition.y > vMinY && mousePosition.y < vMaxY)
                {
                    OnMouseDownTower();
                }
            }
        }
        // change color of tower on mouse hover
        if (mousePosition.x > vMinX && mousePosition.x < vMaxX && mousePosition.y > vMinY && mousePosition.y < vMaxY)
        {
            OnMouseOverTower();
        }
        else
        {
            OnMouseExitTower();
        }
    }

    void OnMouseDownTower() {
        if (ui_prefab.activeSelf == false)
        {
            ui_prefab.gameObject.SetActive(true);
            sMan.closeOldUpgradeMenu(ui_prefab);
        }
        
    }

    void OnMouseExitTower() {
        //Debug.Log("mouse exit");
        sprite.color = startColor;
    }

    void OnMouseOverTower() {
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
        if (rangeUpgradeCount < 2)
        {
            range.transform.localScale += new Vector3(rangeAmount, rangeAmount, range.transform.localScale.z);
            ++rangeUpgradeCount;
            rangeLevel.text = "Level " + (rangeUpgradeCount + 1);
            float upgradeCost = -50f;
            //moneyAmount -= 60f;
            UpdateMoney(upgradeCost);
        }

        if (rangeUpgradeCount == 2)
        {
            rangeLevel.text = "Max Level";
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
            happyLevel.text = "Level " + (happyUpgradeCount + 1);
        }
        
        if (happyUpgradeCount == 3)
        {
            happyLevel.text = "Max Level";
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
