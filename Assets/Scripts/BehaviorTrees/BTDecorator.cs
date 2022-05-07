using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTDecorator : BTNode
{
    protected BTNode child;

    public BTDecorator(BTNode child){
        this.child = child;
    }
}
