using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : Item
{
    private List<GameObject> loads = null;
    //private string label = null;
    //[SerializeField] private bool isFixed = false;

    void Start(){
        loads = new List<GameObject>();
        //contacts = new List<GameObject>();
    }

    public void OnMouseDown()
    {
        if(StateSystem.isEditingGrid())
            if(isOnGrid){
                isDragging = !isDragging;
                isOnGrid = !isOnGrid;
                
                GetTilePtr().GetComponent<Tile>().isHoldingItem = false;
                //Debug.Log("db1");
            }else {
                //Debug.Log("contacts: "+GetContactsCount() + " Spawned: " + isSpawned);
                
                if(isSpawned  && GetContactsCount() > 0){
                    isOnGrid = !isOnGrid;
                    isDragging = !isDragging;

                    GameObject tile = ContactIndex(GetContactsCount() - 1);
                    //Debug.Log("check 2: " + tile.name);
                    SnapOn(tile.transform);

                    if(tile.GetComponent<Tile>().isHoldingItem == true){
                        //Debug.Log("replace");
                        tile.GetComponent<Tile>().ReplaceItem(gameObject);
                    }else{
                        //Debug.Log("update");
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
                loads[i].GetComponent<LoadVector>().ErasedFromGrid();//Destroy(loads[i]);
            }
        }

        base.ErasedFromGrid();
    }

    
}
