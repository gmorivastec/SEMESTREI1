using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTInverter : BTDecorator
{
    public BTInverter(BTNode child) : base(child){}

    public override void Tick(){

        if(child.EstadoActual == Estados.FAILURE){
            EstadoActual = Estados.SUCCESS;
            return;
        }

        if(child.EstadoActual == Estados.SUCCESS){
            EstadoActual = Estados.FAILURE;
            return;
        }

        if(EstadoActual == Estados.IDLE){
           EstadoActual = Estados.RUNNING;
        }

        child.Tick();
    }
}
