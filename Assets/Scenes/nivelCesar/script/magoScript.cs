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

    float vida = 100;
    public Image healdBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        if (Input.GetKeyDown(KeyCode.Space) && !salto)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("entro al if");
            SceneManager.LoadScene("boss");
        }
        if (collision.CompareTag("Enemy"))
        {
            vida = vida - 20;
            healdBar.fillAmount = vida / 100;
        }
    }

}
