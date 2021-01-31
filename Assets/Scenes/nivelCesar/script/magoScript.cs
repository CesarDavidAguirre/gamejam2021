using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class magoScript : MonoBehaviour
{
    public float velocidad;
    public Animator animator;
    public float fuerzaSalto;
    private bool salto = false;
    [Range(0.1f, 5)] public float CadenciaDisparoFija;
    float CadenciaDisparoContador;
    public GameObject PF_Proyectil;
    public GameObject PF_ProyectilIzq;
    public Transform PuntoDeDisparo;
    public Transform PuntoDeDisparoIzq;
    float vida = 150;
    public Image healdBar;
    float vidaTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaTotal = vida;
        CadenciaDisparoContador = CadenciaDisparoFija;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();

        if ((Input.GetKey(KeyCode.Space)))
        {

            animator.SetBool("Disparo", true);
        } else animator.SetBool("Disparo", false);

        if ((Input.GetKey(KeyCode.Space)) && (CadenciaDisparoContador <= 0)) DispararDerecha();

        if (Input.GetKeyDown(KeyCode.UpArrow) && !salto)
        {
            animator.SetBool("saltar", true);
            salto = true;
        }
        if (Input.GetAxis("Horizontal") > 0 )
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("correr", true);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("correr", true);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("correr", false);
        }
        CadenciaDisparoContador -= Time.deltaTime;
    }

    void Mover()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")* velocidad , this.GetComponent<Rigidbody2D>().velocity.y);
    } 
    
    void Salto() 
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
        animator.SetBool("saltar", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("suelo"))
        {
            salto = false;
        }

       

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            vida = vida - 20;
            if (vida <= 0) SceneManager.LoadScene("gameOver");
            healdBar.fillAmount = vida / vidaTotal;
        }
    }

    void DispararDerecha()
    {
        animator.Play("Atack");
        if (this.GetComponent<SpriteRenderer>().flipX)
        {
            Instantiate(PF_ProyectilIzq, PuntoDeDisparoIzq.position, Quaternion.identity);
        }
        else
        {
            Instantiate(PF_Proyectil, PuntoDeDisparo.position, Quaternion.identity);
        }
        
        

        CadenciaDisparoContador = CadenciaDisparoFija;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("boss");
        }
        if (collision.CompareTag("Enemy"))
        {
            vida = vida - 20;
            if (vida <= 0)SceneManager.LoadScene("gameOver");
            healdBar.fillAmount = vida / vidaTotal;
        }
    }


}
