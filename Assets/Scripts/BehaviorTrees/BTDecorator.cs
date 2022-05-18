using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTDecorator : BTNode
{
    protected BTNode child;

    public BTDecorator(BTNode child){
        this.child = child;
    }

    public override void Reset()
    {
        child.Reset();
        
        // reset a mi estado
        EstadoActual = Estados.IDLE;
    }
}
