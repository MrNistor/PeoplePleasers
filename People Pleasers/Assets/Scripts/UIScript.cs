using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject ui_prefab;
    private Button rangeButton;
    public Color startColor;
    public Color mouseOverColor;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        ui_prefab = transform.GetChild(1).gameObject;
        //ui_prefab = GameObject.Find("UI_Shop");
       // ui_prefab.SetActive(false);

        //ui_prefab.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown() {
        ui_prefab.gameObject.SetActive(true);
    }

    void OnMouseExit() {
        //Debug.Log("mouse exit");
        sprite.color = startColor;
    }

    void OnMouseOver() {
        //Debug.Log("mouse over");
        sprite.color = mouseOverColor;
    }

    // public void OnPointerEnter(PointerEventData pointerEventData)
    // {
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         ui_prefab.gameObject.SetActive(true);
    //     }
    // }

    // //Detect when Cursor leaves the GameObject
    // public void OnPointerExit(PointerEventData pointerEventData)
    // {
    //     //Output the following message with the GameObject's name
    //     Debug.Log("Cursor Exiting ");
    // }
}
