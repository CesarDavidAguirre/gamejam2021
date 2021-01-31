using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject EnemigosASpawnear;
    public float Temporizador;
    public float Cadencia;
    public int CantidadACrear;
    float TemporizadorCuentaAtras;
    bool EjecutandoCreacion = false;
    bool OscilacionPermitida = true;

    #region VarOscilacion
    public float Velocidad;
    public float Desfase;
    public Transform Nodo1;
    public Transform Nodo2;
    Transform target;
    public bool Moverse;
    #endregion VarOscilacion
    void Start()
    {
        TemporizadorCuentaAtras = Temporizador;
        target = Nodo2;
    }

    // Update is called once per frame
    void Update()
    {
        if (TemporizadorCuentaAtras <= 0)
        {
            TemporizadorCuentaAtras = Temporizador;
            StartCoroutine(CrearEnemigosEnumerator(1f));
        }

        if(!EjecutandoCreacion)TemporizadorCuentaAtras -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        if (OscilacionPermitida) Oscilacion();
    }

    void SpawnearEnemigos()
    {
        Instantiate(EnemigosASpawnear, transform.position, Quaternion.identity);
    }


    void Oscilacion()
    {
        #region Oscilacion
        Vector3 targetVec3 = new Vector3(target.position.x + Desfase
                                        , target.position.y,
                                        target.position.y);
        transform.position = Vector3.MoveTowards(this.transform.position,
                                                targetVec3,
                                                Time.deltaTime * Velocidad);

        if ((transform.position.y == Nodo1.position.y)) target = Nodo2;
        if ((transform.position.y == Nodo2.position.y)) target = Nodo1;
        #endregion Oscilacion
    }
    IEnumerator CrearEnemigosEnumerator(float v)
    {
        OscilacionPermitida = false;
        EjecutandoCreacion = true;
        for (int i = 0; i < CantidadACrear; i++)
        {
            yield return new WaitForSeconds(1);
            SpawnearEnemigos();
        }
        EjecutandoCreacion = false;
        OscilacionPermitida = true;

    }
}
