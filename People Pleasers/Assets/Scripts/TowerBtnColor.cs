using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBtnColor : MonoBehaviour
{
    private Image _image;
    private bool isTowerBtnClicked;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        isTowerBtnClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        ChangeColor();
    }

    private void OnMouseExit()
    {
        _image.color = Color.white;
    }

    private void OnMouseDown()
    {
        isTowerBtnClicked = true;
        Debug.Log(GetisTowerBtnClicked());
    }

    public bool GetisTowerBtnClicked()
    {
        return isTowerBtnClicked;
    }

    private void ChangeColor()
    {
        if (gameObject.name.Contains("Burger"))
        {
            _image.color = Color.red;
        }
        else if (gameObject.name.Contains("Fan"))
        {
            _image.color = new Color(255f, 174f, 0);
        }
        else if (gameObject.name.Contains("Drink"))
        {
            _image.color = Color.blue;
        }
        else if (gameObject.name.Contains("Entertain"))
        {
            _image.color = new Color(206f, 0, 255f);
        }
        //Debug.Log(gameObject.name);
    }
}
