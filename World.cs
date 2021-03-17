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

////////////////////////////////////////////////////

// Simple Calculation (w/o solutions)//
/*
    A1 + A2 = A3 + UK

    Objects:
        Symbols
            variables
                params
                    value / null #float
                    angle / null #float
                methods
                    constructor () {value=null, angle=null}
                    Constructor (value, angle)
                    isKnown() #bool {
                        if ((value is null) or (angle is null))
                            return false
                        return true
                    }
                    operators +,-,*,/ (variable p) #void {
                        if isKnown and p.isKnown are both true
                            new vector ((sValueX+pValueX),(sValueY+pValueY))
                            get magnitue of new vector, M
                            get angle of new vector, A
                            return variable(value=M, angle=A)
                        else
                            return variable(0,0)

                    }

*/
// Solution Generator //
/*
    A1 + A2 = A3 + U1 + U2
    U1 = F1 * R
    U2 = A4 + A5

    Objects:
        Symbols
            variables()
                params
                    value / null #float
                    subEqn #Equation
                methods
                    constructor () {value=null}
                    Constructor (value)
                    isKnown() #bool {
                        if (value is null)
                            return false
                        return true
                    }
                    setEquation (eqn) {
                        subEqn = eqn
                    }
                    operators +,-,*,/ (variable p) #void {
                        if isKnown and p.isKnown are both true
                            output = s.value + p.value
                            return variable(output)
                        else
                            return variable(0)

                    }
        Equations ()
            params
                leftSide # list
                rightSide # list
            methods
                countUnknowns() #int {
                    count is set to 0
                    for var in leftSide
                        if var is unknown
                            count increases
                    return count
                }
                isSolvable() #bool {
                    if countUnknowns() > 1
                        return false
                    return true
                }


*/