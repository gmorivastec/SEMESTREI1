using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{

    [SerializeField]
    private float frecuencia = 0.5f;

    [SerializeField]
    private GameObject proyectil;
    
    private IEnumerator disparoCorrutina;

    // Start is called before the first frame update
    void Start()
    {

        if(proyectil == null)
            throw new System.Exception("REFERENCIA A PROYECTIL NULA");
        
        disparoCorrutina = Disparo();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(h * 10 * Time.deltaTime, v * 10 * Time.deltaTime, 0);

        // al presionar la barra espaciadora
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(disparoCorrutina);
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            StopCoroutine(disparoCorrutina);
        }
    }

    IEnumerator Disparo() {

        while(true){

            // instanciar es clonar un objeto 
            // hacemos esto para generar nuevos game objects en gameplay

            // https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
            Instantiate(proyectil, transform.position, transform.rotation);

            yield return new WaitForSeconds(frecuencia);
        }
    }
}