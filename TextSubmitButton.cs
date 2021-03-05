using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSubmitButton : MonoBehaviour
{

    [SerializeField] private GameObject input_field_text = null;
    [SerializeField] private GameObject canvas_home = null;
    private GameObject summoner = null;


    void Start(){

        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        float value_to_return;
        string text_to_convert = input_field_text.GetComponent<Text>().text;

        if (CheckInputValid(text_to_convert)){
            value_to_return = float.Parse(text_to_convert);
            canvas_home.GetComponent<SimpleInput>().Get_Summoner().SetAngle(value_to_return);
            canvas_home.GetComponent<SimpleInput>().Hide();

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
