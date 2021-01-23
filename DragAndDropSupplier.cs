using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSupplier : MonoBehaviour
{
    //private bool isDragging;
    public GameObject Supply;
    public GameObject pfSupply;


    public void OnMouseDown()
    {
        //isDragging = true;
        if(StateSystem.isBuilding()){
            Supply = (GameObject)Instantiate(pfSupply, transform);
            Supply.transform.position = transform.position;
            Supply.gameObject.GetComponent<Item>().isDragging = true;
        }
    }

    public void OnMouseUp()
    {
        //Supply.gameObject.GetComponent<Item>().isDragging = false;
    }

    void Update()
    {
        /*
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Supply.transform.position;
            Supply.transform.Translate(mousePosition);
        } */
    }

    public GameObject GenerateSupply()
    {
        GameObject item;
        GameObject pfTile = (GameObject)Instantiate(Resources.Load("Select"));
        item = (GameObject)Instantiate(pfTile, transform);
        item.transform.position = transform.position;
        Destroy(pfTile);

        return item;
    }
}
