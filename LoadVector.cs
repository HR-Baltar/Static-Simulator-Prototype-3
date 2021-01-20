using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVector : Item
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (isDragging == false && !isHeld)
        {
           
            
            if (collision.gameObject.tag == "Material")
            {
                isHeld = true;
                SnapOn(collision.gameObject.transform);
                collision.gameObject.GetComponent<Material>().loads.Add(gameObject);
            }

        }
    }
}
