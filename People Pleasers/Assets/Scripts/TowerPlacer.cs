﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TowerPlacer : MonoBehaviour
{
    public TowerCreater towerCreater;
    // for money
    public GameObject moneyObj;

    //public GameObject ui_prefab;    //Angie;s upgrade menu testing
    //private GameObject uiUpgrade;

    private float towerPrice = 80f;
    public float currentMoney;
    //public float currentMoney;    // not sure why made public?
    // for text
    private float speed = 1.0f;
    private float amount = 1.0f;
    private float shakeRange = 20.0f;

    // fix tower placement bug
    private Bounds tileBound;
    private Vector3 mousePoint;

    // Start is called before the first frame update
    void Start()
    {
        // offset everything to ensure all values are positive, otherwise Bounds.Contains() won't work
        tileBound = GetComponent<CircleCollider2D>().bounds;
        tileBound.center = new Vector3(tileBound.center.x + 1000f, tileBound.center.y + 1000f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // detects if mouse pressed on tile
        if (Input.GetMouseButtonUp(0))
        {
            mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePoint.z = 0f;
            mousePoint.x += 1000f;
            mousePoint.y += 1000f;
            if (tileBound.Contains(mousePoint))
            {
                OnMouseDownTile();
            }                
        }
    }

    public void UpdateMoneyText()
    {
        moneyObj.GetComponent<Text>().text = currentMoney.ToString();
    }

    private void ReadCurrentMoney()
    {
        var currencyText = moneyObj.GetComponent<Text>().text;
        float currency = float.Parse(currencyText);
        
        Debug.Log(currency);
        currentMoney = currency;
    }
    
    private IEnumerator MoneyIconShake()
    {
        float elpased = 0.0f;
        Quaternion orginalPos = moneyObj.transform.rotation;

        while (elpased < amount)
        {
            elpased += Time.deltaTime;
            float z = UnityEngine.Random.value * shakeRange - (shakeRange / 2);
            moneyObj.transform.eulerAngles = new Vector3(orginalPos.x, orginalPos.y, orginalPos.z + z);

            yield return null;
        }
        moneyObj.transform.rotation = orginalPos;
    }

    private void OnMouseDownTile()
    {
        Debug.Log("Clicked");
        var selectTowerIndex = RetrieveTower();
        switch (selectTowerIndex)
        {
            case 0:
                PlaceTower(selectTowerIndex);
                break;
            case 1:
                PlaceTower(selectTowerIndex);
                break;
            case 2:
                PlaceTower(selectTowerIndex);
                break;
            case 3:
                PlaceTower(selectTowerIndex);
                break;
            default:
                break;
        }
        
    }

    /// <summary>
    /// Place the tower and make sure player cannot place the tower again 
    /// On the same place
    /// </summary>
    /// <param name="towerNumber"></param>
    private void PlaceTower(int towerNumber)
    {
        ReadCurrentMoney();
        Debug.Log(currentMoney);
        if (transform.childCount == 0)
        {
            if (currentMoney < towerPrice)
            {
                Debug.Log("Not Enough Money");
                HideFollowImages();
                StartCoroutine(MoneyIconShake());
                return;
            }
            else
            {
                currentMoney -= towerPrice;
                UpdateMoneyText();
                HideFollowImages();
            }

            GameObject tower = Instantiate(towerCreater.GetTowerPrefab()[towerNumber], transform.position, Quaternion.identity) as GameObject;
            //uiUpgrade = Instantiate(ui_prefab, transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            //uiUpgrade.transform.SetParent(transform);
            //uiUpgrade.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Tower is already placed on that tile");
            HideFollowImages();
        }
    }

    private void HideFollowImages()
    {
        GameObject.Find("EntertainmentFollow").GetComponent<FollowMouseTower>().HideImage();
        GameObject.Find("FoodFollow").GetComponent<FollowMouseTower>().HideImage();
        GameObject.Find("DrinkFollow").GetComponent<FollowMouseTower>().HideImage();
        GameObject.Find("FanFollow").GetComponent<FollowMouseTower>().HideImage();
    }

    private void BtnClick()
    {
        HideFollowImages();
        towerCreater.SetTowerIndex(-1);
    }
    /// <summary>
    /// Retrieve tower index number from TowerCreater scriptable object
    /// </summary>
    /// <returns></returns>
    private int RetrieveTower()
    {
        
        var towerIndexNum = towerCreater.GetSelectedTower();
        var towerBtnClicked = towerCreater.GetIsTowerBtnClicked();
        Debug.Log(towerBtnClicked);
        Debug.Log(towerIndexNum);
        try
        {
            if (towerIndexNum == -1 || towerBtnClicked == false)
            {
                return -1;
            }
            else
            {
                Debug.Log("From Tower Placer: " + towerIndexNum);
                towerCreater.SetIsTowerBtnClicked(false);
                return towerIndexNum;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Reference Exception: " + e);
        }
        return towerIndexNum;
    }
}
