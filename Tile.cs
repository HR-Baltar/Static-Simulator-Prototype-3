using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isDragging;
    public GameObject item= null;
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
