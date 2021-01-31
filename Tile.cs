using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isDragging;
    private GameObject item = null;
    public bool isHoldingItem;
    private Vector3 center;

    private void Start()
    {
        center = transform.position;
    }

    public Vector3 GetCenter()
    {
        return center;
    }

    public void ReplaceItem(GameObject g){
        DiscardItem();
        UpdateItem(g);
    }
    public void DiscardItem(){
        Destroy(item);
        isHoldingItem = false;
    }
    public void UpdateItem(GameObject g){
        g.GetComponent<Item>().SetTilePtr(gameObject);
        item = g; 
        isHoldingItem = true;
    }


    /*
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    */


}
