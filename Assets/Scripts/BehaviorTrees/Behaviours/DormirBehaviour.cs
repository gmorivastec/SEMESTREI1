using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormirBehaviour : MonoBehaviour
{
    public int stamina;
    public bool Terminado{
        get;
        set;
    }

    // Start is called before the first frame update
    void Start()
    {
        stamina = 100;
        Terminado = false;
        StartCoroutine(EjecutarAccion());
    }
    
    IEnumerator EjecutarAccion(){
        yield return new WaitForSeconds(3);
        Terminado = true;
    }
}
