using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaceTower(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PlaceTower(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceTower(2);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            PlaceTower(3);
        }
        else
        {
            Debug.Log("?");
        }
    }
    private void OnMouseDown()
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
            GameObject tower = (GameObject)Instantiate(towerCreater.GetTowerPrefab()[towerNumber], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
        }
        else
        {
            Debug.Log("Tower is already placed on that tile");
        }
    }
}
