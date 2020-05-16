using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Tower Creater")]
public class TowerCreater : ScriptableObject
{
    public GameObject towerPrefab;
    // May 15
    public float towerPrice = 25.5f;
    private bool isTowerClicked = false;
    // End of May 15
    private int selected = -1;
    

    public List<GameObject> GetTowerPrefab()
    {
        var towers = new List<GameObject>();
        foreach(Transform tower in towerPrefab.transform)
        {
            towers.Add(tower.gameObject);
        }
        return towers;
    }
    public void SelectTower(Button burgerBtn)
    {
        selected = -1;
        switch (burgerBtn.name)
        {
            case "BurgerTowerBtn":
                selected = 0;
                isTowerClicked = true;
                break;
            case "FanTowerBtn":
                selected = 1;
                isTowerClicked = true;
                break;
            case "DrinkTowerBtn":
                selected = 2;
                isTowerClicked = true;
                break;
            case "EntertainBtn":
                selected = 3;
                isTowerClicked = true;
                break;
            default:
                selected = -1;
                isTowerClicked = false;
                break;
        }
        Debug.Log("Btn clicked" + selected);
        //return selected;
    }

    public int GetSelectedTower()
    {
        return selected;
    }

    // may 15 
    public bool GetIsTowerBtnClicked()
    {
        return isTowerClicked;
    }
    public void SetIsTowerBtnClicked(bool _isClicked)
    {
        isTowerClicked = _isClicked;
    }
    // may 15
    public float BuyTower()
    {
        return towerPrice;
    }
}
