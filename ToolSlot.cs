﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSlot : MonoBehaviour
{
    private bool isDragging = false;
    private GameObject Supply;
    private Sprite supplySprite = null;
    private GameObject pfSupply;
    private Sprite toolDisplay = null;
    private static ToolSlot instance;
   

    void Awake(){
        instance = this;
        
    }

    public void OnMouseDown()
    {
        
        if(StateSystem.isEditingGrid()){
            if(!isDragging){
                StateSystem.ChangeToBuilding();
                SetCursorActive();
            }
        }
    }

    public void Set_pfSupply(GameObject g){
        pfSupply = g;
        supplySprite = pfSupply.GetComponent<SpriteRenderer>().sprite;
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
            //Debug.Log(Supply.GetComponent<Item>().IsOverLapping());

            
            if(Input.GetMouseButtonDown(0) && Supply.GetComponent<Item>().IsOverLapping() && Supply.gameObject.tag != "Eraser"){
                //Debug.Log(Supply.GetComponent<Item>().isOnGrid + "click");
                GameObject item = GenerateSupply();
                
                item.GetComponent<Item>().isDragging = false;
                item.GetComponent<Item>().isSpawned = true;
                //Debug.Log(Supply.gameObject.tag);
                if(Supply.gameObject.tag == "Force"){
                    Debug.Log("click");
                    PopSupply();
                    ForceInput._SaveCursorHome(gameObject);
                }

            } 
            else if(Input.GetMouseButtonDown(1)){
                PopSupply();
                StateSystem.ChangeToEditingGrid();
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
