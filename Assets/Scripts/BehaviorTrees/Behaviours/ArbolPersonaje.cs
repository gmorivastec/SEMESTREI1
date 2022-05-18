using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolPersonaje : MonoBehaviour
{

    private BTRepeaterInfinite root;
    private BTSequence sequence;
    private BTPasear pasear;
    private BTComer comer;
    private BTChecarCansancio checarCansancio;
    private BTDormir dormir;

    // Start is called before the first frame update
    void Start()
    {

        
        sequence = new BTSequence();
        root = new BTRepeaterInfinite(sequence);

        pasear = new BTPasear(GetComponent<PasearBehaviour>());
        comer = new BTComer(GetComponent<ComerBehaviour>());
        checarCansancio = new BTChecarCansancio(GetComponent<DormirBehaviour>(), 150);
        dormir = new BTDormir(GetComponent<DormirBehaviour>());
        
        sequence.AddChild(pasear);
        sequence.AddChild(comer);
        sequence.AddChild(checarCansancio);
        sequence.AddChild(dormir);

        StartCoroutine(TreeTick());
    }

    IEnumerator TreeTick() {
        
        while(true){   
            root.Tick();
            yield return new WaitForSeconds(0.5f);
        }
    }

}
