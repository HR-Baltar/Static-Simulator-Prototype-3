using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public bool isDragging = true;
    //private Vector3 center;
    public bool isHeld = false;
    public bool isOverLappingTile = false;
    public string mate_tag = "Tile";
    private GameObject tile_ptr = null;
    private List<GameObject> contacts =new List<GameObject>();
    //private GameObject mateHomePointer;
    void Start(){
        
    }


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
            //Debug.Log(isOverLappingTile);
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

        
        if (isDragging == false && !isHeld && g.tag == mate_tag)
        {
            

            if (g.GetComponent<Tile>().isHoldingItem == false)
            {

                g.GetComponent<Tile>().UpdateItem(gameObject);
                isHeld = true;
                SnapOn(g.transform);
            }else {
                isHeld = true;
                g.GetComponent<Tile>().ReplaceItem(gameObject);
                SnapOn(g.transform);
            }
            
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
    public virtual void ErasedFromGrid(){
        //update tile item
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
