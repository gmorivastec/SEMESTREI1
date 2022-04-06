using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perrito : MonoBehaviour
{
    // referencia para llevar el control
    private Nodo actual;
    private MonoBehaviour comportamientoActual;

    // Start is called before the first frame update
    void Start()
    {
        
        // Estados
        Nodo dormido = new Nodo("DORMIDO", typeof(DormidoBehaviour));
        Nodo ladrando = new Nodo("LADRANDO", typeof(LadrandoBehaviour));
        Nodo sentado = new Nodo("SENTADO", typeof(SentadoBehaviour));
        Nodo enojado = new Nodo("ENOJADO", typeof(EnojadoBehaviour));

        // Transiciones
        dormido.AgregarArco(Simbolos.ARDILLA, ladrando);
        dormido.AgregarArco(Simbolos.ACARICIAR, sentado);
        dormido.AgregarArco(Simbolos.RUIDO_FUERTE, dormido);

        ladrando.AgregarArco(Simbolos.OLER_COMIDA, sentado);
        ladrando.AgregarArco(Simbolos.ARDILLA, enojado);
        ladrando.AgregarArco(Simbolos.ACARICIAR, dormido);
        
        sentado.AgregarArco(Simbolos.RUIDO_FUERTE, enojado);

        enojado.AgregarArco(Simbolos.ACARICIAR, dormido);

        // Estado inicial
        actual = dormido;

        // tenemos que agregar comportamiento / behaviour dinámicamente
        comportamientoActual = gameObject.AddComponent(actual.Comportamiento) as MonoBehaviour;

    }

    // Update is called once per frame
    void Update()
    {
        // 1era versión de transiciones - por medio de teclado
        if(Input.GetKeyDown(KeyCode.A)){
            CambiarEstado(Simbolos.ACARICIAR);
        }

        if(Input.GetKeyDown(KeyCode.R)){
            CambiarEstado(Simbolos.ARDILLA);
        }

        if(Input.GetKeyDown(KeyCode.C)){
            CambiarEstado(Simbolos.OLER_COMIDA);
        }

        if(Input.GetKeyDown(KeyCode.F)){
            CambiarEstado(Simbolos.RUIDO_FUERTE);
        }
    }

    private void CambiarEstado(Simbolos simbolo){
        
        // primero vamos viendo a dondoe vamos
        Nodo siguiente = actual.AplicarSimbolo(simbolo);
        
        // 2 opciones - es igual al nodo donde estamos o no 
        if(actual != siguiente){

            actual = siguiente;

            // destruir script de componente anterior
            Destroy(comportamientoActual);

            // agregar script de componente nuevo
            comportamientoActual = gameObject.AddComponent(actual.Comportamiento) as MonoBehaviour;
        }
    }
}
