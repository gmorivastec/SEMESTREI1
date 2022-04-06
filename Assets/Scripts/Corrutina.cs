using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutina : MonoBehaviour
{

    private IEnumerator ienumerator;
    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(EjemploDeCorrutina());
        // StartCoroutine(Corrutina2());

        // 1era manera de iniciar corrutina
        // StartCoroutine("Corrutina2");

        ienumerator = Corrutina2();
        coroutine = StartCoroutine(ienumerator);
    }

    // Update is called once per frame
    void Update()
    {
        
        // 2 cosas aquí
        // - input
        // - movimiento
        if(Input.GetKeyDown(KeyCode.A)){
           StopCoroutine("Corrutina2"); 
           // StartCoroutine("Corrutina2");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            StopAllCoroutines();
        }

        if(Input.GetKeyDown(KeyCode.D)){
            // 2da manera de detener corrutina - con referencia a su IEnumerator
            StopCoroutine(ienumerator); 
        }

        if(Input.GetKeyDown(KeyCode.G)){
            // 3era manera - con referencia a un objeto de tipo coroutine
            StopCoroutine(coroutine);
        }
    }

    // Corrutina

    /*
    multilinea
    más contenido
    todavía más
    */

    // mecanismo para tener un flujo paralelo al principal
    // muy utilizado en comportamiento recurrente

    // como se escribe
    // regresan un ienumerator
    // imagina que es un turno del banco

    // idiom - estandard de programación para un lenguaje
    // C# - basado en C (C Sharp - C Sostenido)
    IEnumerator EjemploDeCorrutina(){
        
        // normalmente tiene una espera 
        yield return new WaitForSeconds(2);

        // lógica de algún tipo (ejemplo: disparar, checar distancias, checar vida, etc)
        print("CORRUTINA 1");
    }

    IEnumerator Corrutina2(){
       
       // hagamos un loop! 

       // loop infinito
       // NO hacer fuera de corrutina
       while(true){
       
           print("CORRUTINA 2");
           // los compiladores asumen que un numero decimal es de tipo double
           // ponerle una f le indica al compilador que es float 

           // rule of thumb - si se queja ponle una f
           yield return new WaitForSeconds(0.5f);
       }
        
    }
}
