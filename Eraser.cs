using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : Item
{    
    [SerializeField] private List<string> mateTags = null;



    void Update()
    {   if(StateSystem.isBuilding()){
            if (isDragging)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);

                if(Input.GetMouseButtonDown(0) && GetContactsCount() > 0 ){
                    ContactIndex(0).GetComponent<Item>().ErasedFromGrid();
                }
            }
        }
    }

    public bool CheckingOverlappingMates(GameObject g){
        //Debug.Log(mateTags[0]);
        for(int i = 0; i<mateTags.Count; i++){
            
            if(g.tag == mateTags[i]){
                //Debug.Log("pass");
                return true;
            }
        }
        return false;
    }

    public override void HandleExitingColliders(GameObject g){
        
        if(CheckingOverlappingMates(g)){
            RemoveFromContacts(g);//contacts.Remove(g);

            if(GetContactsCount() < 1){ 
                isOverLappingTile = false;
            }
        }

    }
    public override void HandleEnteringColliders(GameObject g)
    {
        
        if(CheckingOverlappingMates(g)){// && Input.GetMouseButtonDown(0)){

            //if(!collision.gameObject.GetComponent<Tile>().isHoldingItem){
            isOverLappingTile = true;
            AddToContacts(g);//contacts.Add(g);
            //collision.gameObject.GetComponent<Item>().ErasedFromGrid();
        }

    }
}