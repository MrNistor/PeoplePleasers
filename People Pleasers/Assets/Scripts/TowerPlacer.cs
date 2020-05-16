using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerPlacer : MonoBehaviour
{
    public TowerCreater towerCreater;
    //private GameObject towerBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
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
        if (transform.childCount == 0)
        {
            GameObject tower = Instantiate(towerCreater.GetTowerPrefab()[towerNumber], transform.position, Quaternion.identity) as GameObject;
            tower.transform.SetParent(transform);
        }
        else
        {
            Debug.Log("Tower is already placed on that tile");
        }
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
