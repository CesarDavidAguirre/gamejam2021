using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Nave : MonoBehaviour
{
    public float Velocidad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * Velocidad , 0 , 0);
    }
}
