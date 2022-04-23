using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{


    public int MaximoDeBalitas {
        get { return maximoDeBalitas; }
    }

    [SerializeField]
    private int maximoDeBalitas;

    [SerializeField]
    private GameObject original;

    private List<GameObject> pool;

    // Queue - fila
    private Queue<GameObject> objetosDisponibles;

    // 1ero - el manager del pool debe ser un singleton
    public static PoolManager Instance {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        // aquí es donde aseguramos que exista sólo uno
        if(Instance != null){

            Destroy(gameObject);
        } else {

            Instance = this;
            
            

            // inicializamos lista para que no sea nula
            pool = new List<GameObject>();
            objetosDisponibles = new Queue<GameObject>();

            for(int i = 0; i < maximoDeBalitas; i++){

                //1ero - crear objeto
                GameObject nuevo = Instantiate<GameObject>(original);
                
                //2do - desactivarlo
                nuevo.SetActive(false);

                //3ro - agregarlo al pool 
                pool.Add(nuevo);

                //4to - enfilarlo
                objetosDisponibles.Enqueue(nuevo);
            }

        }
    }


    public void ActivarBala(Vector3 pos){

        // 0ero - verificar que hay objetos disponibles
        if(objetosDisponibles.Count == 0)
            return;

        // 1ero - dequeue de fila - sacar de fila 
        GameObject actual = objetosDisponibles.Dequeue();

        // 2do - mover a posicion donde lo queremos
        actual.transform.position = pos;

        // 3ero - activar 
        actual.SetActive(true);

        // 3ero - actualizar ultimo disponible
        // ultimoDisponible++;
        // ultimoDisponible = ultimoDisponible + 1;
        // ultimoDisponible += 1;
    }

    // PREFIERAN ESTE MÉTODO
    // IMPLEMENTEN CORRUTINA DE ESPERA EN OBJETO
    public void DesactivarBala(GameObject bala){

        // 1ero - verificar que el objeto que pretendemos desactivar
        // ES PARTE DE MI POOL!
        if(!pool.Contains(bala))
            return;

        // 2do - sabiendo que existe desactivamos
        bala.SetActive(false);

        // 3ero - agregamos a fila de disponibles
        objetosDisponibles.Enqueue(bala);

    }

    public void DesactivarPorTiempo(GameObject bala, float tiempo){
        StartCoroutine(TemporizadorDeDesactivado(bala, tiempo));
    }

    private IEnumerator TemporizadorDeDesactivado(GameObject bala, float tiempo) {

        yield return new WaitForSeconds(tiempo);
        DesactivarBala(bala);
    }
}
