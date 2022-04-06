using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{

    // DÓNDE TE PUEDE SERVIR:
    // - Managers
    // - Personajes importantes
    // acuérdate que tiene 2 ventajas principales:
    // - se asegura que sólo hay 1
    // - acceso rápido a información 

    // singleton - patrón de diseño 
    // se asegura que sólo hay una instancia de un tipo
    // tradicionalmente limitamos la creación por medio del constructor privado
    // en unity destruimos si es que hay alguien que ya existe

    // 1er requisito - 1 instancia de la clase estática privada
    // propiedad - manejador de acceso a una variable
    // portero que define quien entra y quien no
    public static Singleton Instance {
        get; // quien lee
        private set; // quien puede escribirla
    }


    // Start is called before the first frame update
    void Start()
    {
        // 2do requisito - asegurarse que sólo exista uno
        if(Instance != null){
            
            // al llegar a este start ya estaba asignada
            // destruir esta instancia
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        // así marcamos un objeto para sobrevivir el cambio de escena
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene("Escena2");
        }
    }
}
