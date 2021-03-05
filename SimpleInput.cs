using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInput : MonoBehaviour
{
    // Start is called before the first frame update
    private VectorSubmitButton current_summoner = null;
    private bool isActive = false;
    private float return_val =0;

    public void Set_Summoner(VectorSubmitButton g){
        current_summoner = g;
    }
    public VectorSubmitButton Get_Summoner(){
        return current_summoner;
    }
    public void Set_return_val(float val){
        return_val = val;
    }
    public float Get_Return_val(){
        return return_val;
    }
    public void Hide(){
        gameObject.SetActive(false);
    }
    public void Show(){
        gameObject.SetActive(true);
    }
}
