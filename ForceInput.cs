using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceInput : MonoBehaviour
{
    private static ForceInput instance;
    private GameObject caller;
    
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
    public static void _Caller(GameObject g){
        instance.caller = g;
    }
    public static void _ReturnValue(float val){
        instance.caller.GetComponent<LoadVector>().SetLoadValue(val);// = val;
    }

}
