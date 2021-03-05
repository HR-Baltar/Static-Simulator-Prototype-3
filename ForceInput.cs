using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceInput : MonoBehaviour
{
    private static ForceInput instance;
    private GameObject caller;
    private GameObject CursorHomePointer;
    
    void Awake(){
        instance = this;
        Hide();
    }
    // Start is called before the first frame update
    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
    public static void _Show(){
        instance.Show();
        
    }
    public static void _Hide(){
        instance.Hide();
    }

    //saves caller info
    public static void _Caller(GameObject g){
        instance.caller = g;
    }

    //sets the input value for the force
    public static void _ReturnValue(float val){
        instance.caller.GetComponent<LoadVector>().SetLoadValue(val);// = val;
    }

    public static void _ReturnBool(bool t){
        instance.caller.GetComponent<LoadVector>().SetLoadKnown(t);
    }
    public static void _ReturnAngle(float a){
        instance.caller.GetComponent<LoadVector>().SetLoadAngle(a);
    }
    public static void _SaveForce(){
        instance.GetComponentInParent<World>().AddToForces(instance.caller);
    }
    //sets the cursor back to the home tool item
    public static void _SetBackCursorSupply(){
        instance.CursorHomePointer.GetComponent<ToolSlot>().SetCursorActive();
    }

    //saves the tool item slot of use
    public static void _SaveCursorHome(GameObject g){
        instance.CursorHomePointer = g;
    }

}
