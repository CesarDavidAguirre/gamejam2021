using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo_Script : MonoBehaviour
{
    public float tempo;
    float tempo_Contador;
    void Start()
    {
        tempo_Contador = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        
        tempo_Contador -= Time.deltaTime;
        if (tempo_Contador<= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
