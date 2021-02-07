
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
    {   if(StateSystem.isEditingGrid()){
            //Debug.Log(isOverLappingTile);
            if (isDragging && !isOnGrid)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);


            }
        }

        if(StateSystem.isBuilding()){
            HandleContactStatus();
        }
        
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
                //Debug.Log("added to contacts");
                AddToContacts(g);//contacts.Add(collision.gameObject);
            }

            
        } 
        if(StateSystem.isBuilding()){

            HandleContactSnapping(); 
        }
    }
    public void HandleContactSnapping(){
        //Debug.Log("colliding with tiles" + contacts.Count + isDragging);
        if (isDragging == false  && isOverLappingTile && !isOnGrid )
        {
            
            if(contacts.Count > 0){
               
                GameObject tile = contacts[contacts.Count-1];
                SnapOn(tile.transform);
                isOnGrid = true;
                //Debug.Log("is on grid");
                if (tile.GetComponent<Tile>().isHoldingItem == false)
                {
                    //Debug.Log("is holding");
                   
                    tile.GetComponent<Tile>().UpdateItem(gameObject);

                }else { 
                                    
                    tile.GetComponent<Tile>().ReplaceItem(gameObject);
                    
                }

            }

        }
    }
    public virtual void HandleContactStatus(){
            
        for(int i = 0; i < contacts.Count; i++){
            //Debug.Log(contacts[i].GetComponent<Tile>().isHoldingItem);
            if(contacts[i].GetComponent<Tile>().isHoldingItem){
                RemoveFromContacts(contacts[i]);
            }
        }

        if(contacts.Count < 1){
            isOverLappingTile = false;
        }
    }

    public void SnapOn(Transform collider)
    {
        // by ignoring the z axis perhaps the layers situation is fixed
        transform.position = new Vector3 (collider.position.x, collider.position.y, transform.position.z);
        
    }
    public void SetTilePtr(GameObject g){
        tile_ptr = g;
    }
    public GameObject GetTilePtr(){
        return tile_ptr;
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

