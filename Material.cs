using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : Item
{
    private List<GameObject> loads = null;
    private string label = null;
    [SerializeField] private bool isFixed = false;

    void Start(){
        loads = new List<GameObject>();
        //contacts = new List<GameObject>();
    }

    public void OnMouseDown()
    {
        if(isOnGrid){
            isDragging = !isDragging;
            isOnGrid = !isOnGrid;
            //Debug.Log("db1");
        }else {
            isOnGrid = !isOnGrid;
            isDragging = !isDragging;
            if(isSpawned  && GetContactsCount() > 0){
                GameObject tile = ContactIndex(GetContactsCount() - 1);
                SnapOn(tile.transform);

                if(tile.GetComponent<Tile>().isHoldingItem == true){
                    tile.GetComponent<Tile>().ReplaceItem(gameObject);
                }else{
                    tile.GetComponent<Tile>().UpdateItem(gameObject);
                }
            }
        }
   
     
        
    }

    public void DiscardLoad(GameObject load){
        loads.Remove(load);
        Destroy(load);
        //isHoldingItem = false;
    }
    public void AddToLoads(GameObject load){
        loads.Add(load);
    }
    // public void ClearAllLoads(){
    //     loads.Clear();
    // }

    public override void ErasedFromGrid(){
        //update tile item
        //tile_ptr.GetComponent<Tile>().DiscardItem();
        if(loads.Count > 0){
            for(int i = 0; i<loads.Count; i++){
                Destroy(loads[i]);
            }
        }

        base.ErasedFromGrid();
    }

    
}
