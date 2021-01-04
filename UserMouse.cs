using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMouse : MonoBehaviour
{
    GameObject cursor;
    Ray ray;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
     
        // DEBUG // instantiate selection box
        GameObject pfTile = (GameObject)Instantiate(Resources.Load("Select"));
        cursor = (GameObject)Instantiate(pfTile, transform);
        cursor.transform.position = transform.position;
        Destroy(pfTile);
        
    }

    //the object to move


    void Update()
    {
        
        //updates mouse position internally
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        /*
        // DEBUG // teleports select box on mouse click
        if (Input.GetButtonDown("Fire1")) {
            cursor.transform.position = worldPosition;
        } */

        // mouse collisions
        hit = Physics2D.Raycast(worldPosition, Vector2.zero, 0);
        if (hit )
        {
            Debug.Log(hit.collider.name);
        }
        



    }


}
