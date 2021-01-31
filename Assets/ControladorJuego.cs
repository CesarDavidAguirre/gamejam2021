using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    public int VidaPersonaje = 10;
    public float VidaBoss = 1000;
    public Rigidbody2D Personaje;
    public Image BarradeVida;
    public float Porcentaje;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Porcentaje = VidaBoss/1000;
        BarradeVida.fillAmount = Porcentaje;
        if (VidaPersonaje <= 0) Personaje.gravityScale = 8;
    }
}
