using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Tower Creater")]
public class TowerCreater : ScriptableObject
{
    public GameObject towerPrefab;
    public float towerPrice = 25.5f;
    private bool isTowerClicked = false;
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
                GameObject.Find("FoodFollow").GetComponent<FollowMouseTower>().ShowImage();
                GameObject.Find("FanFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("DrinkFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("EntertainmentFollow").GetComponent<FollowMouseTower>().HideImage();
                break;
            case "FanTowerBtn":
                selected = 1;
                isTowerClicked = true;
                GameObject.Find("FanFollow").GetComponent<FollowMouseTower>().ShowImage();
                GameObject.Find("FoodFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("DrinkFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("EntertainmentFollow").GetComponent<FollowMouseTower>().HideImage();
                break;
            case "DrinkTowerBtn":
                selected = 2;
                isTowerClicked = true;
                GameObject.Find("DrinkFollow").GetComponent<FollowMouseTower>().ShowImage();
                GameObject.Find("FoodFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("FanFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("EntertainmentFollow").GetComponent<FollowMouseTower>().HideImage();
                break;
            case "EntertainBtn":
                selected = 3;
                isTowerClicked = true;
                GameObject.Find("EntertainmentFollow").GetComponent<FollowMouseTower>().ShowImage();
                GameObject.Find("FoodFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("DrinkFollow").GetComponent<FollowMouseTower>().HideImage();
                GameObject.Find("FanFollow").GetComponent<FollowMouseTower>().HideImage();
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

    public bool GetIsTowerBtnClicked()
    {
        return isTowerClicked;
    }

    public void SetIsTowerBtnClicked(bool _isClicked)
    {
        isTowerClicked = _isClicked;
    }

}
