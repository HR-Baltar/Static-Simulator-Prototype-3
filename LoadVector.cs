using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVector : Item
{
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (isDragging == false && !isHeld)
        {
            /*if (collision.gameObject.tag == "Tile")
            {
                if (collision.gameObject.GetComponent<Tile>().isHoldingItem == false)
                {
                    collision.gameObject.GetComponent<Tile>().isHoldingItem = true;
                    collision.gameObject.GetComponent<Tile>().item = gameObject;
                    isHeld = true;

                    SnapOn(collision.gameObject.transform);
                }*/
            if (collision.gameObject.tag == "Material")
            {
                isHeld = true;
                SnapOn(collision.gameObject.transform);
            }

        }
    }
}
