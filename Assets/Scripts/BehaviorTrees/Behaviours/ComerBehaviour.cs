using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComerBehaviour : MonoBehaviour
{
    public bool Terminado{
        get;
        set;
    }

    // Start is called before the first frame update
    void Start()
    {
        Terminado = false;
        StartCoroutine(EjecutarAccion());
    }
    
    IEnumerator EjecutarAccion(){
        yield return new WaitForSeconds(3);
        Terminado = true;
    }
}
