using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTComposite : BTNode
{
    
    protected List<BTNode> children;
    protected int hijoActual;

    public BTComposite() {
        children = new List<BTNode>();
        hijoActual = 0;
    }

    public void AddChild(BTNode child){
        children.Add(child);
    }

    public override void Reset(){

        // reset a todos los hijos
        foreach(var actual in children){
            actual.Reset();
        }

        // reset a mi estado
        EstadoActual = Estados.IDLE;
        hijoActual = 0;
    }
}
