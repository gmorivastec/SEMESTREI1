using System.Collections.Generic;
using System;

// enumeración es un tipo de dato (int, float, string, Nodo, MonoBehaviour, etc)
// con un rango limitado de valores posibles
public enum Simbolos {
    OLER_COMIDA,
    ARDILLA,
    RUIDO_FUERTE,
    ACARICIAR
};

// en POO (programación orientada a objetos)
// las clases son metáforas para objetos "reales"
public class Nodo
{
    // atributos
    // características
    public string Nombre {
        get;
        private set;
    }

    // si no necesitamos permisos separados para lectura y escritura
    // podemos usar una variable
    // arreglos o listas ???
    // en un arreglo accedemos a un elemento por medio de un número
    // arreglito[5] = "hola";
    // diccionario es muy parecido PERO en lugar de usar numerito para acceder a un elemento
    // un valor de un tipo predefinido
    private Dictionary<Simbolos, Nodo> transferencia;

    public Type Comportamiento {
        get;
        private set;
    }

    // comportamientos
    // acciones

    // constructor - método que se llama al crear una nueva instancia de este tipo
    // normalmente sirve para inicializar atributos
    public Nodo(string nombre, Type comportamiento){
        // c# es case sensitive - sensible a mayúsculas / minúsculas
        Nombre = nombre;
        Comportamiento = comportamiento;

        // recuerda inicializar objetos como este 
        transferencia = new Dictionary<Simbolos, Nodo>();
    }

    // capacidad de agregar nueva flechita 
    public void AgregarArco(Simbolos simbolo, Nodo nodo){
        transferencia.Add(simbolo, nodo);
    }

    // decir a donde dirige un símbolo
    public Nodo AplicarSimbolo(Simbolos simbolo){

        // si no está definido 
        if(transferencia.ContainsKey(simbolo)){

            return transferencia[simbolo];

        } else {

            // si no está especificado en el diccionario
            return this;

        }
    }
}
