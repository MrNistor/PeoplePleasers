using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject ui_prefab;

    // Start is called before the first frame update
    void Start()
    {
        ui_prefab = transform.GetChild(1).gameObject;
        ui_prefab.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ui_prefab.gameObject.SetActive(true);
        }

    }
}
