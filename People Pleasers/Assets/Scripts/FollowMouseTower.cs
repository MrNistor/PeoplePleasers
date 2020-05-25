using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseTower : MonoBehaviour
{
    private Vector3 mousePosition;
    private Color c;

    // Start is called before the first frame update
    void Start()
    {
        HideImage();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);   
        GetComponent<Transform>().position = new Vector3(mousePosition.x, mousePosition.y, GetComponent<Transform>().position.z);
    }

    public void HideImage()
    {
        c = GetComponent<SpriteRenderer>().color;
        c.a = 0f;
        GetComponent<SpriteRenderer>().color = c;
    }

    public void ShowImage()
    {
        c = GetComponent<SpriteRenderer>().color;
        c.a = 1f;
        GetComponent<SpriteRenderer>().color = c;
    }
}
