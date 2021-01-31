using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigoVolador : MonoBehaviour
{
   
    public float Velocidad = 1;
    
    public float cantidadEsquirlas;
    float cantidadEsquirlasAngle;
    public GameObject Esquirlas;
    float VidaDisparo;
        
    void Start()
    {
        VidaDisparo = Random.Range(1,4);
        cantidadEsquirlasAngle = 360 / cantidadEsquirlas;
    }

    
    void Update()
    {
        VidaDisparo -= Time.deltaTime;
       
        if (VidaDisparo <= 0)
        {
            float angulo = 0;
            
            for (int i = 0; i < cantidadEsquirlas; i++)
            {
                Instantiate(Esquirlas , this.transform.position , Quaternion.Euler(0,0,angulo));
                angulo += cantidadEsquirlasAngle;
            }
            Destroy(this.gameObject);

        }
       
        transform.Translate(0,Time.deltaTime * Velocidad ,0);
    }

    
}
