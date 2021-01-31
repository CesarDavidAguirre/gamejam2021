using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPiedras : MonoBehaviour
{
    public GameObject EnemigosASpawnear;
    public float Temporizador;
    float TemporizadorCuentaAtras;


    #region VarOscilacion
    public float Velocidad;
    public float Desfase;
    public Transform Nodo1;
    public Transform Nodo2;
     Transform target;    
    #endregion VarOscilacion
    // Start is called before the first frame update
    void Start()
    {
        TemporizadorCuentaAtras = Temporizador;
        target = Nodo1;
    }

    // Update is called once per frame
    void Update()
    {
        if (TemporizadorCuentaAtras <= 0)
        {
            TemporizadorCuentaAtras = Random.Range(2,4);
            SpawnearEnemigos();
        }
        TemporizadorCuentaAtras -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Oscilacion();
    }
    void SpawnearEnemigos()
    {
        Instantiate(EnemigosASpawnear, transform.position, Quaternion.identity);
    }
    void Oscilacion()
    {
        #region Oscilacion
        Vector3 targetVec3 = new Vector3(target.position.x 
                                        , target.position.y + Desfase,
                                        target.position.y);
        transform.position = Vector3.MoveTowards(this.transform.position,
                                                targetVec3,
                                                Time.deltaTime * Velocidad);

        if ((transform.position.x == Nodo1.position.x)) target = Nodo2;
        if ((transform.position.x == Nodo2.position.x)) target = Nodo1;
        #endregion Oscilacion
    }
}
