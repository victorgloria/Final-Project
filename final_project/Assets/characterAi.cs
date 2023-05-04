using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAi : MonoBehaviour
{
    public character Mycharacter;
    public character targetCharacter;
    stateMachine currentState;
    public creatureALlIdleState idleState{get; private set;}
    public creatureChase chaseState{get; private set;}
    public void ChangeState(stateMachine newState){
        currentState = newState;
        currentState.BeginStateBase();
    }
    void Start()
    {
        idleState = new creatureALlIdleState(this);
        chaseState = new creatureChase(this);
        currentState = idleState;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateState();
    }

    public character GetTarget(){
        if(Vector3.Distance(transform.position, targetCharacter.transform.position) < 20 && Vector3.Distance(transform.position, targetCharacter.transform.position) > 3){
            return targetCharacter;
        }
        else{
            return null;
        }
        
    }
}
