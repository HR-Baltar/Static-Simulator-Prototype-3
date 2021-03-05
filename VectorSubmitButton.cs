using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorSubmitButton : MonoBehaviour
{

    [SerializeField] private GameObject input_field_text = null;
    [SerializeField] private GameObject dropdown_field_option = null;
    [SerializeField] private GameObject toggle_field = null;
    [SerializeField] private GameObject simple_input_canvas = null;
    [SerializeField] private float current_angle = 0;


    void Start(){
        //input_field = GameObject.Find("/ForceInput/InputField");
        //Debug.Log(input_field_text.name);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        //Debug.Log("Click");// debug //
        float value_to_return;
        string text_to_convert = input_field_text.GetComponent<Text>().text;
        float dropdown_angle_index = dropdown_field_option.GetComponent<Dropdown>().value;
        AngleFromDropdown(dropdown_angle_index);

        if(toggle_field.GetComponent<Toggle>().isOn){
            StateSystem.ChangeToBuilding();
            ForceInput._ReturnBool(false);
            ForceInput._ReturnAngle(current_angle);
            ForceInput._SetBackCursorSupply();
            ForceInput._SaveForce(); //new
            ForceInput._Hide();
            

        } else if (CheckInputValid(text_to_convert)){
            value_to_return = float.Parse(text_to_convert);
            StateSystem.ChangeToBuilding();
            ForceInput._ReturnValue(value_to_return);
            ForceInput._ReturnBool(true);
            ForceInput._ReturnAngle(current_angle);
            ForceInput._SetBackCursorSupply();
            ForceInput._SaveForce(); //new
            ForceInput._Hide();

        }else{
            Debug.Log("Bad Input");
        }
        //else -> bring up warning text
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

    
    private void AngleFromDropdown(float s){
        // up down left right custom
        
        if(s == 0){current_angle = 90;}
        else if(s==1){current_angle = 270;}
        else if(s==2){current_angle = 180;}
        else if(s==3){current_angle=0;}
        else{
            simple_input_canvas.SetActive(true);
            simple_input_canvas.GetComponent<SimpleInput>().Set_Summoner(this);
            
        }

    }

    public void SetAngle(float f){
        current_angle = f;
    }
}
