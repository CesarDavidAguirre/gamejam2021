using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Script : MonoBehaviour
{
    public ControladorJuego GC;
    public SpriteRenderer SPR;
    public Color colorInicial;
    public Color ColorHit;
    float TiempoFade = 0.2f;
    
    void Start()
    {
        SPR.color = colorInicial;
    }

    // Update is called once per frame
    void Update()
    {
        TiempoFade -= Time.deltaTime;
        if(TiempoFade <= 0)
        {
            SPR.color = colorInicial;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "disparoPJ")
        {
            GC.VidaBoss -= 2;            
            SPR.color = ColorHit;
            TiempoFade = 0.2f;
        }
    }

    IEnumerator Hit()
    {
        SPR.color = ColorHit;
        yield return new WaitForSeconds(0.5f);
        SPR.color = colorInicial;
    }
}
