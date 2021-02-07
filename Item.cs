
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public bool isDragging = true;
    //private Vector3 center;
    public bool isOnGrid = false;
    public bool isOverLappingTile = false;
    public string mate_tag = "Tile";
    private GameObject tile_ptr = null;
    private List<GameObject> contacts =new List<GameObject>();
    public bool isSpawned = false;
    //private GameObject mateHomePointer;
    void Start(){
        
    }


    public void OnMouseDown()
    {
        // isDragging = true;
        // isOnGrid = false;
     
        
    }

    public void OnMouseUp()
    {
        //isDragging = false;
        
    }

    void Update()
    {   if(StateSystem.isBuilding()){
            //Debug.Log(isOverLappingTile);
            if (isDragging && !isOnGrid)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);


            }

            // if(Input.GetMouseButtonDown(0)){
            //     //Debug.Log("colliding with tiles" + contacts.Count + isDragging);
            //     GameObject ct = contacts[contacts.Count -1];
            //     if (isDragging == false)
            //     {
            //         //Debug.Log("is dragging and mate tag is tile");
            //         if(!isOnGrid){
            //             SnapOn(g.transform);
            //             isOnGrid = true;
            //             Debug.Log("is on grid");
            //             if (g.GetComponent<Tile>().isHoldingItem == false)
            //             {
            //                 Debug.Log("is holding");
                        
            //                 g.GetComponent<Tile>().UpdateItem(gameObject);

            //             }else { 
                                            
            //                 g.GetComponent<Tile>().ReplaceItem(gameObject);
                            
            //             }

            //         }else {
            //         //g.GetComponent<Tile>().ReplaceItem(gameObject);

            //         }


            //     }
            // }
        }
        //Debug.Log(isDragging);
        
    }

    
    public bool IsOverLapping(){
        
        return isOverLappingTile;
    }

    private void OnTriggerExit2D(Collider2D collision){
        HandleExitingColliders(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleEnteringColliders(collision.gameObject);
    }

    public virtual void HandleExitingColliders(GameObject g){
        if(g.tag == mate_tag){
            RemoveFromContacts(g);//contacts.Remove(collision.gameObject);

            if(contacts.Count < 1){
                isOverLappingTile = false;
            }
        }
    }

    public virtual void HandleEnteringColliders(GameObject g){
        if(g.tag == mate_tag){

            if(!g.GetComponent<Tile>().isHoldingItem){
                isOverLappingTile = true;
                AddToContacts(g);//contacts.Add(collision.gameObject);
            }
        }

        // Debug.Log("colliding with tiles" + contacts.Count + isDragging);
        // if (isDragging == false  && g.tag == mate_tag)
        // {
        //     Debug.Log("is dragging and mate tag is tile");
        //     if(!isOnGrid){
        //         SnapOn(g.transform);
        //         isOnGrid = true;
        //         Debug.Log("is on grid");
        //         if (g.GetComponent<Tile>().isHoldingItem == false)
        //         {
        //             Debug.Log("is holding");
                   
        //             g.GetComponent<Tile>().UpdateItem(gameObject);

        //         }else { 
                                    
        //             g.GetComponent<Tile>().ReplaceItem(gameObject);
                    
        //         }

        //     }else {
        //        //g.GetComponent<Tile>().ReplaceItem(gameObject);

        //     }


        // }

        
    }

    public void SnapOn(Transform collider)
    {
        // by ignoring the z axis perhaps the layers situation is fixed
        transform.position = new Vector3 (collider.position.x, collider.position.y, transform.position.z);
        
    }
    public void SetTilePtr(GameObject g){
        tile_ptr = g;
    }
    public virtual void ErasedFromGrid(){
        //update tile item
       // Debug.Log("Error: erase");
        tile_ptr.GetComponent<Tile>().DiscardItem();
    }
    public void AddToContacts(GameObject g){

        contacts.Add(g);
    }
    public void RemoveFromContacts(GameObject g){
        contacts.Remove(g);
    }
    public int GetContactsCount(){
        return contacts.Count;
    }
    public GameObject ContactIndex(int idx){
        return contacts[idx];
    }
}

