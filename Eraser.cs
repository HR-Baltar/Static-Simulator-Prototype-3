using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : Item
{    
    [SerializeField] private List<string> mateTags = null;

    public void Start(){
        //mateTags = new List<string>();
        //Debug.Log(mateTags[0]);
        
    }
    public bool CheckingOverlappingMates(GameObject g){
        Debug.Log(mateTags[0]);
        for(int i = 0; i<mateTags.Count; i++){
            Debug.Log(g.tag);
            if(g.tag == mateTags[i]){
                
                return true;
            }
        }
        return false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(CheckingOverlappingMates(collision.gameObject) && Input.GetMouseButtonDown(0)){

            //if(!collision.gameObject.GetComponent<Tile>().isHoldingItem){
            isOverLappingTile = true;

            collision.gameObject.GetComponent<Item>().ErasedFromGrid();
        }

    }
}