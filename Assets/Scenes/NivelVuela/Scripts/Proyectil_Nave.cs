using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Nave : MonoBehaviour
{
    public float Velocidad;

    float VidaUtil = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        VidaUtil -= Time.deltaTime;
        if (VidaUtil<=0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Time.deltaTime * Velocidad , 0 , 0);
    }
}
