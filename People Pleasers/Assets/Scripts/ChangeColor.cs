using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;
    public SpriteRenderer sprite;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver() {
        Debug.Log("mouse over");
        sprite.color = mouseOverColor;
    }

    void OnMouseExit() {
        Debug.Log("mouse exit");
        sprite.color = startColor;
    }
}
