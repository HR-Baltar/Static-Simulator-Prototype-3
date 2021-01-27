using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVector : Item
{
    [SerializeField] private float load_value;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == mate_tag){
            isOverLappingTile = true;
        }
        //Debug.Log(collision.gameObject.name);
        if (isDragging == false && !isHeld)
        {
           
            
            if (collision.gameObject.tag == "Material")
            {
                isHeld = true;
                SnapOn(collision.gameObject.transform);
                //Debug.Log(DragAndDropSupplier._GetSupplierName());
                //DragAndDropSupplier._PopSupply();
                OpenInputMenu();
                //collision.gameObject.GetComponent<Material>().loads.Add(gameObject);
            }

        }
    }

    private void OpenInputMenu(){
        //opens an input menu to give this load a value
        //GameObject force_input = GameObject.Find("ForceInput");
        //force_input.GetComponent<ForceInput>();
        StateSystem.ChangeToWaiting();
        ForceInput._Show();
        ForceInput._Caller(gameObject);
    }
    
}
