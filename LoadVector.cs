using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVector : Item
{
    [SerializeField] private float load_value;
    [SerializeField] private GameObject crossection_ptr;
    [SerializeField] private string label = null;
    [SerializeField] private float angle = 90f;
    [SerializeField] private bool known = false;
    //mate_tag = "Material";

    private void Start()
    {
        mate_tag = "Material";
    }
    public float GetLoadValue(){
        return load_value;
    }
    public void SetLoadValue(float new_val){
        load_value = new_val;
    }

    public void SetLoadKnown(bool t){
        known = t;
    }

    public override void HandleEnteringColliders(GameObject g){
        if(g.tag == mate_tag){
            isOverLappingTile = true;
            AddToContacts(g);
        }

        if (isDragging == false && !isOnGrid)
        {
           
            
            if (g.tag == mate_tag)
            {
                isOnGrid = true;
                crossection_ptr = g;
                g.GetComponent<Material>().AddToLoads(gameObject);
                SnapOn(g.transform);
                OpenInputMenu();
            }

        }
    }
    public override void HandleContactStatus(){
            

        if(GetContactsCount() < 1){
            isOverLappingTile = false;
        }
    }

    private void OpenInputMenu(){
        //opens an input menu to give this load a value

        StateSystem.ChangeToWaiting(); //change state 
        ForceInput._Show(); // display the ui
        ForceInput._Caller(gameObject);
    }

    public override void ErasedFromGrid(){
        gameObject.GetComponentInParent<World>().RemoveFromForces(gameObject);
        crossection_ptr.GetComponent<Material>().DiscardLoad(gameObject);
    }
    
}
