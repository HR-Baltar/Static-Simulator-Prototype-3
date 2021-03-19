using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private static World instance;
    [SerializeField] private List<GameObject> Forces = new List<GameObject>();

    void Awake(){
        instance = this;
    }

    public void AddToForces(GameObject force){
        Forces.Add(force);
    }
    public void RemoveFromForces(GameObject force){
        Forces.Remove(force);
    }

    public static void Solve(){
        Debug.Log("Solving......");
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
                    sub eqn / null # list<variables>
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

    // Main program DEMO 2 // 
    collect the forces into a list (DONE)
    initialize two separate lists (X and Y)
    for each force
        initialize a variable() for each force entity
        count unknowns based on varaibles. 
        add unknowns to unknown list
        if unknowns greater than 2
            unsolvable
        else
            // case of one unknown and one equation
            combine all other terms except for the unknown -> simplify()
            set unknown equal to that sum
        
            // case of two unknowns and 2 equation
            if both in separate equations
                repeat case one for both unknowns
            if both in same equations and both are different data types (ie force vs angle)
                simplify() each equation -> combine knowns
                set a sub equation.
                merge sub equation into other equations


    // Main program DEMO 1 // case of one unknown and one equation
    collect the forces into a list (DONE)
    initialize two separate lists (X and Y)
    for each force
        initialize a variable() for each force entity
        count unknowns based on varaibles. 
        add unknowns to unknown list
        if unknowns greater than 2
            unsolvable
        else
            // case of one unknown and one equation
            combine all other terms except for the unknown -> simplify()
            set unknown equal to that sum
        
            // case of two unknowns and 2 equation
            if both in separate equations
                repeat case one for both unknowns
            if both in same equations and both are different data types (ie force vs angle)
                simplify() each equation -> combine knowns
                set a sub equation.
                merge sub equation into other equations

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