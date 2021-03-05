using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    [SerializeField] private List<GameObject> Forces = new List<GameObject>();

    public void AddToForces(GameObject force){
        Forces.Add(force);
    }
    public void RemoveFromForces(GameObject force){
        Forces.Remove(force);
    }

    //check valid equations and variables //REQUIRES ORIENTATION OF LOAD VECTORS
    // public bool CheckSolvable(){
    //     Yaxis = new List<float>();
    //     Xaxis = new List<float>();

    //     //
    // }
}
