using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSupplier : MonoBehaviour
{
    private bool isDragging;
    public GameObject Supply;


    public void OnMouseDown()
    {
        isDragging = true;
        Supply = GenerateSupply();
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Supply.transform.position;
            Supply.transform.Translate(mousePosition);
        }
    }

    private GameObject GenerateSupply()
    {
        GameObject item;
        GameObject pfTile = (GameObject)Instantiate(Resources.Load("Select"));
        item = (GameObject)Instantiate(pfTile, transform);
        item.transform.position = transform.position;
        Destroy(pfTile);

        return item;
    }
}
