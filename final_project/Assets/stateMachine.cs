using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class stateMachine
{
    protected characterAi creatureAI;

    float timer = 0;
    public stateMachine(characterAi newAi){
        creatureAI = newAi;
    }

    public void UpdateStateBase(){
        timer+=Time.fixedDeltaTime;
        UpdateState();
    }
    public void BeginStateBase(){
        timer = 0;
        BeginState();
    }
    public abstract void UpdateState();

    public abstract void BeginState();
}
