using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRepeater : BTDecorator
{
    private int repetitions, counter;

    public BTRepeater(BTNode child, int repetitions) : base(child){

        this.repetitions = repetitions;
        counter = 0;
    }

    public override void Tick(){

        // si ya acabo los loops no sigue
        if(EstadoActual == Estados.SUCCESS)
            return;

        // si el hijo acabó la ejecución actual actualiza el contador 
        // y resetea al hijo
        if(child.EstadoActual == Estados.SUCCESS 
        || child.EstadoActual == Estados.FAILURE){
            counter++;
            child.Reset();
        }

        // si llegamos al límite de la cuenta ya terminamos
        if(counter == repetitions){
            EstadoActual = Estados.SUCCESS;
            return;
        }

        if(EstadoActual == Estados.IDLE)
            EstadoActual = Estados.RUNNING;

        child.Tick();
    }

    public override void Reset()
    {
        base.Reset();
        counter = 0;
    }
}
