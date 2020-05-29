using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitMenuScript : MonoBehaviour
{

    public GameObject ui_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void closeMenu()
    {
        ui_prefab.gameObject.SetActive(false);
    }



}
