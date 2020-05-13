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
    
    private void OnMouseDown()
    {
        //Instantiate(TowerCreater.Instance.)
        Debug.Log("Tower Down!");
        PlaceTower();
    }
    private void PlaceTower()
    {
        Instantiate(towerCreater.GetTowerPrefab(), transform.position, Quaternion.identity);
    }
}
