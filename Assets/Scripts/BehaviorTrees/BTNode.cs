using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// una enumeración es un tipo de dato con valores posibles
// limitados a un conjunto finito
public enum Estados{
    IDLE,
    SUCCESS, 
    FAILURE,
    RUNNING
}

public abstract class BTNode
{
    public Estados EstadoActual {
        get;
        protected set;
    }

    public BTNode() {
        EstadoActual = Estados.IDLE;
    }

    // método del cual definimos firma
    // pero no implementación
    public abstract void Tick();

    public abstract void Reset();
}
