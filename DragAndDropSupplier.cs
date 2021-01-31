using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropSupplier : MonoBehaviour
{
    private bool isDragging = false;
    private GameObject Supply;
    private GameObject pfSupply;
    private static DragAndDropSupplier instance;
   

    void Awake(){
        instance = this;
    }

    public void OnMouseDown()
    {
        
        if(StateSystem.isBuilding()){
            if(!isDragging){
                SetCursorActive();
            }
        }
    }

    public void Set_pfSupply(GameObject g){
        pfSupply = g;
    }
 //   public void Set_Supply
    public void OnMouseUp()
    {
        //Supply.gameObject.GetComponent<Item>().isDragging = false;
    }

    

    void Update()
    {
        
        if (isDragging)
        {
            //Debug.Log(Supply.GetComponent<Item>().mate_tag + Supply.GetComponent<Item>().IsOverLapping());
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Supply.transform.position;
            Supply.transform.Translate(mousePosition);

            
            if(Input.GetMouseButtonDown(0) && Supply.GetComponent<Item>().IsOverLapping() && Supply.gameObject.tag != "Eraser"){
                //Debug.Log(Supply.GetComponent<Item>().isHeld + "click");
                GameObject item = GenerateSupply();
                
                item.GetComponent<Item>().isDragging = false;
                //Debug.Log(Supply.gameObject.tag);
                if(Supply.gameObject.tag == "Force"){
                    PopSupply();
                    ForceInput._SaveCursorHome(gameObject);
                }

            } 
            else if(Input.GetMouseButtonDown(1)){
                PopSupply();
            }
        } 
    }

    public void SetCursorActive(){
        isDragging = true;
        Supply = (GameObject)Instantiate(pfSupply);
        Supply.transform.position = new Vector3(transform.position.x, transform.position.y, Supply.transform.position.z);
    }

    public static void _PopSupply(){
        //Destroy(instance.Supply)
        Destroy(instance.Supply);
    }
    private void PopSupply(){
        Destroy(Supply);
        isDragging = false;
    }


    private string GetSupplierName(){
        return Supply.name;
    }

    public GameObject GenerateSupply()
    {
        GameObject item;
        //GameObject pfTile = (GameObject)Instantiate(Resources.Load(item_name));
        item = (GameObject)Instantiate(pfSupply);
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        item.transform.position = new Vector3(MousePos.x, MousePos.y, item.transform.position.z);
        //Destroy(pfTile);

        return item;
    }
}
