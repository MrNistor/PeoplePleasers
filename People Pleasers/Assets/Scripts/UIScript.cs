using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject ui_prefab;
    private Button rangeButton;

    // Start is called before the first frame update
    void Start()
    {
        ui_prefab = transform.GetChild(1).gameObject;
        //ui_prefab = GameObject.Find("UI_Shop");
       // ui_prefab.SetActive(false);

        //ui_prefab.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ui_prefab.gameObject.SetActive(true);
        }
        
    }

    public void Clicked()
    {
        //ui_prefab.SetActive(true);
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ui_prefab.gameObject.SetActive(true);
        }
    }

}
