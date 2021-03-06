using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorSubmitButton : MonoBehaviour
{

    [SerializeField] private GameObject input_field_text = null;
    [SerializeField] private GameObject dropdown_field_option = null;
    [SerializeField] private GameObject toggle_unknown = null;
    [SerializeField] private GameObject toggle_custom_angle = null;
    [SerializeField] private GameObject angle_field_text;
   // [SerializeField] private GameObject simple_input_canvas = null;
    [SerializeField] private float current_angle = 0;


    void Start(){
        //input_field = GameObject.Find("/ForceInput/InputField");
        //Debug.Log(input_field_text.name);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }



    void TaskOnClick(){
        //Debug.Log("Click");// debug //
        //float value_to_return;
        string text_to_convert = input_field_text.GetComponent<Text>().text;
        
        //set angle from user input
        if(toggle_custom_angle.GetComponent<Toggle>().isOn){
            current_angle = AngleFromCustom();
        }else{
            float dropdown_angle_index = dropdown_field_option.GetComponent<Dropdown>().value;
            current_angle = AngleFromDropdown(dropdown_angle_index);
        }

        //submit based on user input
        if(toggle_unknown.GetComponent<Toggle>().isOn){
            Submit(false, text_to_convert);

        } else if (CheckInputValid(text_to_convert)){
            Submit(true, text_to_convert);

        }else{
            Debug.Log("Bad Input");
        }
        //else -> bring up warning text
    }

    private void Submit(bool known, string text){
        if(known){
            //value_to_return = float.Parse(text_to_convert); //param
            ForceInput._ReturnValue(float.Parse(text));
        }

        StateSystem.ChangeToBuilding();
        ForceInput._ReturnBool(known);//param
        ForceInput._ReturnAngle(current_angle);
        ForceInput._SetBackCursorSupply();
        ForceInput._SaveForce(); //new
        ForceInput._Hide();
    }

    bool CheckInputValid(string value)
    {
        
        try{
            float flt = float.Parse(value);
            return true;
        }catch{
            return false;
        } 
    } 

    
    private float AngleFromDropdown(float s){
        // up down left right 
        
        if(s == 0){return 90;}
        else if(s==1){return 270;}
        else if(s==2){return 180;}
        else {return 0;}

    }
    private float AngleFromCustom (){
        return float.Parse(angle_field_text.GetComponent<Text>().text);
    }

    public void SetAngle(float f){
        current_angle = f;
    }
}
