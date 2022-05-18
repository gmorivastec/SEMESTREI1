using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRepeaterInfinite : BTDecorator
{
    
    public BTRepeaterInfinite(BTNode child) : base(child){}

    public override void Tick()
    {
        // se repite por siempre
        if(child.EstadoActual == Estados.SUCCESS 
        || child.EstadoActual == Estados.FAILURE){
            child.Reset();
        }

        if(EstadoActual == Estados.IDLE)
            EstadoActual = Estados.RUNNING;

        child.Tick();
    }
}
