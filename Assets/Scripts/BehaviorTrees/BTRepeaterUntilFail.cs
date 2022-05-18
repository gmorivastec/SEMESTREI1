using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRepeaterUntilFail : BTDecorator
{
    public BTRepeaterUntilFail(BTNode child): base(child){}

    public override void Tick()
    {
        if(EstadoActual == Estados.SUCCESS)
            return;

        if(child.EstadoActual == Estados.FAILURE){
            EstadoActual = Estados.SUCCESS;
            return;
        }

        if(child.EstadoActual == Estados.SUCCESS){
            child.Reset();
        }

        if(EstadoActual == Estados.IDLE)
            EstadoActual = Estados.RUNNING;
        
        child.Tick();
    }
}
