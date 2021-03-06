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
    void OnEnable()
    {
        stamina = 100;
        Terminado = false;
        StartCoroutine(EjecutarAccion());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
    
    IEnumerator EjecutarAccion(){
        yield return new WaitForSeconds(3);
        Terminado = true;
    }
}
