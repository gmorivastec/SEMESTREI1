using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTChecarCansancio : BTNode
{
    private DormirBehaviour comportamiento;
    private int staminaDeCansado;

    public BTChecarCansancio(DormirBehaviour comportamiento, int staminaDeCansado){
        this.comportamiento = comportamiento;
        this.staminaDeCansado = staminaDeCansado;
    }
    public override void Tick(){
        Debug.Log("Tick BTChecarCansancio");

/*
        if(EstadoActual == Estados.IDLE){
            EstadoActual = Estados.RUNNING;
        }

        if(EstadoActual == Estados.RUNNING){
            if(comportamiento.stamina <= staminaDeCansado){
                EstadoActual = Estados.SUCCESS;
            }
        }
        */
        if(comportamiento.stamina <= staminaDeCansado){
            EstadoActual = Estados.SUCCESS;
        } else {
            EstadoActual = Estados.FAILURE;
        }
    }

    public override void Reset(){
        EstadoActual = Estados.IDLE;
    }
}
