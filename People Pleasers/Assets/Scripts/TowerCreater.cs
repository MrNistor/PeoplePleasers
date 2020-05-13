using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Tower Creater")]
public class TowerCreater : ScriptableObject
{
    public GameObject towerPrefab;
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
                break;
            case "FanTowerBtn":
                selected = 1;
                break;
            case "DrinkTowerBtn":
                selected = 2;
                break;
            case "EntertainBtn":
                selected = 3;
                break;
            default:
                break;
        }
        Debug.Log("Btn clicked" + selected);
        //return selected;
    }

    public int GetSelectedTower()
    {
        return selected;
    }
}
