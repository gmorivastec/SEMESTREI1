using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perrito : MonoBehaviour
{
    [SerializeField]
    private Transform ardilla;

    [SerializeField]
    private float distanciaConArdilla;

    [SerializeField]
    private float frecuenciaDeChequeo;

    [SerializeField]
    private float plenitudDigestiva = 100;

    [SerializeField]
    private float hambreMinima;

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


        StartCoroutine(ChecarArdilla());
        StartCoroutine(ChecarHambre());
    }

    // Update is called once per frame
    void Update()
    {
        // 1era versión de transiciones - por medio de teclado
        
        /*

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
        */
    }

    // "acariciar" por medio de click
    void OnMouseDown(){
        CambiarEstado(Simbolos.ACARICIAR);
    }

    // lo mejor es detonar un cambio basado en un trigger de lógica
    // ejemplo - colisión, entrada, etc

    // podemos checar en intervalos regulares utilizando una corrutina
    IEnumerator ChecarArdilla(){

        // si estamos más cerca de la ardilla
        // que la distancia valida entonces aplicamos símbolo
        while(true){

            float distancia = Vector3.Distance(transform.position, ardilla.position);

            if(distancia < distanciaConArdilla){
                CambiarEstado(Simbolos.ARDILLA);
            }

            yield return new WaitForSeconds(frecuenciaDeChequeo);
        }
    }

    IEnumerator ChecarHambre() {

        while(true){

            if(plenitudDigestiva < hambreMinima)
                CambiarEstado(Simbolos.OLER_COMIDA);
            
            yield return new WaitForSeconds(frecuenciaDeChequeo);
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
