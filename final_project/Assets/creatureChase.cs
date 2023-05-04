using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureChase : stateMachine
{
    public creatureChase(characterAi creatureAI) : base(creatureAI){

    }

    public override void UpdateState()
    {
        if(creatureAI.GetTarget()!=null){
        creatureAI.Mycharacter.MoveToward(creatureAI.GetTarget().transform.position);
        }
        else{
            creatureAI.ChangeState(creatureAI.idleState);
        }
    }

    public override void BeginState()
    {
        
    }
}
