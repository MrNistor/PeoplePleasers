using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;
    public SpriteRenderer sprite;

    //public GameObject ui_prefab;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
       // ui_prefab = GameObject.Find("UI_Shop");
        //ui_prefab.SetActive(false);
        
    }

    private void Update()
    {
       

    }

    void OnMouseOver() {
        //Debug.Log("mouse over");
        sprite.color = mouseOverColor;
    }

    void OnMouseExit() {
        //Debug.Log("mouse exit");
        sprite.color = startColor;
    }
    private void OnMouseDown()
    {
       

    }




}
