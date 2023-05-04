using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureALlIdleState : stateMachine
{
    public creatureALlIdleState(characterAi creatureAI) : base(creatureAI){

    }
    public override void UpdateState()
    {
        creatureAI.Mycharacter.Stop();
        if(creatureAI.GetTarget() != null){
            creatureAI.ChangeState(creatureAI.chaseState);
        }
    }

    public override void BeginState()
    {
        
    }
}
