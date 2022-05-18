using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSucceder : BTDecorator
{
    public BTSucceder(BTNode child) : base(child){}

    public override void Tick(){

        if(child.EstadoActual == Estados.FAILURE 
        || child.EstadoActual == Estados.SUCCESS){
            EstadoActual = Estados.SUCCESS;
            return;
        }

        if(EstadoActual == Estados.IDLE){
            EstadoActual = Estados.RUNNING;
        }

        child.Tick();
            
    }
}
