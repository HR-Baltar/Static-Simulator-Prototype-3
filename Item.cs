using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isDragging;
    private Vector3 center;
    public bool isHeld = false;

    private void Start()
    {
        center = transform.position;
    }


    public void OnMouseDown()
    {
        if (!isHeld) { 
            isDragging = true;
        }
        //isHeld = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        
    }

    void Update()
    {
        if (isDragging && !isHeld)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        //Debug.Log(isDragging);
        
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (isDragging == false && !isHeld && collision.gameObject.tag == "Tile")
        {
            //Debug.Log(isDragging);
            if (collision.gameObject.GetComponent<Tile>().isHoldingItem == false)
            {
                

                //Debug.Log("Yay : " + isDragging);//debug
                //Debug.Log("Item: " + transform.position);
                //Debug.Log("Tile:" + collision.transform.position);
                collision.gameObject.GetComponent<Tile>().isHoldingItem = true;
                collision.gameObject.GetComponent<Tile>().item = gameObject;
                isHeld = true;

                SnapOn(collision.gameObject.transform);
            }
            
        }
    }

    public void SnapOn(Transform collider)
    {
        // by ignoring the z axis perhaps the layers situation is fixed
        transform.position = new Vector3 (collider.position.x, collider.position.y, transform.position.z);
        
    }
}
