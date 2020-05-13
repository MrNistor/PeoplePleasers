using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerPlacer : MonoBehaviour
{
    public TowerCreater towerCreater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        try
        {
            if (towerIndexNum == -1)
            {
                return -1;
            }
            else
            {
                Debug.Log("From Tower Placer: " + towerIndexNum);
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
