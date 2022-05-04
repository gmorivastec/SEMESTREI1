using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaSO : MonoBehaviour
{

    [SerializeField]
    private PersonajeScriptableObject datos;

    private int vitalidad;

    // Start is called before the first frame update
    void Start()
    {
        vitalidad = datos.vitalidad;
        print(datos.nombre);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
