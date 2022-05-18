using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTComer : BTNode
{

    private ComerBehaviour comportamiento;

    public BTComer(ComerBehaviour comportamiento) {
        this.comportamiento = comportamiento;
    }
    public override void Tick(){

        // aquí no sirve print
        // print();

        Debug.Log("tick en BTComer");

        if(EstadoActual == Estados.IDLE){
            
            comportamiento.enabled = true;
            EstadoActual = Estados.RUNNING;
            return;
        }

        if(EstadoActual == Estados.RUNNING){
            if(comportamiento.Terminado){
                comportamiento.enabled = false;
                EstadoActual = Estados.SUCCESS;
                return;
            }
        }
    }

    public override void Reset(){
        EstadoActual = Estados.IDLE;
        comportamiento.Terminado = false;
    }
}
