using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isDragging = true;
    //private Vector3 center;
    public bool isHeld = false;
    public bool isOverLappingTile = false;
    public string mate_tag = "Tile";
    private GameObject tile_ptr = null;
    //private GameObject mateHomePointer;

    public void OnMouseDown()
    {
        //isDragging = true;
        //isHeld = false;
     
        
    }

    public void OnMouseUp()
    {
        //isDragging = false;
        
    }

    void Update()
    {   if(StateSystem.isBuilding()){
            if (isDragging && !isHeld)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        }
        //Debug.Log(isDragging);
        
    }

    
    public bool IsOverLapping(){
        
        return isOverLappingTile;
    }

    private void OnTriggerExit2D(Collider2D collision){
        Debug.Log("pass");
        if(collision.gameObject.tag == mate_tag){
            isOverLappingTile = false;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == mate_tag){

            if(!collision.gameObject.GetComponent<Tile>().isHoldingItem){
                isOverLappingTile = true;

            }
        }

        
        if (isDragging == false && !isHeld && collision.gameObject.tag == "Tile")
        {
            //Debug.Log(isDragging);
            if (collision.gameObject.GetComponent<Tile>().isHoldingItem == false)
            {

                collision.gameObject.GetComponent<Tile>().UpdateItem(gameObject);
                isHeld = true;
                SnapOn(collision.gameObject.transform);
            }else {
                isHeld = true;
                collision.gameObject.GetComponent<Tile>().ReplaceItem(gameObject);
                SnapOn(collision.gameObject.transform);
            }
            
        }
        //Debug.Log(isDragging + " " + isHeld);
    }

    public void SnapOn(Transform collider)
    {
        // by ignoring the z axis perhaps the layers situation is fixed
        transform.position = new Vector3 (collider.position.x, collider.position.y, transform.position.z);
        
    }
    public void SetTilePtr(GameObject g){
        tile_ptr = g;
    }
    public void ErasedFromGrid(){
        //update tile item
        tile_ptr.GetComponent<Tile>().DiscardItem();
    }
}
