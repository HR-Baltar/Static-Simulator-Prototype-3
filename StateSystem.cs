﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSystem : MonoBehaviour
{
    private State state;
    private static StateSystem instance;

    private enum State{
        WaitingForInput,
        Building,
    }
    void Awake(){
        instance = this;
    }
    void Start()
    {
        state = State.Building;
    }
    public static void ChangeToWaiting(){
        instance.state = State.WaitingForInput;
    }
    public static bool isWaiting(){
        return (instance.state == State.WaitingForInput);
    }
    public static void ChangeToBuilding(){
        instance.state = State.Building;
    }
    public static bool isBuilding(){
        return (instance.state == State.Building);
    }

}
