using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Creater")]
public class TowerCreater : ScriptableObject
{
    public GameObject towerPrefab;

    
    public List<GameObject> GetTowerPrefab()
    {
        var towers = new List<GameObject>();
        foreach(Transform tower in towerPrefab.transform)
        {
            towers.Add(tower.gameObject);
        }
        return towers;
    }

}
