﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Creater")]
public class TowerCreater : ScriptableObject
{
    public GameObject towerPrefab;

    
    public GameObject GetTowerPrefab()
    {
        return towerPrefab;
    }
}