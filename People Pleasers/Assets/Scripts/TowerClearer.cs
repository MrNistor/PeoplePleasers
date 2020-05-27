using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClearer : MonoBehaviour
{
    public TowerCreater towerCreater;
   
    public void BtnClick()
    {
        HideFollowImages();
        towerCreater.SetTowerIndex(-1);
    }

    private void HideFollowImages()
    {
        GameObject.Find("EntertainmentFollow").GetComponent<FollowMouseTower>().HideImage();
        GameObject.Find("FoodFollow").GetComponent<FollowMouseTower>().HideImage();
        GameObject.Find("DrinkFollow").GetComponent<FollowMouseTower>().HideImage();
        GameObject.Find("FanFollow").GetComponent<FollowMouseTower>().HideImage();
    }
}
