using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// personajes de fantasía
// estilo D&D
[CreateAssetMenu(menuName = "ScriptableObjects/Personaje")]
public class PersonajeScriptableObject : ScriptableObject
{
    // qué cosas definir aquí 
    // puros atributos - valores que definen las cualidades de un objeto
    public int vitalidad;
    public int fuerza;
    public int carisma;
    public int destreza;
    public string nombre;
    public GameObject unGameObject;
    public AudioClip[] clip;
    public CharacterController characterController;
    public Texture2D texturita;
    
}
