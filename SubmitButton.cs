using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject input_field_text = null;
    [SerializeField] private GameObject toggle_field = null;
    //[SerializeField]private Button button;

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

        if(toggle_field.GetComponent<Toggle>().isOn){
            StateSystem.ChangeToBuilding();
            ForceInput._ReturnBool(false);
            ForceInput._SetBackCursorSupply();
            ForceInput._Hide();

        } else if (CheckInputValid(text_to_convert)){
            value_to_return = float.Parse(text_to_convert);
            StateSystem.ChangeToBuilding();
            ForceInput._ReturnValue(value_to_return);
            ForceInput._ReturnBool(true);
            ForceInput._SetBackCursorSupply();
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
}
