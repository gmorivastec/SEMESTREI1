using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // si vamos a instanciar dinámicamente 
        // 1. evaluar si podemos hacer pooling (lo vamos a checar después)
        // 2. si no vamos a hacer pooling asegurarse que haya una estrategia de destrucción
        Destroy(gameObject, 3);

        // cómo obtener referencias en runtime
        // es fácil de usar 
        // inconveniente: es lento
        GameObject nave = GameObject.Find("Nave");
        print("nave: " + nave.transform.name);


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 10 * Time.deltaTime, 0);
        // pa que vean
        // acceso es de complejidad constante
        // - muy rápido
        print(Singleton.Instance.transform.name);
    }
}
