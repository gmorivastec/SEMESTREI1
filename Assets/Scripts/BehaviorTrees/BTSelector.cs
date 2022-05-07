using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTComposite
{
    public override void Tick(){

        // checa tu estado 
        if(EstadoActual == Estados.FAILURE || EstadoActual == Estados.SUCCESS)
            return;

        // cambiar nuestro estado a running
        EstadoActual = Estados.RUNNING;

        // en selector cuando cualquier hijo es SUCCESSFUL el padre también
        if(children[hijoActual].EstadoActual == Estados.SUCCESS){
            EstadoActual = Estados.SUCCESS;
            return;
        }

        if(children[hijoActual].EstadoActual == Estados.FAILURE){
            
            // checa si es último
            if(hijoActual == children.Count - 1){
                EstadoActual = Estados.FAILURE;
                return;
            }

            hijoActual++;
        }

        children[hijoActual].Tick();
    }
}
