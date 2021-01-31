using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovPersonaje_Nave : MonoBehaviour
{
    public float VelocidadMov = 3;
    public float CD_Escudo;
    float CD_Escudo_Contador;
    [Range(0.1f, 5)] public float CadenciaDisparoFija;
    float CadenciaDisparoContador;
    float horizontal;
    float vertical;
    public bool EstaEscudado = false;
    public Transform PuntoDeDisparo;
    public GameObject PF_Proyectil;
    public GameObject Escudo;
    GameObject EscudoCreado;
    public ControladorJuego AdminVidas;
    public Image healdBar;
    float vidaTotal;


    public Animator anim;
    
    void Start()
    {
        CadenciaDisparoContador = CadenciaDisparoFija;
        vidaTotal = AdminVidas.VidaPersonaje;


    }

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if ((Input.GetKey(KeyCode.Space)))
        {
            anim.SetBool("Disparo", true);
            anim.Play("Atack");
        }
        else anim.Play("Idle");
        if ((Input.GetKey(KeyCode.Space)) && (CadenciaDisparoContador <= 0)) Disparar();
        if (Input.GetKeyDown(KeyCode.LeftControl) && (CD_Escudo_Contador <= 0))
        {
            EstaEscudado = true;
            EscudoCreado = Instantiate(Escudo, this.transform.position, Quaternion.identity);
            EscudoCreado.transform.parent = this.transform;
            CD_Escudo_Contador = CD_Escudo;
        }
        if (EscudoCreado == null) EstaEscudado = false;
        CadenciaDisparoContador -= Time.deltaTime;
        CD_Escudo_Contador -= Time.deltaTime;

       
    }

    private void FixedUpdate()
    {
        Moverse();
    }

    void Disparar()
    {
        anim.Play("Atack");
        Instantiate(PF_Proyectil, PuntoDeDisparo.position, Quaternion.identity);        
        CadenciaDisparoContador = CadenciaDisparoFija;
        
    }

    void Moverse()
    {
        Vector3 mov = Vector3.zero;
        mov.x = horizontal * Time.deltaTime * VelocidadMov;
        mov.y = vertical * Time.deltaTime * VelocidadMov;
        this.transform.Translate(mov);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemigo") && !EstaEscudado)
        {
            EstaEscudado = false;            
            AdminVidas.VidaPersonaje -= 1;
            if (AdminVidas.VidaPersonaje <= 0) SceneManager.LoadScene("gameOver");
            healdBar.fillAmount = AdminVidas.VidaPersonaje / vidaTotal;
            Destroy(collision.gameObject);            
        }
        
    }
}
