using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : BTComposite
{
    public override void Tick(){

        // checa tu estado 
        if(EstadoActual == Estados.FAILURE || EstadoActual == Estados.SUCCESS)
            return;

        // cambiar nuestro estado a running
        EstadoActual = Estados.RUNNING;

        // checa el estado del hijo actual
        if(children[hijoActual].EstadoActual == Estados.FAILURE){
            EstadoActual = Estados.FAILURE;
            return;
        }

        if(children[hijoActual].EstadoActual == Estados.SUCCESS){
            
            // checar si estamos en último hijo
            if(hijoActual == children.Count - 1){
                EstadoActual = Estados.SUCCESS;
                return;
            }

            // si no fue último hijo moverse de hijo
            hijoActual++;
        }

        children[hijoActual].Tick();
    }
}
